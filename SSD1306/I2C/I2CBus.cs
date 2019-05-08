using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

using Mono.Unix.Native;
using Mono.Unix;

namespace Mono.Linux.I2C
{
    public class I2CBus:IDisposable
    {
        public const string DefaultDeviceFileFormat = "/dev/i2c-{0}";
        public const int I2C_SLAVE = 0x0703;

        private string _device;
        private int _fd = -1;

        //TODO: change to safehandles
        [DllImport("libc.so.6",SetLastError=true)]
        extern private static int ioctl(int fd, int request, byte x);

        public I2CBus(int index)
        {
            _device = string.Format(DefaultDeviceFileFormat, index);
        }

        public I2CBus(int index,string deviceFileFormat)
        {
            _device = string.Format(deviceFileFormat, index);
        }
        
        public I2CBus(string deviceFile)
        {
            _device = deviceFile;
        }

        public bool IsOpen 
        {
            get 
            {
                return _fd != -1;
            }
        }

        private void OpenIfNotOpen ()
        {
            if (!IsOpen) 
            {
                Open ();
            }
        }

        public override string ToString()
        {
            return string.Format("I2C Bus {0} (File Descriptor {1})", _device, _fd);
        }

        protected void Open()
        {
            _fd = Syscall.open(_device, OpenFlags.O_RDWR);
            if (_fd < 0)
            {
                CheckAndThrowUnixIOException();
            }
        }

        protected void ChangeDevice(byte devAddr)
        {
            OpenIfNotOpen ();

            int ret = ioctl(_fd, I2C_SLAVE, devAddr);
            if (ret < 0)
            {
                CheckAndThrowUnixIOException();
            }
        }

        public async Task<byte> ReadBytesAsync(byte devAddr, byte regAddr, byte length, byte[] data, int offset=0, ushort timeout = 0)
        {
            var task = Task<byte>.Factory.StartNew(() => ReadBytes(devAddr, regAddr, length, data, offset, timeout));
            await task;
            return task.Result;
        }

        public unsafe byte ReadBytes(byte devAddr, byte regAddr, byte length, byte[] data, int offset=0, ushort timeout = 0)
        {
            if (length > 127)
                throw new IOException(_device + ": length > 127");

            //TODO: break this up so that we can await on all 3  native calls
            ChangeDevice(devAddr);

            //fixed(byte* p = &regAddr)
            {
                int ret = (int)Syscall.write(_fd, &regAddr, 1);
                if (ret != 1)
                {
                    CheckAndThrowUnixIOException();
                }
            }

            int count;
            fixed (byte* p = &data[offset])
            {
                count = (int)Syscall.read(_fd, p, (ulong)length);
                if (count < 0)
                {
                    CheckAndThrowUnixIOException();
                }
                else if (count != length)
                {
                    throw new IOException(_device + ": read short: length = " + length + " > " + count);
                }
            }

            return (byte)count;
        }

        public async Task WriteBytesAsync(byte devAddr, byte regAddr, byte length, byte[] data)
        {
            var task = Task.Factory.StartNew(() => WriteBytes(devAddr, regAddr, data));
            await task;
        }

        /** Write multiple bytes to an 8-bit device register.
        * @param devAddr I2C slave device address
        * @param regAddr First register address to write to
        * @param length Number of bytes to write
        * @param data Buffer to copy new data from
        * @return Status of operation (true = success)
        */
        public unsafe void WriteBytes(byte devAddr, byte regAddr, byte[] data)
        {

            int pt1 = 0;
            int pt2;
            byte[] buffer = new byte[128];

            ChangeDevice(devAddr);

            while (pt1 <= data.Length-1)
            {
                pt2 = data.Length-1;
                if (pt2 - pt1 > 126) pt2 = pt1 + 126;
                
                buffer[0] = regAddr;
                var copyLen = pt2 - pt1 + 1;
                Array.Copy(data, pt1, buffer, 1, copyLen);
                copyLen++;
                int count;
                fixed (byte* p = buffer)
                {
                    count = (int)Syscall.write(_fd, p, (ulong)copyLen);
                }

                if (count < 0)
                {
                    CheckAndThrowUnixIOException();
                }
                else if (count != copyLen)
                {
                    throw new IOException(_device + ": write short = " + count);
                }

                pt1 = pt2 + 1;
            }
        }

        public async Task WriteWordsAsync(byte devAddr, byte regAddr, byte length, ushort[] data)
        {
            var task = Task.Factory.StartNew(() => WriteWords(devAddr, regAddr, length, data));
            await task;
        }

        public unsafe void WriteWords(byte devAddr, byte regAddr, byte length, ushort[] data)
        {
            int count = 0;
            byte[] buf = new byte[128];
            int i;

            // Should do potential byteswap and call writeBytes() really, but that
            // messes with the callers buffer

            if (length > 63)
            {
                throw new IOException(_device + ": length > 63");
            }

            ChangeDevice(devAddr);

            buf[0] = regAddr;
            for (i = 0; i < (int)length; i++)
            {
                buf[i * 2 + 1] = (byte)(data[i] >> 8);
                buf[i * 2 + 2] = (byte)data[i];
            }
            fixed (byte* p = buf)
            {
                count = (int)Syscall.write(_fd, p, (ulong)(length * 2 + 1));
            }
            if (count < 0)
            {
                CheckAndThrowUnixIOException();
            }
            else if (count != length * 2 + 1)
            {
                throw new IOException(_device + ": write short");
            }
        }

        public void Close()
        {
            if(IsOpen)
            {
                int ret = Syscall.close(_fd);
                if (ret != 0)
                {
                    CheckAndThrowUnixIOException();
                }
                _fd=-1;
            }
        }
        
        public void Dispose()
        {
          Close();
        }

        private void CheckAndThrowUnixIOException()
        {
            var error = Marshal.GetLastWin32Error();
            throw new UnixIOException(error);
        }
    }
}
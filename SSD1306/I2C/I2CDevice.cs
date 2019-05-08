using System;
using System.IO;
using System.Threading.Tasks;

using uint8_t = System.Byte;
using uint16_t = System.UInt16;
using int8_t = System.Byte;

namespace Mono.Linux.I2C
{
    public class I2CDevice
    {
        private I2CBus _bus;
        private byte _deviceAddress;

        public I2CDevice(I2CBus bus, byte deviceAddress)
        {
          _bus=bus;
          _deviceAddress=deviceAddress;
        }

        public byte Address
        {
            get { return _deviceAddress; }
        }

        public override string ToString()
        {
            return string.Format("I2C Device {0} on {1}",_deviceAddress,_bus);
        }

        public async Task<byte[]> ReadAsync(byte regAddr, byte length, ushort timeout = 0)
        {
            byte[] buffer = new byte[length];
            var task = _bus.ReadBytesAsync(_deviceAddress, regAddr, length, buffer, offset: 0, timeout:timeout);
            await task;
            return buffer;
        }

        public byte[] Read(byte regAddr, byte length, ushort timeout = 0)
        {
            byte[] buffer = new byte[length];
            byte ret = ReadBytes(regAddr, length, buffer,timeout: timeout);
            return buffer;
        }

        /** Read a single bit from an 8-bit device register.
        * @param regAddr Register regAddr to read from
        * @param bitNum Bit position to read (0-7)
        * @param data Container for single bit value
        * @param timeout Optional read timeout in milliseconds (0 to disable, leave off to use default class value in I2Cdev::readTimeout)
        * @return Status of read operation (true = success)
        */
        public uint8_t ReadBit(uint8_t regAddr, uint8_t bitNum, uint16_t timeout = 0)
        {
            uint8_t b = ReadByte(regAddr, timeout);
            return (byte)(b & (1 << bitNum));
        }
        public bool ReadBitB(uint8_t regAddr, uint8_t bitNum, uint16_t timeout = 0)
        {
            return ReadBit(regAddr, bitNum, timeout) != 0;
        }

        /** Read a single bit from a 16-bit device register.
        * @param regAddr Register regAddr to read from
        * @param bitNum Bit position to read (0-15)
        * @param data Container for single bit value
        * @param timeout Optional read timeout in milliseconds (0 to disable, leave off to use default class value in I2Cdev::readTimeout)
        * @return Status of read operation (true = success)
        */
        public uint16_t ReadBitW(uint8_t regAddr, uint8_t bitNum, uint16_t timeout)
        {
            uint16_t b;
            b = ReadWord(regAddr, timeout);
            return (ushort)(b & (1 << bitNum));
        }

        /** Read multiple bits from an 8-bit device register.
        * @param regAddr Register regAddr to read from
        * @param bitStart First bit position to read (0-7)
        * @param length Number of bits to read (not more than 8)
        * @param data Container for right-aligned value (i.e. '101' read from any bitStart position will equal 0x05)
        * @param timeout Optional read timeout in milliseconds (0 to disable, leave off to use default class value in I2Cdev::readTimeout)
        * @return Status of read operation (true = success)
        */
        public uint8_t ReadBits(uint8_t regAddr, uint8_t bitStart, uint8_t length, uint16_t timeout = 0)
        {
            // 01101001 read byte
            // 76543210 bit numbers
            // xxx args: bitStart=4, length=3
            // 010 masked
            // -> 010 shifted
            uint8_t count, b;
            b = ReadByte(regAddr, timeout);
            uint8_t mask = (byte)(((1 << length) - 1) << (bitStart - length + 1));
            b &= mask;
            b >>= (bitStart - length + 1);
            return (byte)b;
        }

        public uint8_t ReadBits(int regAddr, uint8_t bitStart, uint8_t length, uint16_t timeout = 0)
        {
            return ReadBits((byte)regAddr, bitStart, length, timeout);
        }

        /** Read multiple bits from a 16-bit device register.
        * @param regAddr Register regAddr to read from
        * @param bitStart First bit position to read (0-15)
        * @param length Number of bits to read (not more than 16)
        * @param data Container for right-aligned value (i.e. '101' read from any bitStart position will equal 0x05)
        * @param timeout Optional read timeout in milliseconds (0 to disable, leave off to use default class value in I2Cdev::readTimeout)
        * @return Status of read operation (1 = success, 0 = failure, -1 = timeout)
        */
        public uint16_t ReadBitsW(uint8_t regAddr, uint8_t bitStart, uint8_t length, uint16_t timeout)
        {
            // 1101011001101001 read byte
            // fedcba9876543210 bit numbers
            // xxx args: bitStart=12, length=3
            // 010 masked
            // -> 010 shifted
            uint16_t w = ReadWord(regAddr, timeout);
            uint16_t mask = (ushort)(((1 << length) - 1) << (bitStart - length + 1));
            w &= mask;
            w >>= (bitStart - length + 1);
            return w;
        }

        public async Task<byte> ReadBytesAsync(int regAddr, byte length, byte[] data,int offset=0, ushort timeout = 0)
        {
            return await _bus.ReadBytesAsync(_deviceAddress, (byte)regAddr, length, data,offset,timeout);
        }

        public byte ReadBytes(int regAddr, byte length, byte[] data,int offset=0, ushort timeout = 0)
        {
            return _bus.ReadBytes(_deviceAddress, (byte)regAddr, length, data,offset, timeout);
        }

        /** Read single byte from an 8-bit device register.
        * @param regAddr Register regAddr to read from
        * @param data Container for byte value read from device
        * @param timeout Optional read timeout in milliseconds (0 to disable, leave off to use default class value in I2Cdev::readTimeout)
        * @return Status of read operation (true = success)
        */
        public uint8_t ReadByte(uint8_t regAddr, uint16_t timeout = 0)
        {
            return Read(regAddr, 1, timeout)[0];
        }
        public uint8_t ReadByte(int regAddr, uint16_t timeout = 0)
        {
            return Read((byte)regAddr, 1, timeout)[0];
        }

        /** Read single word from a 16-bit device register.
        * @param regAddr Register regAddr to read from
        * @param data Container for word value read from device
        * @param timeout Optional read timeout in milliseconds (0 to disable, leave off to use default class value in I2Cdev::readTimeout)
        * @return Status of read operation (true = success)
        */
        public uint16_t ReadWord(uint8_t regAddr, uint16_t timeout = 0)
        {
            return ReadWords(regAddr, 1, timeout)[0];
        }

        /** Read multiple words from a 16-bit device register.
        * @param regAddr First register regAddr to read from
        * @param length Number of words to read
        * @param data Buffer to store read data in
        * @param timeout Optional read timeout in milliseconds (0 to disable, leave off to use default class value in I2Cdev::readTimeout)
        * @return Number of words read (0 indicates failure)
        */
        public uint16_t[] ReadWords(byte regAddr, byte length, ushort timeout)
        {
            var byteLength = (byte) (length*2);
            var bytes = new byte[byteLength];
            
            var returned = _bus.ReadBytes(_deviceAddress, regAddr, byteLength, bytes, 0, timeout = timeout);

            if (returned != byteLength)
            {
                throw new IOException("Read did not return the correct number of bytes");
            }

            var words = new uint16_t[length];
            for (int i = 0; i < length; i++)
            {
                words[i] = BitConverter.ToUInt16(bytes, i*2);
            }

            return words;
        }

        /** write a single bit in an 8-bit device register.
        * @param regAddr Register regAddr to write to
        * @param bitNum Bit position to write (0-7)
        * @param value New bit value to write
        * @return Status of operation (true = success)
        */
        public void WriteBit(byte regAddr, byte bitNum, byte data)
        {
            byte b = ReadByte(regAddr);
            b = (byte)((data != 0) ? (b | (1 << bitNum)) : (b & ~(1 << bitNum)));
            WriteByte(regAddr, b);
        }

        public void WriteBit(byte regAddr, byte bitNum, bool data2)
        {
            byte data = data2 ? (byte)1 : (byte)0;
            byte b = ReadByte(regAddr);
            b = (byte)((data != 0) ? (b | (1 << bitNum)) : (b & ~(1 << bitNum)));
            WriteByte(regAddr, b);
        }

        /** write a single bit in a 16-bit device register.
        * @param regAddr Register regAddr to write to
        * @param bitNum Bit position to write (0-15)
        * @param value New bit value to write
        * @return Status of operation (true = success)
        */
        public void WriteBitW(byte regAddr, byte bitNum, ushort data)
        {
            ushort w = ReadWord(regAddr);
            w = (ushort)((data != 0) ? (w | (1 << bitNum)) : (w & ~(1 << bitNum)));
            WriteWord(regAddr, w);
        }

        /** Write multiple bits in an 8-bit device register.
        * @param regAddr Register regAddr to write to
        * @param bitStart First bit position to write (0-7)
        * @param length Number of bits to write (not more than 8)
        * @param data Right-aligned value to write
        * @return Status of operation (true = success)
        */
        public void WriteBits(byte regAddr, byte bitStart, byte length, byte data)
        {
            // 010 value to write
            // 76543210 bit numbers
            // xxx args: bitStart=4, length=3
            // 00011100 mask byte
            // 10101111 original value (sample)
            // 10100011 original & ~mask
            // 10101011 masked | value
            byte b = ReadByte(regAddr);
            byte mask = (byte)(((1 << length) - 1) << (bitStart - length + 1));
            data <<= (bitStart - length + 1); // shift data into correct position
            data &= mask; // zero all non-important bits in data
            b &= (byte)~(mask); // zero all important bits in existing byte
            b |= data; // combine data with existing byte
            WriteByte(regAddr, b);
        }

        public void WriteBits(byte regAddr, byte bitStart, byte length, sbyte data)
        {
            WriteBits(regAddr, bitStart, length, unchecked((byte)data));
        }

        public void WriteBits(int regAddr, byte bitStart, byte length, byte data)
        {
            WriteBits((byte)regAddr, bitStart, length, data);
        }

        /** Write multiple bits in a 16-bit device register.
        * @param regAddr Register regAddr to write to
        * @param bitStart First bit position to write (0-15)
        * @param length Number of bits to write (not more than 16)
        * @param data Right-aligned value to write
        * @return Status of operation (true = success)
        */
        public void WriteBitsW(byte regAddr, byte bitStart, byte length, ushort data)
        {
            // 010 value to write
            // fedcba9876543210 bit numbers
            // xxx args: bitStart=12, length=3
            // 0001110000000000 mask byte
            // 1010111110010110 original value (sample)
            // 1010001110010110 original & ~mask
            // 1010101110010110 masked | value
            ushort w = ReadWord(regAddr);
            byte mask = (byte)(((1 << length) - 1) << (bitStart - length + 1));
            data <<= (bitStart - length + 1); // shift data into correct position
            data &= mask; // zero all non-important bits in data
            w &= (ushort)~(mask); // zero all important bits in existing word
            w |= data; // combine data with existing word
            WriteWord(regAddr, w);
        }

        public async Task WriteAsync(byte regAddr, byte[] data)
        {
            await _bus.WriteBytesAsync(_deviceAddress,regAddr,(byte)data.Length,data);
        }

        public void Write(byte regAddr, byte[] data)
        {
            _bus.WriteBytes(_deviceAddress,regAddr,data);
        }

        public async Task WriteByteAsync(byte regAddr, byte data)
        {
            await WriteAsync((byte)regAddr, new byte[] { data });
        }

        /** Write single byte to an 8-bit device register.
        * @param regAddr Register address to write to
        * @param data New byte value to write
        * @return Status of operation (true = success)
        */
        public void WriteByte(byte regAddr, byte data)
        {
            Write(regAddr, new byte[] { data });
        }

        public async Task WriteByteAsync(int regAddr, byte data)
        {
            await WriteByteAsync((byte)regAddr, data);
        }

        public void WriteByte(int regAddr, byte data)
        {
            WriteByte((byte)regAddr, data);
        }

        public async Task WriteByteAsync(byte regAddr, sbyte data)
        {
            await _bus.WriteBytesAsync(_deviceAddress, regAddr, 1, new byte[]{(byte)data});
        }

        public void WriteByte(byte regAddr, sbyte data)
        {
            _bus.WriteBytes(_deviceAddress, regAddr, new byte[]{(byte)data});
        }

        public void WriteBytes(byte regAddr, byte length, byte[] data)
        {
            _bus.WriteBytes (_deviceAddress, regAddr, data);
        }

        public async Task WriteWordAsync(byte regAddr, ushort data)
        {
            await _bus.WriteWordsAsync(_deviceAddress, regAddr, 1, new ushort[] { data });
        }

        /** Write single word to a 16-bit device register.
        * @param regAddr Register address to write to
        * @param data New word value to write
        * @return Status of operation (true = success)
        */
        public void WriteWord(byte regAddr, ushort data)
        {
            _bus.WriteWords(_deviceAddress, regAddr, 1, new ushort[] { data });
        }

        public async Task WriteWordAsync(byte regAddr, short data)
        {
            await WriteWordAsync(regAddr, (ushort)data);
        }

        public void WriteWord(byte regAddr, short data)
        {
            WriteWord(regAddr, (ushort)data);
        }
    }
}
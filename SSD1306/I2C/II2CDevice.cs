using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSD1306.I2C
{
    public interface II2CDevice
    {

        void WriteBytes(byte regAddress, byte[] data);
        void WriteByte(byte regAddress, byte data);
    }
}

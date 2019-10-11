using System;
namespace SSD1306.Fonts
{
    public class FontInfo
    {
    
        public char Character    { get; private set; }
        public uint IndexFrom    { get; private set; }
        public uint IndexTo      { get; private set; }
        public uint Columns      { get; private set; }

        public FontInfo(char chr, uint[] data)
        {
            Character = chr;
            Columns = data[0];
            IndexFrom = data[1];
            IndexTo = data[2];
        }
        
    }
}

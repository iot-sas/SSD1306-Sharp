using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSD1306;

namespace SSD1306.Fonts
{

    /* FontCharacterDescripter contains font information for a  single character */
    public class TasmonaMSB_X : IFont
    {

        public uint PageCount { get; } = 3;
        public uint CharSpacing { get; } = 3;
    
        Dictionary<char, uint[]> FontList = new Dictionary<char, uint[]>();
        public byte[] Data { get; } = new byte[]
    
        //INSERTDATA1
        
        public FontInfo GetChar(char chr)
        {
            FontInfo fontInfo = null;
            uint[] data;
            if (FontList.TryGetValue(chr, out data))
            {
                fontInfo = new FontInfo(chr,data);
            }
        
            return fontInfo;
        }
        
        public TasmonaMSB_X()
        {
            
        //INSERTDATA2
        }
    }
}
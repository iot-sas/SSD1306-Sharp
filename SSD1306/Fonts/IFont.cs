using System;
using SSD1306.Fonts;

namespace SSD1306
{
    public interface IFont
    {
        
        uint PageCount {get;}
        uint CharSpacing {get;}


        byte[] Data {get;}

        FontInfo GetChar(char chr);
    }
}

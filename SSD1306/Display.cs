﻿using System;
using Mono.Linux.I2C;


namespace SSD1306
{
    /// <summary>
    /// SSD1306 I2c OLED display driver
    /// </summary>
    class Display
    {
        public uint ScreenWidthPX       { get; private set; }
        public uint ScreenHeightPx      { get; private set; }
        public uint ScreenPages         { get; private set; }
        private byte[,] DisplayBuffer;

        static public readonly byte DefaultI2CAddress = 0x3C;

        I2CBus i2cBus;
        I2CDevice i2cDevice;

        bool DisplayStateOn = false;


        public Display(I2CDevice I2cDevice, uint WidthPx = 128, uint HeightPx = 32)
        {
                ScreenWidthPX = WidthPx;
                ScreenHeightPx = HeightPx;
                i2cDevice = I2cDevice;
        
                ScreenPages = ScreenHeightPx / 8;
                DisplayBuffer = new byte[ScreenPages,ScreenWidthPX];
        }

       
        /// <summary>
        /// Initialize Display
        /// </summary>
        public void Init()
        {
                DisplayOff();
                SendCommand(0x20, 0x00);    //00 Horizontal 01 Virtical
                SendCommand(0x40);          //Set display RAM display start line //Reset
                SendCommand(0xA0);          //Set Segment Re-map  RESET
                SendCommand(0xA8, 0x1F);    //Set MUX ratio to N+1 MUX
                SendCommand(0xC0);          //Set COM Output Scan Direction 0=normal mode (RESET) 
                SendCommand(0xD3, 0x0);     //Set vertical shift by COM from 0d~63d 
                SendCommand(0xDA, 0x00);    //Set COM Pins Hardware Configuration 
                SendCommand(0xD5, 0x80);    //Set Display Clock Divide Ratio/Oscillator Frequency 
                SendCommand(0xD9, 0xF1);    //Set Pre-charge Period
                SendCommand(0xDB, 0x30);    //Set VCOMH Deselect Level 
                SendCommand(0x81, 0xFF);    // Set Contrast Control for BANK0 
                SendCommand(0xA4);          //Entire Display ON 
                SendCommand(0xA6);          //Set A6 Normal / A7 Inverse Displa
                SendCommand(0x8D, 0x14);    //Disable chargepump(RESET) 
        }

        /// <summary>
        /// Send display buffer to the display
        /// </summary>
        /// <param name="Data">Data.</param>
        private void SendDisplayData(byte[] Data)
        {
            i2cDevice.WriteBytes(0x40,(byte)Data.Length,Data);
        }

        /// <summary>
        /// Send commands to the display
        /// </summary>
        private void SendCommand(params byte[] Command)
        {
            foreach (var data in Command)
            {
                i2cDevice.WriteByte(0x80, data);
            }
        }

        // Write Display Buffer to device
        public void DisplayUpdate()
        {
            if (!DisplayStateOn) DisplayOn();  //Display ON 
            SendCommand(0x21,0x0,0x7F); //Set Column Addressing
            SendCommand(0x22,0x0,0x3);  //Set Page Address

            for (int page=0; page < ScreenPages;page++)
            {
                var data = new byte[ScreenWidthPX];
                Buffer.BlockCopy(DisplayBuffer, (int)(page * ScreenWidthPX), data, 0, (int)ScreenWidthPX);
                SendDisplayData(data);
            }
        }

        public void WriteLineBuff(IFont font, String text, uint row, uint col, uint? CharSpacing = null)
        {
            if (!CharSpacing.HasValue) CharSpacing = font.CharSpacing;
            foreach (Char Character in text)
            {
                col += WriteCharBuff(font,Character, row , col);
                col += CharSpacing.Value;
            }
        }

        public void WriteLineBuff(IFont font,params String[] Lines)
        {
            Array.Clear(DisplayBuffer, 0, DisplayBuffer.Length);
            
            uint row = 0;
            foreach (var text in Lines)
            {
                WriteLineBuff(font,text, row, 0);
                row += font.PageCount;
            }
        }
        
        
        public uint WriteCharBuff(IFont font, Char Chr, UInt32 Row, UInt32 Col )
        {
            if (Chr == ' ') return font.CharSpacing;

            var fontinfo = font.GetChar(Chr);
            
            UInt32 StartCol = Col;
            UInt32 EndCol = StartCol + fontinfo.Columns -1;
            
            for (var index = fontinfo.IndexFrom; index <= fontinfo.IndexTo; index++)
            {
                if (Col<ScreenWidthPX && Row < ScreenPages) DisplayBuffer[Row, Col] = font.Data[index];
                if (++Col > EndCol)
                {
                    Col = StartCol;
                    Row++;
                }
            }
            return fontinfo.Columns;
        }

        public uint CalculateColumnWidth(IFont font, String Text, uint MaxWidthToFill)
        {
       
            uint Col = 0;
            
            foreach (Char Chr in Text)
            {
                if (Chr == ' ')
                {
                    Col += font.CharSpacing;
                }
                else
                {
                    var fontinfo = font.GetChar(Chr);
                    Col += fontinfo.Columns;
                    if (Col > MaxWidthToFill) return 0;
                }
            }
            return Col;
        }

        public void WriteLineBuffProportional(IFont font, String text, UInt32 Row=0, UInt32 Col=0 )
        {
            
            var len = CalculateColumnWidth(font, text,ScreenWidthPX - Col);
            uint gap = (ScreenWidthPX - len) / ((uint)text.Length-1);
            WriteLineBuff(font, text, Row, Col, gap);
        
        }




        public void DisplayOn()
        {
            SendCommand(0xAF);  //Display ON 
            DisplayStateOn = true;
        }

        public void DisplayOff()
        {
            SendCommand(0xAE); //Display OFF
            DisplayStateOn = false;
        }

        public void ClearDisplay()
        {
            DisplayOff();
            Array.Clear(DisplayBuffer, 0, DisplayBuffer.Length);
        }

    }
}
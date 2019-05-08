using System;
using Mono.Linux.I2C;
using SSD1306;
using SSD1306.Fonts;

namespace Test
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            
            ﻿using (var i2cBus = new I2CBus("/dev/i2c-1"))
            {
                var i2cDevice = new I2CDevice(i2cBus, Display.DefaultI2CAddress);
            
                var display = new SSD1306.Display(i2cDevice,128,32,true);
                display.Init();

                var tahmona10 = new Tahmona10();
                var tahmona12 = new Tahmona12();

                display.WriteLineBuffProportional(tahmona10, "Hello World");
                display.WriteLineBuff(tahmona10,"Hello World 123456",2,0);
                
                display.DisplayUpdate();
            }
    
        }
    }
}

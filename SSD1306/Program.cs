using System;
using Mono.Linux.I2C;
using SSD1306.Fonts;

namespace SSD1306
{
    class MainClass
    {
        private static Display display;

        public static void Main(string[] args)
        {
            using (var i2cBus = new I2CBus("/dev/i2c-1"))
            {
                var i2cDevice = new I2CDevice(i2cBus, Display.DefaultI2CAddress);

                display = new SSD1306.Display(i2cDevice,128,32);
                display.Init();

                var Tahmona8 = new Tahmona8();
                var tahmona10 = new Tahmona10();
                var tahmona12 = new Tahmona12();
                var tahmona14 = new Tahmona14();
                var dinerRegular24 = new DinerRegular24();

                display.WriteLineBuffProportional(dinerRegular24,"192.168.0.5");                
                display.DisplayUpdate();
             
                while (true)
                {
                    foreach (var dfont in new IFont[] {dinerRegular24,Tahmona8,tahmona10,tahmona12,tahmona14})
                    {
                        display.WriteLineBuff(dfont,"Hello World 123456",dfont.GetType().Name);
                        display.DisplayUpdate();
                        Console.ReadLine();
                    }
                }
            }
        }
    }
}

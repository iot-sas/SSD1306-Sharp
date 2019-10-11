using System;
using System.IO;
using System.Linq;
namespace SSD1306
{

// Creates font classes.
//
// Uses The Dot Factory - Pass it's output into this.
// http://www.eran.io/the-dot-factory-an-lcd-font-and-image-generator/
// https://github.com/pavius/the-dot-factory
//
// See settings screenshot


    public class MakeFont
    {
        public MakeFont()
        {

            String WriteBuffer = null;
            uint lastindex = 0;
            uint ByteCount = 0;
            
            using (var fileTemplate = File.OpenText(Path.Combine(Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"..//..//Fonts//")),"FontTemplate.cs")))
            using (var file = File.OpenText(Path.Combine(Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"..//..//")),"Tahmona10Text.cs")))
            {
                using (var fileOut = File.CreateText(Path.Combine(Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"..//..//")),"Tahmona10.cs")))
                {

                    while (!fileTemplate.EndOfStream)
                    {
                        var test = fileTemplate.ReadLine();
                        if (test.Contains("INSERTDATA1")) break;
                        fileOut.WriteLine(test);
                    }
                    
                    int inBandMode = 0;

                    while (!file.EndOfStream)
                    {
                        var line = file.ReadLine();

                        if (inBandMode == 0) //Waiting to find start of byte[] to copy
                        {
                            if (line.Contains("const")) inBandMode = 1;
                        }
                        else if (inBandMode == 1) //Waiting for end of byte[]
                        {
                            fileOut.WriteLine(line);
                            ByteCount += (uint)line.Split(new[] { "0x" }, StringSplitOptions.None).Length - 1;
                            if (line.Contains("};")) inBandMode = 2;
                        }
                        else if (inBandMode == 2) //Waiting for next byte[]
                        {
                            if (line.Contains("FONT_CHAR_INFO")) inBandMode = 3;
                        }
                        else if (inBandMode == 3) //Process array
                        {
                            while (!fileTemplate.EndOfStream)
                            {
                                var test = fileTemplate.ReadLine();
                                if (test.Contains("INSERTDATA2")) break;
                                fileOut.WriteLine(test);
                            }
                            inBandMode = 4;
                        }
                        else if (inBandMode == 4) //Process array
                        {
                            var lineTrim = line.Trim();
                            if (lineTrim.Contains("};"))
                            {
                                if (!String.IsNullOrEmpty(WriteBuffer)) fileOut.WriteLine(WriteBuffer.Replace("###",$"{ByteCount}"));
                                break;
                            }

                            var vals = lineTrim.Replace("{", "").Replace("}", "").Replace("//", "").Split(new char[] { ',' },3);
                            vals[2] = vals[2].Trim().Replace("'","\\'").Replace(@"\",@"\\");

                            lastindex = uint.Parse(vals[1].Trim());
                            
                            if (!String.IsNullOrEmpty(WriteBuffer)) fileOut.WriteLine(WriteBuffer.Replace("###",$"{lastindex-1}"));
                            WriteBuffer = $"          FontList.Add('{vals[2].Trim()}',new uint[]{{{vals[0].Trim()},{lastindex},###}});";
                            
                        }

                    }
                    
                    
                    while (!fileTemplate.EndOfStream)
                    {
                        fileOut.WriteLine(fileTemplate.ReadLine());
                    }

                }
            }
        
        }
    }
}

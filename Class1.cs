using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Controls;

namespace WpfApp1
{
    internal class Class1
    {
        public void hshu0(string cshu0, string cshu1)
        {
            using (StreamWriter streamWriter = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + cshu0, true, Encoding.UTF8))
            {
                streamWriter.WriteLine(cshu1);
            }
        }

        public List<string> hshu1(string cshu0)
        {
            List<string> strings = new List<string>();
            using (StreamReader streamReader = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + cshu0, Encoding.UTF8))
            {
                while (streamReader.Peek() >= 0)
                {
                    strings.Add(streamReader.ReadLine());
                }
            }
            return strings;
        }
    }
}
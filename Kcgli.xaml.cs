using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace WpfApp1
{
    /// <summary>
    /// Kcgli.xaml 的交互逻辑
    /// </summary>
    public partial class Kcgli : Window
    {
        public Kcgli()
        {
            InitializeComponent();
            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "商品名称.txt"))
            {
                Class1 class1 = new Class1();
                List<string> strings0 = class1.hshu1("商品名称.txt");
                List<string> strings2 = class1.hshu1("商品价格.txt");
                List<string> strings3 = class1.hshu1("商品数量.txt");
                int bliang0 = 0;
                float bliang1 = 0;
                foreach (string s in strings0)
                {
                    listbox0.Items.Add(s);
                    bliang1 += float.Parse(strings2[bliang0]) * float.Parse(strings3[bliang0]);
                    bliang0++;
                }
                label3.Content = "0";
                label4.Content += bliang1.ToString("0.00");
            }
            else
            {
                label4.Content += "0";
            }
        }

        private void xzhong0(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            Class1 class1 = new Class1();
            List<string> strings1 = class1.hshu1("商品编号.txt");
            List<string> strings2 = class1.hshu1("商品价格.txt");
            List<string> strings3 = class1.hshu1("商品数量.txt");
            label0.Content = strings1[listbox0.SelectedIndex];
            label1.Content = strings2[listbox0.SelectedIndex];
            label2.Content = strings3[listbox0.SelectedIndex];
            label3.Content = (float.Parse(strings2[listbox0.SelectedIndex])*float.Parse(strings3[listbox0.SelectedIndex])).ToString("0.00");
        }
    }
}
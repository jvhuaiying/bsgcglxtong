using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;

namespace WpfApp1
{
    /// <summary>
    /// Rkgli.xaml 的交互逻辑
    /// </summary>
    public partial class Rkgli : Window
    {
        public Rkgli()
        {
            InitializeComponent();
            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "商品名称.txt"))
            {
                Class1 class1 = new Class1();
                List<string> strings = class1.hshu1("商品名称.txt");
                foreach (string s in strings)
                {
                    listbox0.Items.Add(s);
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string bliang0 = spmcheng.Text;
            string bliang1 = spbhao.Text;
            string bliang2 = spjge.Text;
            string bliang3 = spsliang.Text;
            if (bliang0 == "" || bliang1 == "" || bliang2 == "" || bliang3 == "")
            {
                MessageBox.Show("输入框不能为空！", "操作提示");
            }
            else
            {
                if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "商品名称.txt"))
                {
                    Class1 class1 = new Class1();
                    List<string> strings = class1.hshu1("商品名称.txt");
                    if (strings.IndexOf(bliang0) == -1)
                    {
                        class1.hshu0("商品名称.txt", bliang0);
                        class1.hshu0("商品编号.txt", bliang1);
                        class1.hshu0("商品价格.txt", bliang2);
                        class1.hshu0("商品数量.txt", bliang3);
                        listbox0.Items.Add(bliang0);
                        MessageBox.Show("入库完成！", "提示");
                        spmcheng.Text = null;
                        spbhao.Text = null;
                        spjge.Text = null;
                        spsliang.Text = null;
                    }
                    else
                    {
                        List<string> strings1 = class1.hshu1("商品数量.txt");
                        List<string> strings2 = class1.hshu1("商品价格.txt");
                        strings2[strings.IndexOf(bliang0)] = ((float.Parse(strings2[strings.IndexOf(bliang0)]) * float.Parse(strings1[strings.IndexOf(bliang0)]) + float.Parse(bliang2) * float.Parse(bliang3)) / (float.Parse(strings1[strings.IndexOf(bliang0)]) + float.Parse(bliang3))).ToString("0.00");
                        File.Delete(AppDomain.CurrentDomain.BaseDirectory + "商品价格.txt");
                        foreach (string s in strings2)
                        {
                            using (StreamWriter streamWriter = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "商品价格.txt", true, Encoding.UTF8))
                            {
                                streamWriter.WriteLine(s);
                            }
                        }
                        strings1[strings.IndexOf(bliang0)] = ((float.Parse(strings1[strings.IndexOf(bliang0)])*10000 + float.Parse(bliang3)*10000)/10000).ToString();
                        File.Delete(AppDomain.CurrentDomain.BaseDirectory + "商品数量.txt");
                        foreach (string s in strings1)
                        {
                            using (StreamWriter streamWriter = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "商品数量.txt", true, Encoding.UTF8))
                            {
                                streamWriter.WriteLine(s);
                            }
                        }
                        MessageBox.Show("入库完成！", "提示");
                        spmcheng.Text = null;
                        spbhao.Text = null;
                        spjge.Text = null;
                        spsliang.Text = null;
                    }
                }
                else
                {
                    Class1 class1 = new Class1();
                    class1.hshu0("商品名称.txt", bliang0);
                    class1.hshu0("商品编号.txt", bliang1);
                    class1.hshu0("商品价格.txt", bliang2);
                    class1.hshu0("商品数量.txt", bliang3);
                    listbox0.Items.Add(bliang0);
                    MessageBox.Show("入库完成！", "提示");
                    spmcheng.Text = null;
                    spbhao.Text = null;
                    spjge.Text = null;
                    spsliang.Text = null;
                }
            }
        }
    }
}
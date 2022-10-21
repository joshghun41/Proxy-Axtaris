using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;



namespace Proxy_Axtaris
{
    /// <summary>
    /// MainWindow.xaml etkileşim mantığı
    /// </summary>
    public partial class MainWindow : Window
    {
        public interface IProxy
        {
            List<string> GetUrls(string text);
            void SetUrls(string urls);
        }

        public class HelpClass
        {
            public static List<string> GetDatas()
            {
                var result = File.ReadAllText("C:\\Users\\Help\\source\\repos\\Proxy-Axtaris\\Proxy-Axtaris\\txt\\Notes.txt").Split('\n');
                for (int i = 0; i < result.Length; i++)
                {
                    result[i] = result[i].Remove(result[i].Length - 2, 2);
                }
                return result.ToList();
            }
        }
        public class RamProxy : IProxy
        {
            private List<string> ramlist;
            public RamProxy()
            {
                ramlist = HelpClass.GetDatas();
            }


            public List<string> GetUrls(string text)
            {
                var List = new List<string>();
                foreach (var item in ramlist)
                {
                    if (List.Count <= 10)
                    {
                        if (item.StartsWith(text))
                        {
                            List.Add(item);
                        }
                    }
                    else
                    {
                        break;
                    }
                }
                return List;
            }

            public void SetUrls(string urls)
            {
                ramlist.Insert(0, urls);
            }
        }

        IProxy ramcache = new RamProxy();
            List<string> Datas = new List<string>();
            public MainWindow()
            {
                InitializeComponent();
            
            }
        
        private void textchanged(object sender, TextChangedEventArgs e)
        {
        
            string text = textbox.Text;
            if (text != string.Empty)
            {
                Datas= ramcache.GetUrls(text);
              
                listbox1.ItemsSource = null;
                listbox1.ItemsSource = Datas;
            
            }
            else
            {
                listbox1.ItemsSource = null;
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

            var data = textbox.Text;
            ramcache.SetUrls(data);

        }

    }
}


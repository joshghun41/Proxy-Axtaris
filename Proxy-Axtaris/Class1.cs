using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy_Axtaris
{
    public  interface IProxy
    {
        List<string> GetUrls(string text);
        void SetUrls(string urls);
    }

    public class HelpClass
    {
        public static List<string> GetDatas()
        {
            var result = File.ReadAllText(@"~/../../../txt/Notes.txt").Split('\n');
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
            ramlist=HelpClass.GetDatas();
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
}

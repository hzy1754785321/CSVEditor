using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CSV
{
    class Program
    {
        static void Main(string[] args)
        {
            LoadTable(@"C: \Users\ychi\source\repos\CSV\table");    
        }

        public  static void LoadTable(string path)
        {
            string fn = "";
            GameTables.Load(path);
            GameTables.ParseTable();
            //GameTables.CheckTable();
        }
    }
}

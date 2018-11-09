using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CSV
{
    public static partial class GameTables
    {
        public static void ParseTable()
        {
            foreach (var item in 宝可梦)
            {
                item.Parse();
            }
            var pm = GetPmById(1001);
            Console.WriteLine(JsonConvert.SerializeObject(pm));
            Console.ReadLine();
        }
    }

}

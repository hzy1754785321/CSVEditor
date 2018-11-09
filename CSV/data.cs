﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSV
{


    [Serializable()]
    public class Item
    {
        public int type;
        public int count;
        public Item() { }
        public Item(int type, int count)
        {
            this.type = type;
            this.count = count;
        }
        public static Item Parse(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return null;
            }
            string[] args = str.Split(';');
            return new Item() { type = int.Parse(args[0]), count = int.Parse(args[1]) };
        }
    }



    public static class Data
    {


        public static List<Item> ToItemList(this string str, char[] separator1, char[] separator2, string reson = "")
        {
            if (string.IsNullOrEmpty(str))
            {
                return null;
            }
            List<Item> ret = new List<Item>();
            var args = str.Split(separator2, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0, length = args.Length; i < length; i++)
            {
                var item = args[i].ToItem(separator1);
                ret.Add(item);
            }
            return ret;
        }

        public static Item ToItem(this string str, params char[] separator)
        {
            if (string.IsNullOrEmpty(str))
            {
                return new Item();
            }
            var args = str.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            int type = 0;
            int count = 0;
            if (args.Length < 2)
                return new Item();
            type = int.Parse(args[0]);
            count = int.Parse(args[1]);
            return new Item() { type = type, count = count };
        }

        public static List<int> ToIntList(this string str, params char[] separator)
        {
            List<int> ret = new List<int>();
  
            var args = str.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            int length = args.Length;
            if (length == 0)
            {
                return ret;
            }
            int value;
            for (int i = 0; i < length; i++)
            {
                if (!int.TryParse(args[i], out value))
                {
                    continue;
                }
                ret.Add(value);
            }
            return ret;
        }

        public static List<double> ToDoubleList(this string str, params char[] separator)
        {
            List<double> ret = new List<double>();
            if (string.IsNullOrEmpty(str))
            {
                return ret;
            }
            var args = str.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            int length = args.Length;
            if (length == 0)
            {
                return ret;
            }
            double value;
            for (int i = 0; i < length; i++)
            {
                if (!double.TryParse(args[i], out value))
                {
                    continue;
                }
                ret.Add(value);
            }
            return ret;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CSV
{
    partial class GameTables
    {
        /// <summary>
		/// ';',','
		/// </summary>
		public static char[] itemSeparator1 = new char[] { ';', ',' };
        /// <summary>
        /// |
        /// </summary>
        public static char[] itemSeparator2 = new char[] { '|' };

        public static table_宝可梦 GetPmById(int id)
        {
            return 宝可梦.FirstOrDefault(e => e.id == id);
        }
    }


    public class CSVReader
    {
        public static int head = 2;
        public static int start = 3;
        public static List<string[]> Load(string fn, string encoding = "GBK")
        {
            var content = File.ReadAllText(fn, Encoding.GetEncoding(encoding));
            var lines = new List<string[]>();
            ParseLines(lines, content);
            return lines;
        }

        public static List<T> LoadAsObjects<T>(string fn, string encoding = "GBK") where T : new()
        {
            var lines = Load(fn);
            var header = lines[head];
            var objects = new List<T>();
            for (int i = start; i < lines.Count; i++)
                objects.Add(new T());
            for (int i = 0; i < header.Length; i++)
            {
                if (string.IsNullOrEmpty(header[i]))
                {
                    continue;
                }
                var field = typeof(T).GetField(header[i]);
                if (field == null)
                {
                    Console.WriteLine("unknown column: '{0}'.", header[i]);
                    continue;
                }
                for (int j = start; j < lines.Count; j++)
                {
                    var str = lines[j][i];
                    if (field.FieldType == typeof(string))
                        field.SetValue(objects[j - start], str);
                    else
                    {
                        if (str == "")
                            continue;
                        if (field.FieldType.IsEnum)
                        {

                            field.SetValue(objects[j - start], Enum.Parse(field.FieldType, str));
                        }
                        else
                        {
                            try
                            {
                                var val = Convert.ChangeType(str, field.FieldType);
                                field.SetValue(objects[j - start], val);
                            }
                            catch (Exception e)
                            {
                                //Log.Error("{0}\n{1}", e.Message, e.StackTrace);
                                throw e;
                            }
                        }
                    }
                }
            }
            return objects;
        }

        public static List<T> LoadAsObjects<T>(List<string[]> lines) where T : new()
        {
            var count = lines.Count;
            var header = lines[head];
            var objects = new List<T>(count - start);
            for (int i = start; i < count; i++)
                objects.Add(new T());
            for (int i = 0; i < header.Length; i++)
            {
                if (string.IsNullOrEmpty(header[i]))
                {
                    continue;
                }
                var field = typeof(T).GetField(header[i]);
                if (field == null)
                {
                    Console.WriteLine("unknown column: '{0}'.", header[i]);
                    continue;
                }
                for (int j = start; j < lines.Count; j++)
                {
                    var str = lines[j][i];
                    if (field.FieldType == typeof(string))
                        field.SetValue(objects[j - start], str);
                    else
                    {
                        if (str == "")
                            continue;
                        if (field.FieldType.IsEnum)
                        {

                            field.SetValue(objects[j - start], Enum.Parse(field.FieldType, str));
                        }
                        else
                        {
                            try
                            {
                                var val = Convert.ChangeType(str, field.FieldType);
                                field.SetValue(objects[j - start], val);
                            }
                            catch (Exception e)
                            {
                                //Log.Error("{0}\n{1}", e.Message, e.StackTrace);
                                throw e;
                            }
                        }
                    }
                }
            }
            return objects;
        }

        private static void ParseLines(List<string[]> lines, string content)
        {
            content = content.Replace("\r\n", "\n");
            content = content.Replace("\r", "\n");
            List<string> ret = new List<string>();
            bool inQuote = false;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < content.Length; ++i)
            {
                var c = content[i];
                if (!inQuote)
                {
                    if (c == ',')
                    {
                        ret.Add(sb.ToString());
                        sb.Remove(0, sb.Length);
                    }
                    else if (c == '\n')
                    {
                        ret.Add(sb.ToString());
                        sb.Remove(0, sb.Length);
                        lines.Add(ret.ToArray());
                        ret.Clear();
                    }
                    else if (c == '"')
                        inQuote = true;
                    else
                        sb.Append(c);
                }
                else
                {
                    if (c == '"')
                    {
                        if (i < content.Length - 1 && content[i + 1] == '"')
                            sb.Append(c);
                        inQuote = false;
                    }
                    else
                        sb.Append(c);
                }
            }
        }

  
    }

    public partial class table_宝可梦
    {
        public List<Item> parsedSkill;
        public List<Item> parsedUpItem;
        public List<Item> parseStarUpCost;
        public Item parsedUpPrice;
        public List<int> parsedLearnSkill;

        public List<int> parsedUpElfSp;
        public List<int> parsedUpLvSp;
        public List<int> parsedUpLoveLvSp;
        public List<int> parsedStarPokemon;
        public Item[] parsedUpPriceSp;
        public List<Item>[] parsedUpItemSp;
        public List<double> parsedAbliUp;
        public Item parsedDebrisNeed;
        public List<Item> parsedSeerValue;
        public void Parse()
        {
            if (!string.IsNullOrEmpty(skill))
            {
                parsedSkill = skill.ToItemList(new char[] { ';' }, new char[] { '|' });
            }
            if (!string.IsNullOrEmpty(upItem))
            {
                parsedUpItem = upItem.ToItemList(new char[] { ';' }, new char[] { '|' });
            }
            if (!string.IsNullOrEmpty(starUpCost))
            {
                parseStarUpCost = starUpCost.ToItemList(new char[] { ';' }, new char[] { '|' });
            }
            if (!string.IsNullOrEmpty(upPrice))
            {
                parsedUpPrice = upPrice.ToItem(new char[] { ';' });
            }
            if (!string.IsNullOrEmpty(learnSkill))
            {
                parsedLearnSkill = learnSkill.ToIntList('|');
            }
            if (!string.IsNullOrEmpty(seerValueCost))
            {
                parsedSeerValue = seerValueCost.ToItemList(GameTables.itemSeparator1, GameTables.itemSeparator2);
            }
            if (!string.IsNullOrEmpty(upElfSp))
            {
                parsedUpElfSp = upElfSp.ToIntList(GameTables.itemSeparator2);

                int count = parsedUpElfSp.Count;
                if (!string.IsNullOrEmpty(upLvSp))
                    parsedUpLvSp = upLvSp.ToIntList(GameTables.itemSeparator2);
                if (parsedUpLvSp == null || parsedUpLvSp.Count != count)
                    return;

                if (!string.IsNullOrEmpty(upLoveLvSp))
                    parsedUpLoveLvSp = upLoveLvSp.ToIntList(GameTables.itemSeparator2);
                if (parsedUpLoveLvSp == null || parsedUpLoveLvSp.Count != count)
                    return;

                parsedUpPriceSp = new Item[count];
                if (!string.IsNullOrEmpty(upPriceSp))
                {
                    var args = upPriceSp.Split(GameTables.itemSeparator2);
                    for (int i = 0, length = args.Length; i < length; i++)
                    {
                        var arg = args[i];
                        if (!string.IsNullOrEmpty(arg))
                            parsedUpPriceSp[i] = arg.ToItem(GameTables.itemSeparator1);
                        else
                            return;
                    }
                }

                parsedUpItemSp = new List<Item>[count];
                if (!string.IsNullOrEmpty(upItemSp))
                {
                    var args = upItemSp.Split(':');
                    for (int i = 0, length = args.Length; i < length; i++)
                    {
                        var arg = args[i];
                        if (!string.IsNullOrEmpty(arg))
                            parsedUpItemSp[i] = arg.ToItemList(GameTables.itemSeparator1, GameTables.itemSeparator2);
                        else
                            return;
                    }
                }
            }
            if (!string.IsNullOrEmpty(starPokemon))
                parsedStarPokemon = starPokemon.ToIntList(GameTables.itemSeparator2);
            parsedAbliUp = abliUp.ToDoubleList(GameTables.itemSeparator1);
            if (parsedAbliUp.Count < starCan)
                return;
            if (!string.IsNullOrEmpty(debrisNeed))
                parsedDebrisNeed = debrisNeed.ToItem(GameTables.itemSeparator1);
        }
    }
}

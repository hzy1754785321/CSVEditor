using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft;
using System.IO;

namespace CSV
{
    public static partial class GameTables
    {
        static string confPath;
        public static Dictionary<string, Dictionary<string, string>> _langs;
        public static List<table_宝可梦> 宝可梦;


        public static void Load(string dataFolder)
        {
            confPath = dataFolder;
            string fn;
            fn = string.Format("{0}/TElf_宝可梦.csv", dataFolder);
            宝可梦 = CSVReader.LoadAsObjects<table_宝可梦>(fn);
        }

    }


    /// <summary>
    /// TElf_宝可梦
    /// </summary>
    public partial class table_宝可梦
	{
		/// <summary>
		/// 宝可梦ID
		/// </summary>
		public int id;
		/// <summary>
		/// 上阵ID
		/// </summary>
		public int battleId;
		/// <summary>
		/// 宝可梦名字
		/// </summary>
		public string name;
		/// <summary>
		/// 宝可梦描述
		/// </summary>
		public string drc;
		/// <summary>
		/// 特性ID
		/// </summary>
		public int ability;
		/// <summary>
		/// 升23456789星消耗道具（道具id；数量分隔）
		/// </summary>
		public string starUpCost;
		/// <summary>
		/// 努力值升阶道具需求（从1升2起，0升1不需要）
		/// </summary>
		public string seerValueCost;
		/// <summary>
		/// 技能(技能编号;技能学习等级|技能编号;技能学习等级)
		/// </summary>
		public string skill;
		/// <summary>
		/// 血量种族值
		/// </summary>
		public int hp;
		/// <summary>
		/// 物攻种族值
		/// </summary>
		public int atk;
		/// <summary>
		/// 物防种族值
		/// </summary>
		public int def;
		/// <summary>
		/// 特攻种族值
		/// </summary>
		public int atkSp;
		/// <summary>
		/// 特防种族值
		/// </summary>
		public int defSp;
		/// <summary>
		/// 速度种族值
		/// </summary>
		public int spe;
		/// <summary>
		/// 种族值总和
		/// </summary>
		public int all;
		/// <summary>
		/// 属性ID（1.火 2.水 3.草 4.妖 5.恶 6.龙 7.冰 8.鬼 9.普通 10.电 11.虫 12.飞行 13.地面 14.岩石 15.格斗 16.超能 17.钢 18.毒）
		/// </summary>
		public int attribute;
		/// <summary>
		/// 副属性（1.火 2.水 3.草 4.妖 5.恶 6.龙 7.冰 8.鬼 9.普通 10.电 11.虫 12.飞行 13.地面 14.岩石 15.格斗 16.超能 17.钢 18.毒）
		/// </summary>
		public int attribute2;
		/// <summary>
		/// 品级
		/// </summary>
		public int quality;
		/// <summary>
		/// 稀有星数
		/// </summary>
		public int rarityStar;
		/// <summary>
		///  稀有度（最低1，最高100）
		/// </summary>
		public int rarity;
		/// <summary>
		/// 进化所需等级
		/// </summary>
		public int upLv;
		/// <summary>
		/// 进化所需亲密度等级
		/// </summary>
		public int upLoveLv;
		/// <summary>
		/// 进化所需道具
		/// </summary>
		public string upItem;
		/// <summary>
		/// 进化前的宝可梦ID
		/// </summary>
		public int downElf;
		/// <summary>
		/// 不可进化（0否，1是，默认0）
		/// </summary>
		public int sotpGrow;
		/// <summary>
		/// 进化后的宝可梦ID
		/// </summary>
		public int upElf;
		/// <summary>
		/// 进化所需货币
		/// </summary>
		public string upPrice;
		/// <summary>
		/// 特殊进化所需等级(|分隔）
		/// </summary>
		public string upLvSp;
		/// <summary>
		/// 特殊进化所需亲密度等级(|分隔）
		/// </summary>
		public string upLoveLvSp;
		/// <summary>
		/// 特殊进化所需道具(道具id;道具数量|第二个道具id;道具数量:另一个宝可梦进化所需…   ';'分隔id和数量'|'分隔不同的道具':'分隔不同的宝可梦需求）
		/// </summary>
		public string upItemSp;
		/// <summary>
		/// 特殊进化后的宝可梦ID(|分隔）
		/// </summary>
		public string upElfSp;
		/// <summary>
		/// 特殊进化所需货币(；分隔道具id和数量 |分隔不同的宝可梦需求）
		/// </summary>
		public string upPriceSp;
		/// <summary>
		/// 升星可用宝可梦
		/// </summary>
		public string starPokemon;
		/// <summary>
		/// 可学习的天赋树
		/// </summary>
		public int talentGroupId;
		/// <summary>
		/// 可学习的技能机器id(系ID|系ID)
		/// </summary>
		public string learnSkill;
		/// <summary>
		/// 可升最高星数(最高到达星数）
		/// </summary>
		public int starCan;
		/// <summary>
		/// 可超进阶的用1
		/// </summary>
		public int advance;
		/// <summary>
		/// 宝可萌声音
		/// </summary>
		public string voice;
		/// <summary>
		/// 孵化时间（单位：分钟）
		/// </summary>
		public int hatch;
		/// <summary>
		/// 碎片需求数量
		/// </summary>
		public string debrisNeed;
		/// <summary>
		/// 合成消耗金币
		/// </summary>
		public int CostMoney;
		/// <summary>
		/// 宝可萌星级加成
		/// </summary>
		public string abliUp;
		/// <summary>
		/// 图鉴显示(0不显示，1显示，默认0)
		/// </summary>
		public int showBook;
		/// <summary>
		/// 默认精灵球
		/// </summary>
		public int ballID;
		/// <summary>
		/// 额外测试
		/// </summary>
		public string ext;
	}

 
}
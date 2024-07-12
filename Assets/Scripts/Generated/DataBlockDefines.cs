using System;
using System.Collections.Generic;
using System.Linq;
using CSExcelReader.Core;
using ClientServerLib;
namespace CSExcelReader.Generate {
    public class Commom_Structs_PlayerItem_DBBase : DataBlockGen<Commom.Structs.PlayerItem>
    {
        protected static Dictionary<string, Func<string, object>> fieldStringParser = new Dictionary<string, Func<string, object>>();
        protected override void BuildMapAndGroup()
        {
        }
        static void AddGeters()
        {
        }
        static Commom_Structs_PlayerItem_DBBase() 
        {
            AddFieldTextParser<Commom.Structs.PlayerItem>(fieldStringParser); 
            AddGeters();
        }
    }

   public class Game_Test_GameLevel_DBBase : DataBlockGen<Game.Test.GameLevel>
   {
      protected static Dictionary<string, Func<string, object>> fieldStringParser = new Dictionary<string, Func<string, object>>();
      protected Dictionary<int, Game.Test.GameLevel> inner_ID_index = null;
      protected Dictionary<int, Game.Test.GameLevel> inner_Level_index = null;
      protected Dictionary<string, Game.Test.GameLevel[]> inner_Name_group = null;
      protected override void BuildMapAndGroup()
      {
               inner_ID_index = BuildMap<int>("ID");
               inner_Level_index = BuildMap<int>("Level");
               inner_Name_group = BuildGroup<string>("Name");
      }
      static void AddGeters()
      {
          keysGeters.Add("ID", Keys_ID_Geter);
          keysGeters.Add("Level", Keys_Level_Geter);
          rangesGeters.Add("Level", Ranges_Level_Geter);
          keysGroupGeters.Add("Name", KeysGroup_Name_Geter);
      }
        static Game.Test.GameLevel[] Keys_ID_Geter(DataBlock block,string[] keys) 
        {
            var parpser = fieldStringParser["ID"];
            var bi = (Game_Test_GameLevel_DBBase)block;
            return keys.Select(n => (int)Convert.ChangeType(parpser(n), typeof(int))).Select(n => bi.inner_ID_index[n]).ToArray();
        }
        static Game.Test.GameLevel[] Keys_Level_Geter(DataBlock block,string[] keys) 
        {
            var parpser = fieldStringParser["Level"];
            var bi = (Game_Test_GameLevel_DBBase)block;
            return keys.Select(n => (int)Convert.ChangeType(parpser(n), typeof(int))).Select(n => bi.inner_Level_index[n]).ToArray();
        }
        static Game.Test.GameLevel[] Ranges_Level_Geter(DataBlock block,STuple<int, int>[] ranges)
        {
            var bi = (Game_Test_GameLevel_DBBase)block;
            return bi.datas.Where(n => 
            {
                var value = n.GetValue<int>("Level");
                return ranges.Any(r => r.A <= value && r.B >= value);
            }).ToArray();
        }
        static Game.Test.GameLevel[] KeysGroup_Name_Geter(DataBlock block,string[] keys)
        {
            var parpser = fieldStringParser["Name"];
            var bi = (Game_Test_GameLevel_DBBase)block;
            return keys.Select(n => (string)Convert.ChangeType(parpser(n), typeof(string))).Select(n => bi.inner_Name_group[n]).Combine().ToArray();
        }
        static Game_Test_GameLevel_DBBase() 
        {
            AddFieldTextParser<Game.Test.GameLevel>(fieldStringParser); 
            AddGeters();
        }
   }

    public class Player_Test_PlayerInfos_DS_DBBase : DataBlockGen<Player.Test.PlayerInfos_DS>
    {
        protected static Dictionary<string, Func<string, object>> fieldStringParser = new Dictionary<string, Func<string, object>>();
        protected override void BuildMapAndGroup()
        {
        }
        static void AddGeters()
        {
        }
        static Player_Test_PlayerInfos_DS_DBBase() 
        {
            AddFieldTextParser<Player.Test.PlayerInfos_DS>(fieldStringParser); 
            AddGeters();
        }
    }

}
namespace Player.Test {
   public class PlayerItems : CSExcelReader.Generate.Commom_Structs_PlayerItem_DBBase {
         private static PlayerItems instance = null;
        public static PlayerItems I 
        {
            get
            {
                if (instance != null) return instance;
                instance = DataBlockManager.I.GetBlock<PlayerItems>(typeof(PlayerItems).FullName);
                return instance;
            }
        }
         public static Commom.Structs.PlayerItem[] R => I.datas;
        protected override void ReadFinishInit()
        {
            base.ReadFinishInit();
            instance = this;
        }
        public override void UnLoad()
        {
            base.UnLoad();
            instance = null;
        }
   }
   public class PlayerInfos : CSExcelReader.Generate.Player_Test_PlayerInfos_DS_DBBase {
         private static PlayerInfos instance = null;
        public static PlayerInfos I 
        {
            get
            {
                if (instance != null) return instance;
                instance = DataBlockManager.I.GetBlock<PlayerInfos>(typeof(PlayerInfos).FullName);
                return instance;
            }
        }
         public static Player.Test.PlayerInfos_DS V => I.datas[0];
        protected override void ReadFinishInit()
        {
            base.ReadFinishInit();
            instance = this;
        }
        public override void UnLoad()
        {
            base.UnLoad();
            instance = null;
        }
   }
}
namespace Game.Test {
   public class Gamelevels : CSExcelReader.Generate.Game_Test_GameLevel_DBBase {
         private static Gamelevels instance = null;
        public static Gamelevels I 
        {
            get
            {
                if (instance != null) return instance;
                instance = DataBlockManager.I.GetBlock<Gamelevels>(typeof(Gamelevels).FullName);
                return instance;
            }
        }
         public static Game.Test.GameLevel[] R => I.datas;
         public static Dictionary<int, Game.Test.GameLevel> IDMap => I.inner_ID_index;
         public static Dictionary<int, Game.Test.GameLevel> LevelMap => I.inner_Level_index;
         public static Dictionary<string, Game.Test.GameLevel[]> NameGroup => I.inner_Name_group;
        protected override void ReadFinishInit()
        {
            base.ReadFinishInit();
            instance = this;
        }
        public override void UnLoad()
        {
            base.UnLoad();
            instance = null;
        }
   }
}

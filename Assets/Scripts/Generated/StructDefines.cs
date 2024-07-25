using System;
using CSExcelReader.Core;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;
namespace Game.Test {
    public class GameLevel : CSExcelStructBase
   {
      static Dictionary<string,object> valueGeters = new Dictionary<string,object>();
       public int ID;
       public int Level;
       public string Name;
       public long Cost;
       [JsonConverter(typeof(StringEnumConverter))]
       public Game.Test.SahpeTypes Shape;
         public override T GetValue<T>(string name)
        {
            if (valueGeters.TryGetValue(name, out object geter)) 
            {
                if (geter is Func<GameLevel,T> get) return get(this);
            }
            return default(T);
        }
       static GameLevel() 
       {
         valueGeters.Add("ID", (Func<GameLevel,int>)((a) => a.ID));
         valueGeters.Add("Level", (Func<GameLevel,int>)((a) => a.Level));
         valueGeters.Add("Name", (Func<GameLevel,string>)((a) => a.Name));
         valueGeters.Add("Cost", (Func<GameLevel,long>)((a) => a.Cost));
         valueGeters.Add("Shape", (Func<GameLevel,Game.Test.SahpeTypes>)((a) => a.Shape));
      }
   }
}
namespace Commom.Structs {
    public class ToolItem : CSExcelStructBase
   {
      static Dictionary<string,object> valueGeters = new Dictionary<string,object>();
       public int Id;
       public string Name;
       public float Prob;
         public override T GetValue<T>(string name)
        {
            if (valueGeters.TryGetValue(name, out object geter)) 
            {
                if (geter is Func<ToolItem,T> get) return get(this);
            }
            return default(T);
        }
       static ToolItem() 
       {
         valueGeters.Add("Id", (Func<ToolItem,int>)((a) => a.Id));
         valueGeters.Add("Name", (Func<ToolItem,string>)((a) => a.Name));
         valueGeters.Add("Prob", (Func<ToolItem,float>)((a) => a.Prob));
      }
   }
    public class PlayerItem : CSExcelStructBase
   {
      static Dictionary<string,object> valueGeters = new Dictionary<string,object>();
       public int Level;
       public int Id;
       public string Name;
       public int Count;
         public override T GetValue<T>(string name)
        {
            if (valueGeters.TryGetValue(name, out object geter)) 
            {
                if (geter is Func<PlayerItem,T> get) return get(this);
            }
            return default(T);
        }
       static PlayerItem() 
       {
         valueGeters.Add("Level", (Func<PlayerItem,int>)((a) => a.Level));
         valueGeters.Add("Id", (Func<PlayerItem,int>)((a) => a.Id));
         valueGeters.Add("Name", (Func<PlayerItem,string>)((a) => a.Name));
         valueGeters.Add("Count", (Func<PlayerItem,int>)((a) => a.Count));
      }
   }
}
namespace Player.Test {
    public class PlayerInfos_DS : CSExcelStructBase
   {
      static Dictionary<string,object> valueGeters = new Dictionary<string,object>();
       public long Coins;
       public long Diamons;
       public int Level;
       public Game.Test.GameLevel[] GameLevel;
       public Commom.Structs.ToolItem[] ToolItems;
       public Commom.Structs.PlayerItem PlayerItem;
       public int[][] Bonus;
         public override T GetValue<T>(string name)
        {
            if (valueGeters.TryGetValue(name, out object geter)) 
            {
                if (geter is Func<PlayerInfos_DS,T> get) return get(this);
            }
            return default(T);
        }
       static PlayerInfos_DS() 
       {
         valueGeters.Add("Coins", (Func<PlayerInfos_DS,long>)((a) => a.Coins));
         valueGeters.Add("Diamons", (Func<PlayerInfos_DS,long>)((a) => a.Diamons));
         valueGeters.Add("Level", (Func<PlayerInfos_DS,int>)((a) => a.Level));
         valueGeters.Add("GameLevel", (Func<PlayerInfos_DS,Game.Test.GameLevel[]>)((a) => a.GameLevel));
         valueGeters.Add("ToolItems", (Func<PlayerInfos_DS,Commom.Structs.ToolItem[]>)((a) => a.ToolItems));
         valueGeters.Add("PlayerItem", (Func<PlayerInfos_DS,Commom.Structs.PlayerItem>)((a) => a.PlayerItem));
         valueGeters.Add("Bonus", (Func<PlayerInfos_DS,int[][]>)((a) => a.Bonus));
      }
   }
}

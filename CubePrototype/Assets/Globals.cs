using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Globals 
{
   public static int TERRAIN_LAYER_MASK = 1 << 6;
   public static BuildingData[] BUILDING_DATA = new BuildingData[]
   {
     //new BuildingData("Building", 100)
     new BuildingData("House", 100, new Dictionary<string, int>()
        {
            { "gold", 100 },
            { "wood", 120 }
        }),
        new BuildingData("Tower", 100, new Dictionary<string, int>()
        {
            { "gold", 80 },
            { "wood", 80 },
            { "stone", 100 }
        })
   };
   public static Dictionary<string, GameResources> GAME_RESOURCES = new Dictionary <string, GameResources>()
   {
    {"gold", new GameResources("Gold", 0)},
    {"wood", new GameResources("Wood", 0)},
    {"stone", new GameResources("Stone", 0)}
   };

   
        
    
}

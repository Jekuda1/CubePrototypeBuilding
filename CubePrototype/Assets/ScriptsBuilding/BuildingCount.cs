using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum BuildingType
{
    GeneratorA,
    GeneratorB,
    House,
    ScoreGenerator1,
    ScoreGenerator2,

    Converter,

    GeneratorC


}

public class BuildingCount : MonoBehaviour
{
    public BuildingType type;
    public BuildingManager buildingManager;

    public GameObject nameCheck;

    public float numberOfBuildings = 0f;
   public float GeneratorAnumber = 0f;
   public float GeneratorBnumber = 0f;

   public float GeneratorCnumber = 0f;
   public float House = 0f;

   public void Update()
   {
   /* if(buildingManager.Placed == false)
      {
        //type = buildingManager.pendingObject.name;
        // get the name of the pending object inorder to know where to add 1
      }*/

       if(buildingManager.Placed == true)
       {
        //add that data to the count, set the count null
         numberOfBuildings += 1f;
         buildingManager.Placed = false;
       }
   }

  
}

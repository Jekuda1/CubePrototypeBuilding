using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorOne : MonoBehaviour
{
  // this script had a lots going on, now is just a scriptableObject holder
   public int GenerationSpeed = 1/100;

   public BuildingObjectSO myObject;
   public int WorkingForce = 0;
   public int maxWorkingForce = 3;

   public DisplayBuilding db;

   public bool ImBuilded = false;

   public int OneAmount;

   public int TwoAmount;

   public void Start()
   {
     //if(ImBuilded == true)
//     db = GameObject.Find("DisplayBuilding").GetComponent<DisplayBuilding>();
    // db.selectedObject = this.gameObject;
    //  StartCoroutine(resourcesGen());
   }
   public void Update()
   {
    /*if(db.isBuilding == true)
    {
      StartCoroutine(resourcesGen());
    }*/
      
   }
   public void IncreaseAmount()
   {
      //OneAmount += 1;
      //return;
   }
  /*  public IEnumerator resourcesGen()
   {
     yield return new WaitForSeconds(5);
     db.myAmount1 += 10;
     StartCoroutine(resourcesGen());
   }*/
  

}

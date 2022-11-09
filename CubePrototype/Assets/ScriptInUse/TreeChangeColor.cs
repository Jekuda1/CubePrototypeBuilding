using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeChangeColor : MonoBehaviour
{
    public DisplayBuilding db;

    public GameObject myTree;
    public Material myMaterialgood;
    //public Material myMaterialgoodSecond;
    //public Material myMaterialBad;

    // Start is called before the first frame update
    void Start()
    {
      myMaterialgood.SetColor("_Color", Color.green);
      //myMaterialgoodSecond.SetColor("_Color", Color.green);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(db.wasteAmount < 50)
        {
          myMaterialgood.SetColor("_Color", Color.green);
         // myMaterialgoodSecond.SetColor("_Color", Color.green);
        }
        if(db.wasteAmount >= 50)
        {
          myMaterialgood.SetColor("_Color", Color.yellow);
        //  myMaterialgoodSecond.SetColor("_Color", Color.green);
        }
        if(db.wasteAmount >= 100)
        {
          myMaterialgood.SetColor("_Color", Color.red);
         // myMaterialgoodSecond.SetColor("_Color", Color.yellow);
        }
        if(db.wasteAmount >= 150)
        {
         // myMaterialgoodSecond.SetColor("_Color", Color.red);
          myMaterialgood.SetColor("_Color", Color.black);
        }
        if(db.wasteAmount >= 200)
        {
          Destroy(gameObject);
         // myMaterialgoodSecond.SetColor("_Color", Color.black);
        }
    }
}

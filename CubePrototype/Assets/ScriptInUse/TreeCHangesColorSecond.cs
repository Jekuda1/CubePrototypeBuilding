using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeCHangesColorSecond : MonoBehaviour
{
    public DisplayBuilding db;

    public Material mySecondMaterial;

    public GameObject mySecondTree;
    // Start is called before the first frame update
    void Start()
    {
        mySecondMaterial.SetColor("_Color", Color.green);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(db.wasteAmount >= 100)
        {
            mySecondMaterial.SetColor("_Color", Color.yellow);
        }
        if(db.wasteAmount >= 200)
        {
            mySecondMaterial.SetColor("_Color", Color.red);
        }
        if(db.wasteAmount >= 300)
        {
            mySecondMaterial.SetColor("_Color", Color.black);
        }
        if(db.wasteAmount >= 350)
        Destroy(gameObject);

        
    }
}

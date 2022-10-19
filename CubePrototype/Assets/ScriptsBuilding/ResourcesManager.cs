using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResourcesManager : MonoBehaviour
{
    /*public float Aresource = 0f;
    public float Bresource = 0f;
    public float Cresource = 0f;
    public float Dresource = 0f;*/
    public int currentAResources = 100;
    //public int currentBResources = 50;
    private BuildingCost buildingToPlace;

     public TextMeshProUGUI AUI;
    public TextMeshProUGUI BUI;
     public TextMeshProUGUI CUI;
    public TextMeshProUGUI DUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        AUI.text = "A" + currentAResources.ToString();
      //  BUI.text = "B" + currentBResources.ToString();
    }

    public void BuyBuilding(BuildingCost buildingcost)
    {
        if(currentAResources >= buildingcost.cost)
        {
            currentAResources -= buildingcost.cost;
            //buildingToPlace = building
        }
    }
}

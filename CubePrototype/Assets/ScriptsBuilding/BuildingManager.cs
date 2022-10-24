using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingManager : MonoBehaviour
{
    public GameObject[] objects;
    public GameObject pendingObject;
    public Material[] materials;
    public BuildingCost[] costs;

    private Vector3 pos;
    private RaycastHit hit;

    public LayerMask layermask;
    public float gridSize;
    public float rotateAmount;
    bool gridOn;
    public Toggle gridToogle;
    public bool canPlace = true;
   // private int pendingObjectCost;
    public BuildingCost price;
    public ResourcesManager Aprice;
   // int spawnID = 0;
    // Start is called before the first frame update
    void Start()
    {
     
    }
    private void FixedUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out hit, 1000, layermask));
        {
            pos = hit.point;
        }
    }
    public void SelectObject(int index)
    {
       // int cost;
      // if(objects.index == 1)
      
        pendingObject = Instantiate(objects[index], pos, transform.rotation);
       // pendingObject = GetComponent<BuildingCost>().cost;
       // objects[index].GetComponent<BuildingCost>().cost;
        //pendingObject.cost = costs[index];
       // ResourcesManager.currentAResources -= price.cost; objects[index].GetComponent<BuildingCost>().cost;
         
      
    }

    public void PlaceObject()
    {
        
       // Aprice.currentAResources -= pendingObject.buildingcost.cost;
       
        pendingObject = null;
        
      //  Aprice.currentAResources -= price.cost;
    }
    public void RotateObject()
    {
        pendingObject.transform.Rotate(Vector3.up, rotateAmount);
    }

    // Update is called once per frame
    void Update()
    {
        if(pendingObject != null)
        {
            if(gridOn)
            {
                pendingObject.transform.position = new Vector3(
                    RoundToNearestGrid(pos.x),
                    RoundToNearestGrid(pos.y),
                    RoundToNearestGrid(pos.z)
                );
            }
            else
            {
                {
                    pendingObject.transform.position = pos;
                }
            }
           
            if(Input.GetMouseButtonDown(0) && canPlace)
            {
              //  int BuildingCost = objects[spawnID].GetComponent<BuildingCost>().cost;
                PlaceObject();
               //  Aprice.currentAResources -= BuildingCost;
                
            }
            if(Input.GetKeyDown(KeyCode.R))
            {
                RotateObject();
            }
            UpdateMaterials();
        }
        
    }
    public void UpdateMaterials()
    {
        if(canPlace)
        {
           // pendingObject.GetComponent<MeshRenderer>().material = materials[0];
        }
        else
        {
          // pendingObject.GetComponent<MeshRenderer>().material = materials[1]; 
        }
    }
    public void ToggleGrid()
    {
      if(gridToogle.isOn)
      {
        gridOn = true;
      }
      else
      {
        gridOn = false;
      }
    }
    float RoundToNearestGrid(float pos)
    {
        float xDiff = pos % gridSize;
        pos -= xDiff;
        if(xDiff > (gridSize / 2))
        {
            pos += gridSize;
        }
        return pos;

    }
   /* int BuildingCost()
    {
        switch(spawnID)
        {
             case 0: return objects[0].GetComponent<BuildingCost>().cost;
             case 1: return objects[1].GetComponent<BuildingCost>().cost;
             case 2: return objects[2].GetComponent<BuildingCost>().cost;
             case 3: return objects[3].GetComponent<BuildingCost>().cost;
             case 4: return objects[4].GetComponent<BuildingCost>().cost;
             case 5: return objects[5].GetComponent<BuildingCost>().cost;
             case 6: return objects[6].GetComponent<BuildingCost>().cost;
             case 7: return objects[7].GetComponent<BuildingCost>().cost;
             default:return -1;

        }
    }*/
}

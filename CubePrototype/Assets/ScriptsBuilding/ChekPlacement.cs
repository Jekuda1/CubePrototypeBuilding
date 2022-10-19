using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChekPlacement : MonoBehaviour
{
    BuildingManager buildingManager;
    //public int cost = 10;
    // Start is called before the first frame update
    void Start()
    {
        buildingManager = GameObject.Find("BuildingManager").GetComponent<BuildingManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
      if(other.gameObject.CompareTag("Object"))
      {
        buildingManager.canPlace = false;
      }
      if(other.gameObject.CompareTag("GeneratorA"))
      {
        buildingManager.canPlace = false;
      }
      if(other.gameObject.CompareTag("GeneratorB"))
      {
        buildingManager.canPlace = false;
      }

    }
    private void OnTriggerExit(Collider other)
    {
      if(other.gameObject.CompareTag("Object"))
      {
        buildingManager.canPlace = true;
      }
       if(other.gameObject.CompareTag("GeneratorA"))
      {
        buildingManager.canPlace = true;
      }
       if(other.gameObject.CompareTag("GeneratorB"))
      {
        buildingManager.canPlace = true;
      }
    }
}

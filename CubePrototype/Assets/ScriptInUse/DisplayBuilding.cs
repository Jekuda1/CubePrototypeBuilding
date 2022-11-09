using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DisplayBuilding : MonoBehaviour
{
    public BuildingObjectSO[] building;
    public GameObject selectedObject;

    public GeneratorOne one;

    public bool isA; public bool isB; public bool isC; public bool isD;

    public int currentCost;
     public int currentCost2;
    
    public int WorkerMax;

    public int currentWorkerAmount;

    public bool isBuilding;

    public bool isChoice;
    private Vector3 posi;
    private RaycastHit hit;
    public LayerMask layermask;

    public TextMeshProUGUI resourcetext;
    public TextMeshProUGUI resourcetext2;
    public TextMeshProUGUI wastetext;
    public TextMeshProUGUI workertext;

    public int myAmount1;

    public int myAmount2;

    public int wasteAmount;

    public float Abuilding; //public float AbuildingAdd = 1f; 

    public float Bbuilding; public float Cbuilding; public float Dbuilding;

   // public GeneratorOne one;
    // Start is called before the first frame update
    void Start()
    {
      
       
    }
    private void FixedUpdate()
    {
      // here Im launching a Ray in order to get the position of the mouse. this will be handy later when its
      // time to move the building in the world space
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 1000, layermask)) ;
        {
            posi = hit.point;
        }
        // also, as we are in the FixedUpdate is here that the resources amount UI is Updated
         resourcetext.text = myAmount1.ToString();
         resourcetext2.text = myAmount2.ToString(); 
         wastetext.text = wasteAmount.ToString();
         workertext.text = currentWorkerAmount.ToString();
    }
    // this has been the trikiest of the function in this script. Instantiate a prefab based on the list created 
    // at the beginning of this script, is called from the button in the UI canvas.
    public void ChooseObject(int index)
    {
        if (currentCost <= myAmount1 && currentCost2 <= myAmount2)
        {
            selectedObject = Instantiate(building[index].buildingBody, posi, transform.rotation);
            currentCost = building[index].Cost;
             currentCost2 = building[index].Cost2;
            isChoice = building[index].isChoosen = true;
            selectedObject.name = building[index].buildingname;
            isBuilding = false;

            myAmount1 -= currentCost;
            myAmount2 -= currentCost2;
            
            

        }


    }
    public void Update()
    {
      // in the update many things happen here im setting back to 0 the costs
        if(selectedObject == null)
        {
          currentCost = 0;
          currentCost2 = 0;
        }
       // here is where the instantiated object gets able to move into worldspace
        if (selectedObject != null)
        {
            selectedObject.transform.position = posi;
            
        }
        // here there are a serie of different boolean calculation in order to keep count of the buildings
        // each placed building will then start the appropiate Coroutine of the generation
        // they however share the "waste" Coroutine that is called from each building
        // they are mostly based on Tags aka name of the placed building
        if (Input.GetMouseButtonDown(0) && selectedObject != null)
        {
             if(selectedObject.CompareTag("GeneratorA"))
       {
         isA = true;
         Abuilding += 1f ;
          LetsWork();
          produceWaste();
         
       }
          if(selectedObject.CompareTag("GeneratorB"))
          {
            isB = true;
            Bbuilding += 1f;
            LetsWork2();
            produceWaste();

          }
           if(selectedObject.CompareTag("GeneratorC"))
           {
             Cbuilding += 1;
             isC = true;
             reduceWaste();
           }
           if(selectedObject.CompareTag("BuildingD"))
           {
            Dbuilding += 1;
            isD = true;
            IncreaseWorker();
            produceWaste();
           }
            PositionateObject();
           
            isBuilding = true;
            isChoice = false;
           
            

        }
        // here is the deselction "function", the player can press right click to return the action
        // for example aBuilding is selected for mistake, because we want bBUilding to be placed
        if (Input.GetMouseButtonDown(1) && selectedObject != null)
        {
            Destroy(selectedObject);
            selectedObject = null;
             myAmount1 += currentCost;
            myAmount2 += currentCost2;
        }
      
    }
    // here is where the object is finally placed, so that no selected object will be active after that
    // I dont really remember if one.ImBuilded has any use in general, samesame for the GeneratorOne script
    public void PositionateObject()
    {
        selectedObject = null;
        one.ImBuilded = true;
        
        

    }
    //here is a basic worker counter, even tough I think we are not really boing to use it as there are no 
    // worker involved in the game. this counter can be however used for some other mechanic
    public void IncreaseWorker()
    {
      if(Dbuilding > 0)
      {
        currentWorkerAmount += 1;
      }
    }
    // here there are a bunch of methods that are responsable to run the Coroutines, each resources and 
    // building has theyr own metod name
    public void LetsWork()
    {
        if(Abuilding > 0)
        {
          StartCoroutine(resourcesGen()) ;
        }
       
    }
    public void LetsWork2()
    {
         if(Bbuilding > 0)
        {
            StartCoroutine(resourcesGenDue());
        }
    }
    public void produceWaste()
    {
        StartCoroutine(wasteGeneration());
    }
    public void reduceWaste()
    {
        StartCoroutine(reducewasteGeneration());
    }
    // And now ladies and gentlments, a bunch of IEnumerator where the magic happen, here resources are created
    // each amount of second, and then the coroutine repeat itself
   
     public IEnumerator resourcesGen()
   {
     yield return new WaitForSeconds(5);
     myAmount1 += 5;
     StartCoroutine(resourcesGen());
   }
    public IEnumerator resourcesGenDue()
   {
     yield return new WaitForSeconds(5);
     myAmount2 += 5;
     StartCoroutine(resourcesGenDue());
   }
   public IEnumerator wasteGeneration()
   {
     yield return new WaitForSeconds(5);
     wasteAmount += 1;
     StartCoroutine(wasteGeneration());
   }
    public IEnumerator reducewasteGeneration()
   {
     yield return new WaitForSeconds(10);
     wasteAmount -= 7;
     StartCoroutine(reducewasteGeneration());
   }



}

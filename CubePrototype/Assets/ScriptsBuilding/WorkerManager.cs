using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class WorkerManager : MonoBehaviour
{
   public DisplayBuilding db;

   //public Transform[] houses;

   public GameObject selectedHouse;

   public GameObject infoPanel;

   public TextMeshProUGUI numberofWorker;

   public int WorkerInHouse;
    // Start is called before the first frame update
    void Start()
    {
      WorkerInHouse = 0; 
      int worker = GetComponent<DisplayBuilding>().WorkerMax;
      infoPanel.SetActive(false);
      
    }

    // Update is called once per frame
    void Update()
    {
        
     
        
        
    }
    public void AddWorker()
    {
        WorkerInHouse +=1;
         numberofWorker.text = WorkerInHouse.ToString(); 

    }
    public void RemoveWorker()
    {
        
          WorkerInHouse -=1;
           numberofWorker.text = WorkerInHouse.ToString(); 
        

    }
    public void OnMouseDown()
    {
        if(gameObject.CompareTag("BuildingD") && selectedHouse == null)
        {
            selectedHouse = gameObject;
            infoPanel.SetActive(true);
        }
       
        

    }
    public void CloseInfoPanel()
    {
        selectedHouse = null;
        infoPanel.SetActive(false);
    }
  
}

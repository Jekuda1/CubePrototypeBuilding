using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResourceA : MonoBehaviour
{
    public float maxAmount;
    public float currentAmount;
    private float wasteAmount = 0f;
    public bool Builded = false;
    public bool BuildedB = false;
    public TextMeshProUGUI AUI;
    public TextMeshProUGUI BUI;
    public TextMeshProUGUI AUIWaste;
    public float extractingSpeed;
    public float actualWaste;
    public float wasteSpeed;
    public float WorkerAmount = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
      currentAmount = maxAmount; 
      actualWaste = wasteAmount; 
    }

    // Update is called once per frame
    void Update()
    {
        if(Builded)
        {
            currentAmount += extractingSpeed * Time.deltaTime/3 * WorkerAmount;
            actualWaste += wasteSpeed * Time.deltaTime/5 * WorkerAmount;
            AUIWaste.text = ""+ actualWaste;
            AUI.text = ""+ currentAmount;


        }
        if(BuildedB)
        {
          currentAmount += extractingSpeed * Time.deltaTime/3;
            actualWaste += wasteSpeed * Time.deltaTime/5;
            BUI.text = ""+ currentAmount;  
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            AddWorker();
        }
        
       // coinText.text ="" + numberOfCoins;
    }
    void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("GeneratorA"))
        {
            Builded = true;
        }
        if(other.CompareTag("GeneratorB"))
        {
            BuildedB = true;
        }
    }
    void AddWorker()
    {
        WorkerAmount += 1f;
    }
    
}

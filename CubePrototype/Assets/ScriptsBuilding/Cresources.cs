using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Cresources : MonoBehaviour
{
    ResourcesManager rm;
    public float currentAmountC;
    public float extractingSpeed;
    public TextMeshProUGUI CUI;
    public TextMeshProUGUI AUIWaste;
    public bool isBuildedC = false;
    public float actualWaste;
    public float wasteSpeed;
    // Start is called before the first frame update
    void Start()
    {
      //  rm = GameObject.Find("ResourcesManager").GetComponent<ResourcesManager>();
        currentAmountC = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(isBuildedC)
        {
           currentAmountC += extractingSpeed * Time.deltaTime / 5;
            actualWaste += wasteSpeed * Time.deltaTime/2;
             CUI.text = ""+ currentAmountC;
             AUIWaste.text = ""+ actualWaste;
             //rm.Cresource += extractingSpeed * Time.deltaTime / 5;
            // rm.CUI.text = ""+ rm.Cresource;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("GeneratorC"))
        {
            isBuildedC = true;
        }
    }
}

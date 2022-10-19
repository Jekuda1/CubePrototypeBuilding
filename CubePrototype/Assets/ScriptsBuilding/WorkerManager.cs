using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WorkerManager : MonoBehaviour
{
    public float currentWorker = 0f;
    public TextMeshProUGUI WUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Ground"))
        {
            currentWorker += 1f;
            WUI.text = ""+ currentWorker;
        }
    }
}

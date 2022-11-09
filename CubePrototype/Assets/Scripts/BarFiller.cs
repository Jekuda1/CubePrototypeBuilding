using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BarFiller : MonoBehaviour
{
    public Image WasteBar;
    public float maxTime;
    public float currentTime;
    private int timeflow = 1;

    // Start is called before the first frame update
    void Start()
    {
       maxTime = currentTime; 
    }

    // Update is called once per frame
    void Update()
    {
        WasteBar.fillAmount = currentTime / maxTime; 
        maxTime += timeflow * Time.deltaTime;

        
    }
}

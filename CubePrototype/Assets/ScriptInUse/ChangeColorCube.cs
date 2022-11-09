using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorCube : MonoBehaviour
{
    // this is the script responsable to set the color of the cubes according to theyr position
    // it also set if they are in second or third zone, making easy to chek what can be placed and what no

    public float myActualLevel;
    public float maxLevel;
    public MovingBlocks mb;

    public Material[] myMaterial;

    public bool isInSecondZone = false;
    public bool isInTirdZone = false;
    

    public Color startColor;
    public Color  firstZoneColor; 

    public Color  secondZoneColor;

    public Renderer myRenderer;

    public GameObject myGameObject;

    public GameObject myHeight;

    public bool isHigh = false;
    public bool isHigher = false;

    public void Start()
    {
        myActualLevel = 0f;
        //myMaterial.color = startColor;
        myRenderer = GetComponent<Renderer>();
        myRenderer.enabled = true;
        myRenderer.sharedMaterial = myMaterial[0];
    }
    public void Update()
    {
        if(isHigh == false )
        {
          myRenderer.sharedMaterial = myMaterial[0];
           
          
            
        }
        if(isHigh == true)
        {
            myRenderer.sharedMaterial = myMaterial[1];
            isInSecondZone = true;
            
        }
        if(isHigher == true && isHigh == true)
        {
            myRenderer.sharedMaterial = myMaterial[2];
            isInTirdZone = true;
            isInSecondZone = false;
        }
        if(isHigher == false && isHigh == true)
        {
            myRenderer.sharedMaterial = myMaterial[1];
            isInTirdZone = false;
        }
        if(isHigh == false && isHigher == false)
        {
            myRenderer.sharedMaterial = myMaterial[0];
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("FIrstPosition"))
        {
            isHigh = true;
        }
         if(other.CompareTag("SecondPosition"))
         {
            isHigher = true;
         }
    }
    public void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("SecondPosition"))
        {
            isHigher = false;
        }
        if(other.CompareTag("FIrstPosition"))
        {
            isHigher = false;
            isHigh = false;
        }
    }

    
}

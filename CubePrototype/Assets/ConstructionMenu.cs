using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstructionMenu : MonoBehaviour
{
    public GameObject ConstructionUI;
    public bool isActive = false;

    public void ActivateUi()
    {
        if(isActive == false)
        {
            ConstructionUI.SetActive(true);
            isActive = true;

        }
        
        
    }
    public void DisactivateUI()
    {
        if(isActive == true)
        {
           ConstructionUI.SetActive(false);
           isActive = false;
        }
        
    }
}

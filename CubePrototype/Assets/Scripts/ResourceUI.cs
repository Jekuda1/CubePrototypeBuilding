using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ResourceUI : MonoBehaviour
{
  public GameObject popupPanel;
  //public TextMeshProUGUI resourceQuantityText;
 // public ResourceSource resource;

  void OnMouseEnter()
  {
    popupPanel.SetActive(true);
  } 
  void OnMouseExit()
  {
    popupPanel.SetActive(false);
  }
 

  
}

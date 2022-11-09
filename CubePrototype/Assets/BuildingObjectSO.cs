using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "newBuilding", menuName = "building")]
public class BuildingObjectSO : ScriptableObject
{
    [SerializeField] string id;

    public string ID {get {return id;}}
    public string buildingname;
    public string description;

    public GameObject buildingBody;

    public bool isChoosen = false;

    public bool isBuilded = false;
    
    public int Cost;
    public int Cost2;
   
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SelectManager : MonoBehaviour
{

    public GameObject selectedObject;
    public TextMeshProUGUI objNameText;
    private BuildingManager buildingmanager;
    public GameObject objUI;
    // Start is called before the first frame update
    void Start()
    {
        buildingmanager = GameObject.Find("BuildingManager").GetComponent<BuildingManager>();
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetMouseButtonDown(0))
       {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, 1000))
        {
            if(hit.collider.gameObject.CompareTag("Object"))
            {
                Select(hit.collider.gameObject);
            }
        }
       } 
       if(Input.GetMouseButtonDown(1))
       {
        Deselect();
       }
    }

    public void Select(GameObject obj)
    {
      if(obj == selectedObject)
      return;
      if(selectedObject != null) Deselect();
      Outline outline = obj.GetComponent<Outline>();
      if(outline == null) obj.AddComponent<Outline>();
      else outline.enabled = true;
      selectedObject = obj;
      objUI.SetActive(true);
      objNameText.text = obj.name;
    }

    public void Deselect()
    {
        objUI.SetActive(false);
        selectedObject.GetComponent<Outline>().enabled = false;
        selectedObject = null;
    }
    public void Move()
    {
        buildingmanager.pendingObject = selectedObject;
    }
    public void Delete()
    {
        GameObject objToDestroy = selectedObject;
        Deselect();
        Destroy(objToDestroy);
    }
}

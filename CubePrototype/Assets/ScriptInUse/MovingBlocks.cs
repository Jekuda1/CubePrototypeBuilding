using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBlocks : MonoBehaviour
{
   // this is the script responsable to move the bloks, is strictly related to the changing color script, 
   // the function that move the bloks are called from the button, i will try to make it smoother

    public GameObject selectedObject;
    public GameObject objUI;
   

    public ChangeColorCube cb;

  

    private Vector3 posi;


    void Update()
    { 
       if(Input.GetMouseButtonDown(0))
       {
         Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
         if(Physics.Raycast(ray, out hit, 1000))
         {
            if(hit.collider.gameObject.CompareTag("Ground"))
            {
                selectedObject = (hit.collider.gameObject);
                objUI.SetActive(true);
            }
         }
       }
       if(Input.GetMouseButtonDown(1))
       {
         objUI.SetActive(false);
       }
       
        
    }
    public void Start()
    {
      
      objUI.SetActive(false);
    }
    public void MoveUp()
    {
      
      selectedObject.transform.Translate(0f, 1f, 0f);
      cb.myActualLevel += 1f;
    }
    public void MoveDown()
    {
       selectedObject.transform.Translate(0f, -1f, 0f);
       
    }
    public void StopMoving()
    {
        selectedObject.transform.Translate(0f,0f,0f);
       
    }
}

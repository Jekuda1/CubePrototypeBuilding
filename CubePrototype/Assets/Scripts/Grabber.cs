using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabber : MonoBehaviour
{
    private GameObject selectedObject;
    public float YChanges = 1f;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(selectedObject == null)
            {
              RaycastHit hit = CastRay();
              if(!hit.collider.CompareTag("Ground"))
              {
                return;
              }
              selectedObject = hit.collider.gameObject;
              Cursor.visible = false;
            }
            

        }
        else
        {
            selectedObject = null;
            Cursor.visible = true;
        }
        if(selectedObject != null)
        {
            Vector3 position = new Vector3(Input.mousePosition.x, Camera.main.WorldToScreenPoint(selectedObject.transform.position).y, Input.mousePosition.z);
            Vector3 worldPosition = Camera.main.ScreenToViewportPoint(position);
            //selectedObject.transform.position = new Vector3(worldPosition.x, worldPosition.y, worldPosition.z);
           // selectedObject.transform.position = new Vector3(worldPosition.x, .25f, worldPosition.z); 
            selectedObject.transform.position = new Vector3(transform.position.x, transform.position.y +10, transform.position.z);

        }
    }
    private RaycastHit CastRay()
    {
        Vector3 screenMousePosFar = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.farClipPlane);

        Vector3 screenMousePosNear = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane);
        Vector3 worldMousePositionFar = Camera.main.ScreenToWorldPoint(screenMousePosFar);
        Vector3 worldMousePositionNear = Camera.main.ScreenToWorldPoint(screenMousePosNear);
        RaycastHit hit;
        Physics.Raycast(worldMousePositionNear, worldMousePositionFar - worldMousePositionNear, out hit);

        return hit;
    }
}

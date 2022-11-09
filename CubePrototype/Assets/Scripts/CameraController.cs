using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;
    public Transform cameraTransform;
    public Transform followTransform;
    public float movementSpeed;
   // public float normalSpeed;
   // public float fastSpeed;
    public float movementTime;
    public Vector3 newPosition;
    public Vector3 zoomAmount;
    public Vector3 newZoom;
    public float rotrationAmount;
    public Quaternion newRotation;
    public Vector3 dragStartPosition;
    public Vector3 dragCurrentPosition;
    public Vector3 rotateStartPosition;
    public Vector3 rotateCurrentPosition;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        newPosition = transform.position;
        newRotation = transform.rotation;
        newZoom = cameraTransform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if(followTransform != null)
        {
            transform.position = followTransform.position;
        }
         HandleMovementInput();
         HandleMouseInput();
         
    }
    void HandleMouseInput()
    {
        if(Input.mouseScrollDelta.y != 0)
        {
            newZoom += Input.mouseScrollDelta.y * zoomAmount;
        }
    /*  if(Input.GetMouseButtonDown(1))
      {
        Plane plane = new Plane(Vector3.up, Vector3.zero);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float entry;
        if(plane.Raycast(ray, out entry))
        {
            dragStartPosition = ray.GetPoint(entry);
        }
      }
      if(Input.GetMouseButtonDown(1))
      {
        Plane plane = new Plane(Vector3.up, Vector3.zero);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float entry;
        if(plane.Raycast(ray, out entry))
        {
            dragCurrentPosition = ray.GetPoint(entry);
            newPosition = cameraTransform.position + dragStartPosition - dragCurrentPosition;
        }
    }*/
     if(Input.GetMouseButtonDown(2))
     {
        rotateStartPosition = Input.mousePosition;
     }
      if(Input.GetMouseButtonDown(2))
      {
        rotateCurrentPosition = Input.mousePosition;
        Vector3 difference = rotateStartPosition - rotateCurrentPosition;
        rotateStartPosition = rotateCurrentPosition;
        newRotation *= Quaternion.Euler(Vector3.up * (-difference.x / 5f));
      }
   }
    void HandleMovementInput()
    {
         /*if(Input.GetKey(KeyCode.LeftShift))
         {
           movementSpeed = fastSpeed;
         }
         else
         {
            movementSpeed = normalSpeed;
         }*/
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            followTransform = null;
        }
        if(Input.GetKey(KeyCode.W))
        {
            newPosition += (transform.forward * movementSpeed);
        }
        if(Input.GetKey(KeyCode.S))
        {
            newPosition += (transform.forward * -movementSpeed); 
        }
        if(Input.GetKey(KeyCode.D))
        {
            newPosition += (transform.right * movementSpeed); 
        }
        if(Input.GetKey(KeyCode.A))
        {
            newPosition += (transform.right * -movementSpeed); 
        }
         if(Input.GetKey(KeyCode.Q))
        {
            newRotation *= Quaternion.Euler(Vector3.up * -rotrationAmount);
        }
        if(Input.GetKey(KeyCode.E))
        {
            newRotation *= Quaternion.Euler(Vector3.up * rotrationAmount);
        }
        if(Input.GetKey(KeyCode.T))
        {
            newZoom += zoomAmount;
        }
        if(Input.GetKey(KeyCode.G))
        {
            newZoom -= zoomAmount;
        }
        cameraTransform.localPosition = Vector3.Lerp(cameraTransform.localPosition, newZoom, Time.deltaTime * movementTime );
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime * movementTime);
        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * movementTime);
    }
}

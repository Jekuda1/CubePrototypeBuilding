using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoints : MonoBehaviour
{ public WayPoints NextWayPoint;

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position, 0.2f);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

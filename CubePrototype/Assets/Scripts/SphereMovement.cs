using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereMovement : MonoBehaviour
{
    public WayPoints CurrWaypoint;
    public float MoveSpeed = 5;
    // Start is called before the first frame update
    void Start()
    {
        if(CurrWaypoint != null)
        return;
        WayPoints[] WayPoints = FindObjectsOfType<WayPoints>();

        float lastMinDistance = float.MaxValue;

        foreach (var wp in WayPoints)
        {
            float dist = Vector3.Distance(transform.position, wp.transform.position);
            if(dist < lastMinDistance)
            {
                CurrWaypoint = wp;
                lastMinDistance = dist;
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, CurrWaypoint.transform.position, MoveSpeed * Time.deltaTime);

        if(Vector3.Distance(transform.position, CurrWaypoint.transform.position) < 0.05f)
        {
            CurrWaypoint = CurrWaypoint.NextWayPoint;
        }
    }
}

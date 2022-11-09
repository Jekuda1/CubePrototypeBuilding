using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WasteSpawner : MonoBehaviour
{

    public GameObject wastePrefab;
    public DisplayBuilding db;
    public bool stopSpawning;

    public float interval = 10;
    float timer;
    // Start is called before the first frame update
    void Start()
    { 
        //&& timer >= interval
        //timer += Time.deltaTime;
       
        
    }

    // Update is called once per frame Input.GetKeyDown(KeyCode.Space)
    void Update()
    {
         if(db.wasteAmount >= 10 )
        {
           // ShitGenerator();
          Invoke("GenerateShit", 0.1f);
        }
    }
    public void ShitGenerator()
    {
      Vector3 randomSpawnPosition = new Vector3(Random.Range(-16, 2), 4, Random.Range(1, 10));
         GameObject newObject = Instantiate(wastePrefab, randomSpawnPosition, Quaternion.identity);
         
    }
    public void SpawnObject()
    {
        Vector3 randomSpawnPosition = new Vector3(Random.Range(-16, 2), 4, Random.Range(1, 10));
        Instantiate(wastePrefab, randomSpawnPosition, transform.rotation);
        if(stopSpawning)
        CancelInvoke("SpawnObject");
    }
    public void GenerateShit()
    {
       stopSpawning = false;
            timer -= interval;
            InvokeRepeating("SpawnObject", timer, interval);
            stopSpawning = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreGenerator : MonoBehaviour
{
    public float ScoreAmount = 0f;
    public float ScoreIncrease = 1f;
    public bool isPlaced;
    public TextMeshProUGUI ScoreUI;
    // Start is called before the first frame update
    void Start()
    {
        isPlaced = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isPlaced)
        {
            ScoreAmount += ScoreIncrease * Time.deltaTime;
            ScoreUI.text = "" + ScoreAmount;
        }
        
    }
    void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("ScoreGenerator1"))
        {
            isPlaced = true;
        }
    }
}

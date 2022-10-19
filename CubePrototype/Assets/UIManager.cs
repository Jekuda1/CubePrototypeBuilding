using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private BuildingManager _buildingmanager;
    public Transform buildingMenu;
    public GameObject buildingButtonPrefab;
    public Transform resourcesUIParent;
    public GameObject gameResourceDisplayPrefab;

    private Dictionary<string, Text> _resourceTexts;

    private void Awake()
    {

        //_buildingmanager = GetComponent<BuildingManager>();


        // create texts for each in-game resource (gold, wood, stone...)
        _resourceTexts = new Dictionary<string, Text>();
        foreach (KeyValuePair<string, GameResources> pair in Globals.GAME_RESOURCES)
        {
            GameObject display = Instantiate(gameResourceDisplayPrefab, resourcesUIParent);
            display.name = pair.Key;
            _resourceTexts[pair.Key] = display.transform.Find("Text").GetComponent<Text>();
            _SetResourceText(pair.Key, pair.Value.Amount);
        }

        // create buttons for each building type
        // ...
    }

    private void _SetResourceText(string resource, int value)
    {
        _resourceTexts[resource].text = value.ToString();
    }

    public void UpdateResourceTexts()
    {
        foreach (KeyValuePair<string, GameResources> pair in Globals.GAME_RESOURCES)
        {
            _SetResourceText(pair.Key, pair.Value.Amount);
        }
    }
}

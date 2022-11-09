using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameResources : MonoBehaviour
{
    private string _name;
    private int _currentAmount;

    public GameResources(string name, int initialAmount)
    {
        _name = name;
        _currentAmount = initialAmount;
    }

    public void AddAmount(int value)
    {
        _currentAmount += value;
        if(_currentAmount < 0)
        _currentAmount = 0;
    }
    public string Name { get => _name;}
    public int Amount { get => _currentAmount;}
    
        
    
}

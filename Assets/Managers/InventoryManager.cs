using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] SharedVariables sharedVariables = null;
    void Start()
    {
        
    }

    public int GetCoinsAmount()
    {
        return sharedVariables.coinsCount;
    }
    public void AddCoins(int amount)
    {
        sharedVariables.UpdateCoinCount(sharedVariables.coinsCount + amount);
    }
    public void RemoveCoins(int amount)
    {
        sharedVariables.UpdateCoinCount(sharedVariables.coinsCount - amount);
    }

    void Update()
    {
        
    }
}

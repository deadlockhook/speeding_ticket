using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SharedVariables : MonoBehaviour
{

    public float fuelAmount = 0.0f;
    public float nitroAmount = 0.0f;
    public int coinsCount = 0;

    public TextMeshProUGUI coinAmtText;
    public TextMeshProUGUI fuelAmtText;
    public TextMeshProUGUI nitroAmtText;
    void Start()
    {
        
    }

    public void UpdateCoinCount(int newCoinsCount)
    {
        coinsCount = newCoinsCount;
        coinAmtText.text = "Coins : " + coinsCount;
    }
    public void UpdateFuelAmount(float newfuelAmount)
    {
        fuelAmount = newfuelAmount;
        fuelAmtText.text = "Fuel : " + (int)fuelAmount + "%";
    }
    public void UpdateNitroAmount(float newnitroAmount)
    {
        nitroAmount = newnitroAmount;
        nitroAmtText.text = "Nitro : " + (int)nitroAmount + "%";
    }

    void Update()
    {
        
    }
}

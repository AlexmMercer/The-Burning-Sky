using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    [SerializeField] GameManager MainManager;
    public void BuyMachineGun()
    {
        if(MainManager.getTotalCoinsValue() >= 0)
        {
            MainManager.decreaseTotalCoinsValue(0);
            MainManager.allowToUseMachineGun();
            Debug.Log("You have bought M2 Browning!");
        } else
        {
            Debug.Log("Not enough money to buy MachineGun!");
        }
    }

    public void BuyUnguidedMissiles()
    {
        if (MainManager.getTotalCoinsValue() >= 200)
        {
            MainManager.decreaseTotalCoinsValue(200);
            MainManager.allowToUseUnguidedMissiles();
            Debug.Log("You have bought unguided missiles!");
        }
        else
        {
            Debug.Log("Not enough money to buy unguided missiles!");
        }
    }
}

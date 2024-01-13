using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    [SerializeField] GameManager MainManager;
    [SerializeField] GameObject WeaponryPanel;
    [SerializeField] GameObject AmmoPanel;
    [SerializeField] GameObject BuyM2Button;
    [SerializeField] GameObject BuyUnguidedMissilesButton;
    [SerializeField] TextMeshProUGUI TotalCoinsText;
    [SerializeField] TextMeshProUGUI TotalM2AmmoText;
    [SerializeField] TextMeshProUGUI TotalUnguidedMissilesText;
    [SerializeField] int M2BrowningPrice = 100;
    [SerializeField] int UnguidedMissileAbilityPrice = 200;
    [SerializeField] int AmmoM2BrowningPrice = 10;
    [SerializeField] int UnguidedMissilePrice = 20;
    [SerializeField] GameObject Player;


    private void Start()
    {
        WeaponryPanel.SetActive(true);
        AmmoPanel.SetActive(false);
        TotalCoinsText.text = $"{MainManager.getTotalCoinsValue()}";
        TotalM2AmmoText.text = $"{MainManager.getSummaryAmmoValue()}";
    }
    public void BuyMachineGun()
    {
        if(MainManager.getTotalCoinsValue() >= M2BrowningPrice)
        {
            MainManager.decreaseTotalCoinsValue(M2BrowningPrice);
            MainManager.allowToUseMachineGun();
            MainManager.setSummaryAmmoValue(10);
            Debug.Log("You have bought M2 Browning!");
            BuyM2Button.GetComponent<Button>().enabled = false;
        } else
        {
            Debug.Log("Not enough money to buy MachineGun!");
        }
    }

    public void BuyUnguidedMissiles()
    {
        if (MainManager.getTotalCoinsValue() >= UnguidedMissileAbilityPrice)
        {
            MainManager.decreaseTotalCoinsValue(UnguidedMissileAbilityPrice);
            MainManager.allowToUseUnguidedMissiles();
            Debug.Log("You have bought unguided missiles!");
            BuyUnguidedMissilesButton.GetComponent<Button>().enabled = false;
        }
        else
        {
            Debug.Log("Not enough money to buy unguided missiles!");
        }
    }

    public void BuyAmmoForMachineGun()
    {
        if(MainManager.getTotalCoinsValue() >= AmmoM2BrowningPrice)
        {
            MainManager.decreaseTotalCoinsValue(AmmoM2BrowningPrice);
            MainManager.addAmmo(1);
            Debug.Log("You have bought 1 ammo for M2 'Browning' !");
            Debug.Log($"Summary ammo: {MainManager.getSummaryAmmoValue()}");
            TotalCoinsText.text = $"{MainManager.getTotalCoinsValue()}";
            TotalM2AmmoText.text = $"{MainManager.getSummaryAmmoValue()}";
        } else
        {
            Debug.Log("Not enough money to buy ammo.");
        }
    }

    public void BuyUnguidedMissile()
    {
        if (MainManager.getTotalCoinsValue() >= UnguidedMissilePrice)
        {
            MainManager.decreaseTotalCoinsValue(UnguidedMissilePrice);
            MainManager.addUnguidedMissile(1);
            Debug.Log("You have bought 1 unguided missile!");
            Debug.Log($"Summary ammo: {MainManager.getSummaryUnguidedMissilesValue()}");
            TotalCoinsText.text = $"{MainManager.getTotalCoinsValue()}";
            TotalUnguidedMissilesText.text = $"{MainManager.getSummaryUnguidedMissilesValue()}";
        }
        else
        {
            Debug.Log("Not enough money to buy unguided missile.");
        }
    }

    public void ShowWeaponry()
    {
        WeaponryPanel.SetActive(true);
        AmmoPanel.SetActive(false);
    }

    public void ShowAmmo()
    {
        WeaponryPanel.SetActive(false);
        AmmoPanel.SetActive(true);
    }
}

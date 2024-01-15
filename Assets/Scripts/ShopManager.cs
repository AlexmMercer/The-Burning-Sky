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
    [SerializeField] GameObject BuyM2AmmoButton;
    [SerializeField] GameObject BuyUnguidedMissilesAmmoButton;
    [SerializeField] AudioClip ApprovedSound;
    [SerializeField] AudioClip DeniedSound;
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
            PurchaseM2Approved();
        } else
        {
            Debug.Log("Not enough money to buy MachineGun!");
            M2PurchaseDenied();
        }
    }

    public void BuyUnguidedMissiles()
    {
        if (MainManager.getTotalCoinsValue() >= UnguidedMissileAbilityPrice)
        {
            MainManager.decreaseTotalCoinsValue(UnguidedMissileAbilityPrice);
            MainManager.allowToUseUnguidedMissiles();
            PurchaseUnguidedMissilesApproved();
            Debug.Log("You have bought unguided missiles!");
        }
        else
        {
            UnguidedMissilesPurchaseDenied();
            Debug.Log("Not enough money to buy unguided missiles!");
        }
    }

    public void BuyAmmoForMachineGun()
    {
        if(MainManager.getSummaryAmmoValue() < 50)
        {
            if (MainManager.getTotalCoinsValue() >= AmmoM2BrowningPrice)
            {
                MainManager.decreaseTotalCoinsValue(AmmoM2BrowningPrice);
                MainManager.addAmmo(1);
                PurchaseM2AmmoApproved();
                Debug.Log("You have bought 1 ammo for M2 'Browning' !");
                Debug.Log($"Summary ammo: {MainManager.getSummaryAmmoValue()}");
                TotalCoinsText.text = $"{MainManager.getTotalCoinsValue()}";
                TotalM2AmmoText.text = $"{MainManager.getSummaryAmmoValue()}";
            }
            else
            {
                Debug.Log("Not enough money to buy ammo.");
                M2AmmoPurchaseDenied();
            }
        }
    }

    public void BuyUnguidedMissile()
    {
        if(MainManager.getSummaryUnguidedMissilesValue() < 6)
        {
            if (MainManager.getTotalCoinsValue() >= UnguidedMissilePrice)
            {
                MainManager.decreaseTotalCoinsValue(UnguidedMissilePrice);
                MainManager.increaseSummaryUnguidedMissilesValue();
                PurchaseUnguidedMissileAmmoApproved();
                MainManager.addUnguidedMissile();
                Debug.Log("You have bought 1 unguided missile!");
                Debug.Log($"Summary unguided missiles number: {MainManager.getSummaryUnguidedMissilesValue()}");
                TotalCoinsText.text = $"{MainManager.getTotalCoinsValue()}";
                TotalUnguidedMissilesText.text = $"{MainManager.getSummaryUnguidedMissilesValue()}";
            }
            else
            {
                UnguidedMissileAmmoPurchaseDenied();
                Debug.Log("Not enough money to buy unguided missile.");
            }
        }
        else
        {
            Debug.Log("Unguided missiles limit achieved.");
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

    public void PurchaseM2Approved()
    {
        BuyM2Button.GetComponent<AudioSource>().clip = ApprovedSound;
    }

    public void M2PurchaseDenied()
    {
        BuyM2Button.GetComponent<AudioSource>().clip = DeniedSound;
    }

    public void PurchaseUnguidedMissilesApproved()
    {
        BuyUnguidedMissilesButton.GetComponent<AudioSource>().clip = ApprovedSound;
    }

    public void UnguidedMissilesPurchaseDenied()
    {
        BuyUnguidedMissilesButton.GetComponent<AudioSource>().clip = DeniedSound;
    }

    public void PurchaseM2AmmoApproved()
    {
        BuyM2AmmoButton.GetComponent<AudioSource>().clip = ApprovedSound;
    }

    public void M2AmmoPurchaseDenied()
    {
        BuyM2AmmoButton.GetComponent<AudioSource>().clip = DeniedSound;
    }

    public void PurchaseUnguidedMissileAmmoApproved()
    {
      BuyUnguidedMissilesAmmoButton.GetComponent<AudioSource>().clip = ApprovedSound;
    }

    public void UnguidedMissileAmmoPurchaseDenied()
    {
      BuyUnguidedMissilesAmmoButton.GetComponent<AudioSource>().clip = DeniedSound;
    }

    public void M2AmmoBuyButtonClickSound()
    {
        BuyM2AmmoButton.GetComponent<AudioSource>().Play();
    }

    public void UnguidedMissileAmmoBuyButtonClickSound()
    {
        BuyM2AmmoButton.GetComponent<AudioSource>().Play();
    }

    public void BuyM2ButtonPlaySound()
    {
        BuyM2Button.GetComponent<AudioSource>().Play();
    }

    public void BuyUnguidedMissilesPlaySound()
    {
        BuyUnguidedMissilesButton.GetComponent<AudioSource>().Play();
    }
}

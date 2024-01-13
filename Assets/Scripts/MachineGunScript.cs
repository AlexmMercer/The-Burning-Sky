using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject.SpaceFighter;

public class MachineGunScript : MonoBehaviour
{
    [SerializeField] GameObject Bullet;
    [SerializeField] GameObject Player;
    [SerializeField] GameManager Manager;
    [SerializeField] TextMeshProUGUI AmmoLeftText;
    private float timeBetweenShots = 0.15f;
    private float timeBetweenQueues = 15.0f;
    private float timeCounterBetweenBullets = 0;
    private float timeCounterBetweenQueues = 0;
    private int bulletCounter = 0;
    private List<GameObject> bullets = new List<GameObject>();
    private float shotPower = 90.0f;

    private void Start()
    {
        AmmoLeftText.text = $"{Manager.getSummaryAmmoValue()}";
    }

    void Update()
    {
        timeCounterBetweenBullets += Time.deltaTime;
        if(Input.GetKeyDown(KeyCode.V))
        {
            ShootMachineGun();
        }

       foreach(var bullet in bullets)
        {
            if(bullet != null) 
            {
                Vector3 X = new Vector3(Player.transform.forward.x, Player.transform.forward.y, Player.transform.forward.z);
                //bullet.transform.Translate(Vector3.Cross(X, Vector3.up) * (-shotPower) * Time.deltaTime);
            }
        }
    }

    public void ShootMachineGun()
    {
        if(Manager.getSummaryAmmoValue() > 0)
        {
            GetComponent<AudioSource>().Play();
            GameObject bulletNew = Instantiate(Bullet);
            bulletNew.transform.position = gameObject.transform.position;
            Quaternion rotation = Quaternion.LookRotation(Vector3.Cross(Player.transform.forward, Vector3.up));
            //bulletNew.transform.rotation = Bullet.transform.rotation;
            bulletNew.transform.rotation = rotation;
            bulletNew.transform.SetParent(null);
            Manager.addAmmo(-1);
            bullets.Add(bulletNew);
            bulletNew.GetComponent<Rigidbody>().AddRelativeForce(Player.transform.right * shotPower, ForceMode.VelocityChange);
            AmmoLeftText.text = $"{Manager.getSummaryAmmoValue()}";
        }
    }
}

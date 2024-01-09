using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using Zenject.SpaceFighter;

public class MissileLauncher : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI MissilesLeftText;

    private List<GameObject> unguidedMissiles = new List<GameObject>();
    private float missilePower = 50.0f;

    void Start()
    {
        foreach(Transform obj in transform)
        {
            if(obj.tag == "PlayerUnguidedMissile")
            {
                unguidedMissiles.Add(obj.gameObject);
            }
        }
        MissilesLeftText.text = $"{unguidedMissiles.Count}";
    }

    void Update()
    {
        
    }

    public void LaunchUnguidedMissile()
    {
        if(unguidedMissiles.Count > 0)
        {
            GameObject missileNew = unguidedMissiles[unguidedMissiles.Count - 1];
            missileNew.transform.SetParent(null);
            missileNew.GetComponent<AudioSource>().Play();
            missileNew.transform.Find("UnguidedMissileEngineFire 1").gameObject.SetActive(true);
            unguidedMissiles.RemoveAt(unguidedMissiles.Count - 1);
            MissilesLeftText.text = $"{unguidedMissiles.Count}";
            missileNew.GetComponent<Rigidbody>().AddRelativeForce(transform.up * missilePower, ForceMode.VelocityChange);
        } else
        {
            MissilesLeftText.text = "0";
        }
    }
}

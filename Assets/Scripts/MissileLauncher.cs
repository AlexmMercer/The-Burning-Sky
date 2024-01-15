using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using Zenject.SpaceFighter;

public class MissileLauncher : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI MissilesLeftText;
    [SerializeField] GameManager MainManager;
    [SerializeField] GameObject UnguidedMissilePrefab;

    private List<GameObject> unguidedMissiles = new List<GameObject>();
    private float missilePower = 70.0f;

    void Start()
    {
        int unguidedMissilesNumber = MainManager.getSummaryUnguidedMissilesValue();
        List<Transform> missileSlots = new List<Transform>();

        foreach(Transform obj in transform)
        {
            if(obj.tag == "MissileSlot")
            {
                missileSlots.Add(obj);
            }
        }
        Debug.Log(missileSlots.Count);
        for(int i = 0; i < unguidedMissilesNumber; i++)
        {
            var missileUnguidedNew = Instantiate(UnguidedMissilePrefab, missileSlots[i].transform.position, UnguidedMissilePrefab.transform.rotation);
            missileUnguidedNew.transform.SetParent(missileSlots[i]);
            unguidedMissiles.Add(missileUnguidedNew);
        }
        Debug.Log(unguidedMissilesNumber);
        MissilesLeftText.text = $"{unguidedMissiles.Count}";
    }

    void Update()
    {
        
    }

    public void LaunchABarrageOfMissiles()
    {
        for (int i = 0; i < unguidedMissiles.Count; i++) 
        {
            //StartCoroutine(LaunchMissileAfterDelay(0.00f));
        }
    }

    private IEnumerator LaunchMissileAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        LaunchUnguidedMissile();
    }

    public void LaunchUnguidedMissile()
    {
        if(unguidedMissiles.Count > 0)
        {
            GameObject missileNew = unguidedMissiles[unguidedMissiles.Count - 1];
            missileNew.transform.SetParent(null);
            missileNew.AddComponent<Rigidbody>();
            missileNew.GetComponent<Rigidbody>().useGravity = false;
            missileNew.GetComponent<AudioSource>().Play();
            missileNew.transform.Find("UnguidedMissileEngineFire 1").gameObject.SetActive(true);
            unguidedMissiles.RemoveAt(unguidedMissiles.Count - 1);
            MissilesLeftText.text = $"{unguidedMissiles.Count}";
            MainManager.DecreaseDestroyedMissilesNumber();
            missileNew.GetComponent<Rigidbody>().AddRelativeForce(transform.up * missilePower, ForceMode.VelocityChange);
        } else
        {
            MissilesLeftText.text = "0";
        }
    }
}

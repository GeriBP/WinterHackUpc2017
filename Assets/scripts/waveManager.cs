using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waveManager : MonoBehaviour {
    public float iniTime, incTime, minTime, increment;
    public GameObject slime, ghost;
    public GameObject[] spawnpointSlime;
    [Range(0.0f, 1.0f)]
    public float slimeProb = 0.5f;
    //fantasmes only initialize
    // Use this for initialization
    void Start () {
        StartCoroutine(spawnGuys());
        StartCoroutine(incTimer());
    }

    IEnumerator spawnGuys()
    {
        while (true)
        {
            float enemy = Random.Range(0.0f, 1.0f);
            if (enemy < slimeProb)
            {
                int selSpwn = Random.Range(0, spawnpointSlime.Length);
                Instantiate(slime, spawnpointSlime[selSpwn].transform.position, Quaternion.identity);
            } else
            {
                Instantiate(ghost, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);
            }
            yield return new WaitForSeconds(iniTime);
        }
    }

    IEnumerator incTimer()
    {
        while (iniTime >= minTime)
        {
            iniTime -= increment;
            yield return new WaitForSeconds(incTime);
        }
        yield return null;
    }
}

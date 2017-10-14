using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waveManager : MonoBehaviour {
    public float initial, incTime, minTime, increment;
    public GameObject slime, ghost;
    public GameObject[] spawnpointSlime;
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
            Instantiate(enemy, //POSICIO, radiusF), Quaternion.identity);
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

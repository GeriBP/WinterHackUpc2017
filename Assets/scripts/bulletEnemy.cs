using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletEnemy : MonoBehaviour {
    public GameObject deathPS;
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameObject.Find("flamethrower").GetComponent<PlayerWeapon>().TakeDamage(2.0f);
        } else if (other.tag == "shield")
        {
            //ps
            GameObject.Instantiate(deathPS, transform.position, Quaternion.identity);
        }
        //Instantiate PS
        Destroy(gameObject);
    }
}

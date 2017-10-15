using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletEnemy : MonoBehaviour {
    [HideInInspector]
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameObject.Find("flamethrower").GetComponent<PlayerWeapon>().TakeDamage();
        } else if (other.tag == "shield")
        {
            //ps
        }
        //Instantiate PS
        Destroy(gameObject);
    }
}

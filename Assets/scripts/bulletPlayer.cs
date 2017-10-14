using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletPlayer : MonoBehaviour {
    [HideInInspector]
    public float damage;
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "enemy")
        {
            other.gameObject.SendMessage("TakeDamage", damage);
        }
        //Instantiate PS
        Destroy(gameObject);
    }
}

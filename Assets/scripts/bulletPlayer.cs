using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletPlayer : MonoBehaviour {
    [HideInInspector]
    public float damage;
    public GameObject deathPS;
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "enemy")
        {
            other.gameObject.SendMessage("TakeDamage", damage);
        }
        //Instantiate PS
        GameObject.Instantiate(deathPS, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    public void SetDamage(float f)
    {
        damage = f;
    }
}

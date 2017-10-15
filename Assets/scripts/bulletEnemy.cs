using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletEnemy : MonoBehaviour {
    public GameObject deathPS;
    public AudioClip clip;
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameObject.Find("flamethrower").GetComponent<PlayerWeapon>().TakeDamage(2.0f);
            AudioSource.PlayClipAtPoint(clip, gameObject.transform.position, 0.5f);
            Destroy(gameObject);
        } else if (other.tag == "shield")
        {
            //ps
            GameObject.Instantiate(deathPS, transform.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(clip, gameObject.transform.position, 0.5f);
            Destroy(gameObject);
        }
        //Instantiate PS
        
    }
}

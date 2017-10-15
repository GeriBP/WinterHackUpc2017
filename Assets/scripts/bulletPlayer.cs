using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletPlayer : MonoBehaviour {
    [HideInInspector]
    public float damage;
    public AudioClip clip;
    public GameObject deathPS;
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "enemy")
        {
            other.gameObject.SendMessage("TakeDamage", damage);
        }
        //Instantiate PS
        GameObject.Instantiate(deathPS, transform.position, Quaternion.identity);
        AudioSource.PlayClipAtPoint(clip, gameObject.transform.position, 0.5f);
        Destroy(gameObject);
    }

    public void SetDamage(float f)
    {
        damage = f;
    }
}

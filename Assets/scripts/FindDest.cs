using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindDest : MonoBehaviour {

	public float hp = 100;
	private float currentHP;
	private float damageHP = 1;

	private GameObject portal_1;
	private GameObject portal_2;
	private Vector3 target;
	public float MaxScale = 1;
	public GameObject deathPS;
	private AudioClip clip;


	// Use this for initialization
	void Start () {
		currentHP = hp;
		portal_1 = GameObject.Find("Stone_Gate");
		portal_2 = GameObject.Find("Stone_Gate2");
		//float rand = Random.Range(0.0f, 2.0f);
		if (Vector3.Distance(transform.position, portal_1.transform.position) < Vector3.Distance(transform.position, portal_2.transform.position)) target = portal_1.transform.position;
		else target = portal_2.transform.position;
		transform.GetComponent<UnityEngine.AI.NavMeshAgent>().destination = target;

		int i = (int) Mathf.Floor (Random.Range(0.0f, 6.0f));
		string file0 = "Sounds/Dead";
		string file = file0 + i.ToString();
		clip = Resources.Load<AudioClip> (file);
	}

	public void TakeDamage(float dmg) {
		hp -= dmg;
		if (hp <= 0.0f) {
			Death ();
		}
	}

	void Death() {
		//Particle system goes here
		AudioSource.PlayClipAtPoint(clip, gameObject.transform.position);

        GameObject.Instantiate(deathPS, transform.position, Quaternion.identity);
        GameObject.Find("GameManager").GetComponent<score>().modifyScore(5);
        Destroy (this.gameObject);
	}

	void FixedUpdate() {
		transform.LookAt(transform.position + transform.GetComponent<UnityEngine.AI.NavMeshAgent>().velocity);
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "portal")
        {
            //ps
            GameObject.Instantiate(deathPS, transform.position, Quaternion.identity);
            Destroy(gameObject);
            GameObject.Find("flamethrower").GetComponent<PlayerWeapon>().TakeDamage(1.0f);
        }
        //Instantiate PS
        
    }
}
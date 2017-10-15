﻿using System.Collections;
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

	// Use this for initialization
	void Start () {
		currentHP = hp;
		portal_1 = GameObject.Find("Stone_Gate");
		portal_2 = GameObject.Find("Stone_Gate2");
		float rand = Random.Range(0.0f, 2.0f);
		if (rand <= 1.0f) target = portal_1.transform.position;
		else target = portal_2.transform.position;
		transform.GetComponent<UnityEngine.AI.NavMeshAgent>().destination = target;
	}

	public void TakeDamage(float dmg) {
		hp -= dmg;
		if (hp <= 0.0f) {
			Death ();
		}
	}

	void Death() {
		//Particle system goes here
		float F = Mathf.Floor(Random.Range(1.0f, 7.0f));
		int i = (int) F;
		FindObjectOfType<AudioMngr>().PlaySound(i);

        GameObject.Instantiate(deathPS, transform.position, Quaternion.identity);
        Destroy (this.gameObject);
	}

	void FixedUpdate() {
		transform.LookAt(transform.position + transform.GetComponent<UnityEngine.AI.NavMeshAgent>().velocity);
	}
}
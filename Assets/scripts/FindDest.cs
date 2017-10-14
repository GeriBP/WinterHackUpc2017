using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindDest : MonoBehaviour {

	public Transform portal_1;
	public Transform portal_2;

	// Use this for initialization
	void Start () {
		//dest = 
	}
	
	// Update is called once per frame
	void Update () {
		transform.GetComponent<UnityEngine.AI.NavMeshAgent>().destination = 
		 Vector3.Min(portal_1.position, portal_2.position);﻿
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindDest : MonoBehaviour {

	public Transform destination;

	// Use this for initialization
	void Start () {
		//dest = 
	}
	
	// Update is called once per frame
	void Update () {
		transform.GetComponent<UnityEngine.AI.NavMeshAgent>().destination = destination.position;﻿
	}
}

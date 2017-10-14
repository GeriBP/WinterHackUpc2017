using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindDest : MonoBehaviour {

	public Transform portal_1;
	public Transform portal_2;
	private Vector3 target;

	// Use this for initialization
	void Start () {
		float rand = Random.Range(0.0f, 2.0f);
		if (rand <= 1.0f) target = portal_1.position;
		else target = portal_2.position;
	}
	
	// Update is called once per frame
	void Update () {		
		transform.GetComponent<UnityEngine.AI.NavMeshAgent>().destination = target;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindDest : MonoBehaviour {

	public GameObject portal_1;
	public GameObject portal_2;
	private Vector3 target;

	// Use this for initialization
	void Start () {
		portal_1 = GameObject.Find("Stone_Gate");
		portal_2 = GameObject.Find("Stone_Gate2");
		float rand = Random.Range(0.0f, 2.0f);
		if (rand <= 1.0f) target = portal_1.transform.position;
		else target = portal_2.transform.position;
		transform.GetComponent<UnityEngine.AI.NavMeshAgent>().destination = target;
	}
}

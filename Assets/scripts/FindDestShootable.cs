using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindDestShootable : MonoBehaviour {

	private GameObject portal_1;
	private GameObject portal_2;
	private GameObject PlayerTarget;
	public GameObject projectile;
	private Vector3 target;

	// Use this for initialization
	void Start () {
		PlayerTarget = GameObject.FindGameObjectWithTag("Player");
		portal_1 = GameObject.Find("Stone_Gate");
		portal_2 = GameObject.Find("Stone_Gate2");
		float rand = Random.Range(0.0f, 2.0f);
		if (rand <= 1.0f) target = portal_1.transform.position;
		else target = portal_2.transform.position;
		transform.
		transform.GetComponent<UnityEngine.AI.NavMeshAgent>().destination = target;
	}

	void ShootBullet() {
		Instantiate(projectile, this.transform);
	}

	void Update () {
		float rand = Random.Range(0.0f, 10.0f);
		if (rand < 1.0f) ShootBullet ();
	}

}

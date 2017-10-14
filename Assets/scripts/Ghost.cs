using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour {
    #region parameters
    [Header("Ghost numeric parameters")]
    [SerializeField]
    float hp;
    private float currrentHp;
    [SerializeField]
    float speed;
    [SerializeField]
    float flightMin;
    [SerializeField]
    float flightMax;
    [SerializeField]
    float firerate;
    [SerializeField]
    float bulletSpeed;
    [Header("Ghost gameobjects")]
    [SerializeField]
    GameObject bullet;
    [SerializeField]
    GameObject gunPoint;
    public Vector3 iniCenter, iniSize;
    public Vector3 endCenter, endSize;

    private Vector3 spawnPoint, goalPoint, flightPoint;

    private int stage = 0; //0 towards flight, 1 flying, 2 attacking

    private Rigidbody myRb;
    private bool canfire = true;
    private GameObject player;
    private Animator myAnim;
    #endregion
    // Use this for initialization
    void Start () {
        currrentHp = hp;
        spawnPoint = RandomPointInBox(iniCenter, iniSize);
        goalPoint = RandomPointInBox(endCenter, endSize);
        flightPoint = new Vector3(spawnPoint.x, Random.Range(flightMin, flightMax), spawnPoint.z);
        transform.position = spawnPoint;
        myRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Camera");
        myAnim = GetComponent<Animator>();
        Debug.Log(spawnPoint);
        Debug.Log(flightPoint);
        Debug.Log(goalPoint);
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.LookAt(player.transform);
        switch (stage)
        {
            case 0:
                myRb.AddForce((flightPoint-transform.position).normalized * speed, ForceMode.Force);
                if (Vector3.Distance(flightPoint, transform.position) <= 0.25f)
                {
                    stage = 1;
                }
                break;
            case 1:
                myRb.AddForce((goalPoint - transform.position).normalized * speed, ForceMode.Force);
                if (Vector3.Distance(goalPoint, transform.position) <= 0.25f)
                {
                    stage = 2;
                    myRb.velocity = Vector3.zero;
                    myAnim.SetBool("moving", false);
                }
                break;
            case 2:
                myRb.velocity = Vector3.zero;
                if (canfire)
                {
                    canfire = false;
                    Invoke("EnableFire", firerate);
                    GameObject tmp = Instantiate(bullet, gunPoint.transform.position, Quaternion.identity);
                    tmp.GetComponent<Rigidbody>().AddForce((player.transform.position - gunPoint.transform.position).normalized
                        * bulletSpeed, ForceMode.Impulse);
                }
            break;
        }
    }

    private static Vector3 RandomPointInBox(Vector3 center, Vector3 size)
    {
        return center + new Vector3(
           (Random.value - 0.5f) * size.x,
           (Random.value - 0.5f) * size.y,
           (Random.value - 0.5f) * size.z
        );
    }

    void EnableFire()
    {
        canfire = true;
    }
}

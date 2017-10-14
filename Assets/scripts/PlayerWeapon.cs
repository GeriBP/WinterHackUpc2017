using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using LockingPolicy = Thalmic.Myo.LockingPolicy;
using Pose = Thalmic.Myo.Pose;
using UnlockType = Thalmic.Myo.UnlockType;

public class PlayerWeapon : MonoBehaviour
{
    #region parameters
    [Header("Player numeric parameters")]
    [SerializeField]
    float hp;
    [SerializeField]
    float bulletForce;
    private float currentHp;
    [Header("Weapon numeric parameters")]
    [SerializeField]
    float firerate;
    [SerializeField]
    float maxScale;
    [SerializeField]
    float scaleFactor;
    private float initialScale;
    [Header("GameObject references")]
    [SerializeField]
    [Tooltip ("Point where we spawn bullets")]
    GameObject gunPoint;
    [SerializeField]
    GameObject bullet;
    [SerializeField]
    GameObject laserPoint;
    [SerializeField]
    GameObject myoManger;

    private ThalmicMyo myo;
    private bool canfire = true;
    private bool chargingShot = false;
    private Pose lastPose;
    private GameObject tempBullet = null;
    private LineRenderer laser;
    private Ray shootRay;
    private RaycastHit shootHit;
    #endregion
    // Use this for initialization
    void Start()
    {
        //Set current hp to maxHp
        currentHp = hp;
        //Get myo controller
        myo = myoManger.GetComponent<ThalmicMyo>();
        //initialize last position
        lastPose = Pose.Rest;
        //Set initial bullet scale for shooting
        initialScale = bullet.transform.localScale.x;
        //Set lineRenderer laser
        laser = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //Print current position
        //Debug.Log(myo.pose);

        //Scale bullet when charging
        if (chargingShot)
        {
            //Make bullet follow gunPoint
            tempBullet.transform.position = gunPoint.transform.position;
        }

        //Fire on release fist
        if (chargingShot && lastPose != Pose.Fist)
        {
            ShootBullet();
        }

        //Initialize charge shot
        if (canfire && !chargingShot && myo.pose == Pose.Fist)
        {
            //canfire = false;
            //Invoke("EnableFire", firerate);
            chargingShot = true;
            tempBullet = Instantiate(bullet, gunPoint.transform.position, Quaternion.identity);
            //tempBullet.GetComponent<Rigidbody>().AddForce(transform.forward.normalized * bulletForce, ForceMode.Impulse);
        }

        //Update laser
        laser.SetPosition(0, laserPoint.transform.position);
        shootRay.origin = laserPoint.transform.position;
        shootRay.direction = transform.forward;
        // Perform the raycast against gameobjects on the shootable layer and if it hits something...
        if (Physics.Raycast(shootRay, out shootHit, 100.0f))
        {
            laser.SetPosition(1, shootHit.point);
        }
        // If the raycast didn't hit anything on the shootable layer...
        else
        {
            //Set the second position of the line renderer to the fullest extent of the gun's range.
            laser.SetPosition(1, shootRay.origin + shootRay.direction * 100.0f);
        }

        //Set last pose for next update tick
        lastPose = myo.pose;
    }


    private void ShootBullet()
    {
        //Disable charging and firerate control
        chargingShot = false;
        canfire = false;
        Invoke("EnableFire", firerate);

        //Shoot bullet
        GameObject shotBullet = Instantiate(bullet, gunPoint.transform.position, Quaternion.identity);
        shotBullet.transform.localScale = tempBullet.transform.localScale;
        shotBullet.GetComponent<Rigidbody>().AddForce(transform.forward.normalized * bulletForce, ForceMode.Impulse);
        Destroy(tempBullet);
    }

    private void FixedUpdate()
    {
        if (chargingShot)
        {
            //I reuse x value since y and z are the same -> tiny memory allocation optimization
            if (tempBullet.transform.localScale.x < maxScale) tempBullet.transform.localScale = new Vector3(tempBullet.transform.localScale.x + scaleFactor,
                tempBullet.transform.localScale.x + scaleFactor, tempBullet.transform.localScale.x + scaleFactor);
            else
            {
                //Bullet charged to max
            }
        }
    }
    void EnableFire()
    {
        canfire = true;
    }
}

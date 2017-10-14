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
    GameObject myoManger;

    private ThalmicMyo myo;
    private bool canfire = true;
    private bool chargingShot = false;
    private Pose lastPose;
    private GameObject tempBullet = null;
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
    }

    // Update is called once per frame
    void Update()
    {
        //Scale bullet when charging
        if (chargingShot)
        {
            //I reuse x value since y and z are the same -> tiny memory allocation optimization
            if (tempBullet.transform.localScale.x < maxScale) tempBullet.transform.localScale = new Vector3(tempBullet.transform.localScale.x + scaleFactor,
                tempBullet.transform.localScale.x + scaleFactor, tempBullet.transform.localScale.x + scaleFactor);
            else
            {
                //Bullet charged to max
            }

            //Make bullet follow gunPoint
            tempBullet.transform.position = gunPoint.transform.position;
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

        //Fire on release fist
        if (chargingShot && myo.pose == Pose.Rest && lastPose == Pose.Fist)
        {
            //Disable charging and
            chargingShot = false;
            canfire = false;
            Invoke("EnableFire", firerate);
            tempBullet.GetComponent<Rigidbody>().AddForce(transform.forward.normalized * bulletForce, ForceMode.Impulse);
        }

        //Set last pose for next update tick
        lastPose = myo.pose;
    }

    void EnableFire()
    {
        canfire = true;
    }
}

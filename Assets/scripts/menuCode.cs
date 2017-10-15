using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using LockingPolicy = Thalmic.Myo.LockingPolicy;
using Pose = Thalmic.Myo.Pose;
using UnlockType = Thalmic.Myo.UnlockType;
using UnityEngine.UI;
public class menuCode : MonoBehaviour {
    private ThalmicMyo myo;
    [SerializeField]
    GameObject myoManger;
    // Use this for initialization
    void Start () {
        //Get myo controller
        myo = myoManger.GetComponent<ThalmicMyo>();
    }
	
	// Update is called once per frame
	void Update () {
        if (myo.pose == Pose.Fist && Time.time > 5.0f)
        {
            go();
        }
    }

    private void go()
    {
        SceneManager.LoadScene("tutorial");
    }
}

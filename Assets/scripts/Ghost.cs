using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour {
    #region parameters
    [Header("Ghost numeric parameters")]
    [SerializeField]
    float hp;
    private float currrentHp;
    #endregion
    // Use this for initialization
    void Start () {
        currrentHp = hp;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

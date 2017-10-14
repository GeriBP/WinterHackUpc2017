using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    #region parameters
    [Header("Player numeric parameters")]
    [SerializeField]
    float hp;
    private float currentHp;
    [Header("Weapon numeric parameters")]
    [SerializeField]
    float firerate;
    #endregion
    // Use this for initialization
    void Start()
    {
        currentHp = hp;
    }

    // Update is called once per frame
    void Update()
    {

    }
}

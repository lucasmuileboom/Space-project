using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    private PlayerInput _PlayerInput;

    [SerializeField]
    private Transform muzzle;
    private float fireRate = 0.5f;
    private float nextFire = 0.5f;
    [SerializeField]
    private GameObject projectile;

    void Awake ()
    {
        _PlayerInput = GetComponent<PlayerInput>();
    }
    void Start()
    {
        nextFire = Time.time + fireRate;
    }
	void Update ()
    {
        if (_PlayerInput.shoot)
        {
            if (Time.time >= nextFire)
            {
                nextFire = Time.time + fireRate;
                Instantiate(projectile,muzzle.position,muzzle.rotation);

            }
        }
	}
}

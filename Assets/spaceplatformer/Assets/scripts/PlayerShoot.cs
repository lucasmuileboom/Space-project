using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShoot : MonoBehaviour
{
    Animator animatie;
    private PlayerInput _PlayerInput;
    [SerializeField] private GameObject projectile;
    [SerializeField] private Transform muzzle;
    [SerializeField] private Text bullet;
    private float fireRate = 0.5f;
    private float nextFire;
    private float charge = 0.3f;
    private float donechargeing;
    private bool chargeing = false;

    private void Awake ()
    {
        _PlayerInput = GetComponent<PlayerInput>();
    }
    private void Start()
    {
        animatie = GetComponent<Animator>();
        nextFire = Time.time + fireRate;
    }
    private void Update()
    {
        if (_PlayerInput.shoot)
        {
            shoot();
        }
        if (Time.time >= donechargeing && chargeing)
        {
            animatie.SetBool("attack", false);
            
            print("shoot");
            nextFire = Time.time + fireRate;
            Instantiate(projectile, muzzle.position, muzzle.rotation);
            chargeing = false;
        }
        else
        {

        }
    }
    public void shoot()
    {
       if (Time.time >= nextFire && !chargeing)
       {
            animatie.SetBool("attack", true);
            donechargeing = Time.time + charge;
            print("wait");
            chargeing = true;
        }
    }
}

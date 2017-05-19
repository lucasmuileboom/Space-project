using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    private PlayerInput _PlayerInput;
    [SerializeField] private GameObject projectile;
    [SerializeField] private Transform muzzle;
    private float fireRate = 0.5f;
    private float nextFire;
    private float reloadtime = 1.0f;
    private float doneReloading;
    
    private int Magsize = 7;
    private int amountOfMag = 2;
    private int bullets;
    private bool reloading = false;
    
    
    private void Awake ()
    {
        _PlayerInput = GetComponent<PlayerInput>();
    }
    private void Start()
    {
        bullets = Magsize * amountOfMag;
        nextFire = Time.time + fireRate;
    }
    private void Update()
    {
        if (Magsize <= 0)
        {
            reload();
        }
        if (Time.time >= doneReloading && reloading)
        {
            if (bullets >= 7)
            {
                Magsize = 7;
                bullets -= 7;
                reloading = false;
                print("reloaded");
            }            
        }
    }
    public void shoot()
    {
        if (Magsize >= 1)
        {
            if (Time.time >= nextFire)
            {
                nextFire = Time.time + fireRate;
                Instantiate(projectile, muzzle.position, muzzle.rotation);
                Magsize--;
            }
        }
        print(Magsize);
        print("total" + bullets);
    }
    public void reload()
    {
        if (!reloading)
        {
            doneReloading = Time.time + reloadtime;
            reloading = true;
            
        }
        
        
    }
}

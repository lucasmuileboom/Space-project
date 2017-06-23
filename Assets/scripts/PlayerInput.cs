using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    //PlayerShoot _PlayerShoot;
    public bool left = false;
    public bool right = false;
    public bool up = false;
    public bool down = false;
    public bool shoot = false;

    private void Awake()
    {
        //_PlayerShoot = GetComponent<PlayerShoot>();
    }
	private void Update ()
    {
        if (Input.GetKeyDown(KeyCode.W))//Up
        {
            up = true;
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            up = false;
        }
        if (Input.GetKeyDown(KeyCode.S))//down
        {
            down = true;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            down = false;
        }
        if (Input.GetKeyDown(KeyCode.A))//left
        {
            left = true;
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            left = false;
        }
        if (Input.GetKeyDown(KeyCode.D))//right
        {
            right = true;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            right = false;
        }
        if (Input.GetKeyDown("space"))//shoot
        {
            shoot = true;
        }
        if (Input.GetKeyUp("space"))
        {
            shoot = false;
        }
    }
}

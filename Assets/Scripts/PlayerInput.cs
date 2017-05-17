using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public bool left = false;
    public bool right = false;
    public bool up = false;
    public bool shoot = false;

	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            up = true;
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            up = false;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            left = true;
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            left = false;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            right = true;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            right = false;
        }
        if (Input.GetKeyDown("space"))
        {
            shoot = true;
        }
        if (Input.GetKeyUp("space"))
        {
            shoot = false;
        }
    }

}

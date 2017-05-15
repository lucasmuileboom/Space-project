using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public bool left = false;
    public bool right = false;
    public bool up = false;

	void Update ()
    {
        if (Input.GetKeyDown("space"))
        {
            up = true;
        }
        if (Input.GetKeyUp("space"))
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
    }

}

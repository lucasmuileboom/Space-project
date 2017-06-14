using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Groundcollision : MonoBehaviour
{
    public bool Grounded = false;

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Ground")
        {
            Grounded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D col)
    {
        Grounded = false;
    }
}

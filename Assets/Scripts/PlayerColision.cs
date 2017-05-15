using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColision : MonoBehaviour
{
    public bool Grounded = false;

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Ground")
        {
            Grounded = true;
        }
    }
    void OnCollisionExit2D(Collision2D col)
    {
        Grounded = false;
    }
}

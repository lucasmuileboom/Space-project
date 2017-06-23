using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColision : MonoBehaviour
{
    PlayerHealth _PlayerHealth;
    public bool Grounded = false;

    private void Awake()
    {
        _PlayerHealth = GetComponent<PlayerHealth>();
    }
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Ground")
        {
            Grounded = true;
        }
        if (coll.gameObject.tag == "Enemy")
        {
            _PlayerHealth.hit();
        }
    }
    private void OnCollisionExit2D(Collision2D col)
    {
        Grounded = false;
    }
}

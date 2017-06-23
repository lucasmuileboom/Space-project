using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private int speed = 50;

    private void Start()
    {
        Destroy(gameObject, 0.2f);
    }
    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            Destroy(gameObject, 0f);
        }
    }
}

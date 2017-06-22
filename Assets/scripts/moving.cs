using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moving : MonoBehaviour {
    [SerializeField]
    private float speed;

    private Rigidbody2D _rigidbody;
    private Vector2 _inputDirection;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();


    }
    // Update is called once per frame
    void Update () {
        float x = Input.GetAxis("Horizontal");
        _inputDirection = new Vector2(x, 0.0f);
    }
    void FixedUpdate()
    {
        // move the player using physics
        _rigidbody.AddForce(_inputDirection * speed);
    }
}

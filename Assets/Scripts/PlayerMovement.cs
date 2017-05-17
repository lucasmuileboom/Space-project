using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerInput _PlayerInput;
    private PlayerColision _PlayerColision;
    private Rigidbody2D _Rigidbody;
    private Vector2 moveposition;

    [SerializeField]private int speed;
    [SerializeField]private int jumpPower;

    //private int jumpSpeed;
    private bool jump = false;
    private bool flipped;

    void Start()
    {
        _Rigidbody = GetComponent<Rigidbody2D>();
        //jumpSpeed = speed / 10;
    }
    void Awake()
    {
        _PlayerInput = GetComponent<PlayerInput>();
        _PlayerColision = GetComponent<PlayerColision>();
    }
    void Update()
    {
        if (_PlayerColision.Grounded && jump)
        {
            jump = false;
        }

        if (!_PlayerInput.right && _PlayerInput.left)
        {
            flipL();
        }
        else if (_PlayerInput.right && !_PlayerInput.left)
        {
            flipR();
        }
    }
    void FixedUpdate()
    {
        if (_PlayerColision.Grounded)//op de grond
        {
            //_Rigidbody.drag = 25;
            if (_PlayerInput.right)//right
            {
                // _Rigidbody.AddForce(Vector2.right * Time.fixedDeltaTime * speed);
                _Rigidbody.MovePosition(new Vector2(transform.position.x + 1 * Time.fixedDeltaTime * speed, _Rigidbody.velocity.y + transform.position.y));
            }
            if (_PlayerInput.left)//left
            {
                _Rigidbody.MovePosition(new Vector2(transform.position.x - 1 * Time.fixedDeltaTime * speed, _Rigidbody.velocity.y + transform.position.y));
                //_Rigidbody.AddForce(Vector2.left * Time.fixedDeltaTime * speed);
            }
            if (_PlayerInput.up && !jump)//jump
            {
                _Rigidbody.drag = 1;
                _Rigidbody.AddForce(Vector2.up * jumpPower);
                jump = true;
            }
        }
        else if (!_PlayerColision.Grounded)//in de lucht
        {
           // _Rigidbody.drag = 1;
        }
    }
    private void flipL()
    {
        transform.rotation = Quaternion.Euler(0, 180, 0);
    }
    private void flipR()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}

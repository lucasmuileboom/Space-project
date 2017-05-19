using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerInput _PlayerInput;
    private PlayerColision _PlayerColision;
    private Vector2 moveVector;
    private Vector2 jumpReset;

    private int jumpForce = 15;
    private int moveSpeedMax = 10;
    private float moveSpeed = 1;
    private float gravity = 0.4f;
    private float jumpForceCurrent;
    private float moveSpeedCurrent;
    private float moveSpeedDecFactor;
    private bool jumping = false;

    private void Awake()
    {
        _PlayerInput = GetComponent<PlayerInput>();
        _PlayerColision = GetComponent<PlayerColision>();
    }
    private void Update()
    {
        if (_PlayerColision.Grounded && jumping)
        {
            jumping = false;
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
    private void FixedUpdate()
    {
        if (_PlayerInput.left)//left
        {
            flipL();
            moveLeft();
        }
        else if (_PlayerInput.right)//right
        {
            flipR();
            moveRight();            
        }
        else//idle
        {
            idle();            
        }
        if (_PlayerInput.up)//jump
        {
            if (!jumping && _PlayerColision.Grounded)
            {
                jump();
                
            }
        }
        if (_PlayerInput.down)//bukken
        {
            crouch();
        }
        if (!_PlayerInput.down)//stand up
        {
            standUp();
        }
        if (!_PlayerColision.Grounded)//air
        {
            jumpForceCurrent -= gravity;
            moveSpeed = 0.1f;
            moveSpeedDecFactor = 0.90f;
        }
        else if (_PlayerColision.Grounded)//grounded
        {
            jumping = false;
            jumpForceCurrent = 0;
            moveSpeed = 1;
            moveSpeedDecFactor = 0.50f;            
        }
        moveVector = new Vector2(moveSpeedCurrent, jumpForceCurrent);
        transform.Translate(moveVector * Time.deltaTime);
    }
    private void flipL()
    {
        transform.rotation = Quaternion.Euler(0, 180, 0);
    }
    private void flipR()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
    private void crouch()
    {
      
    }
    private void standUp()
    {

    }
    private void moveLeft()
    {
        moveSpeedCurrent += moveSpeed;
        if (moveSpeedCurrent >= moveSpeedMax)
        {
            moveSpeedCurrent = moveSpeedMax;
        }
    }
    private void moveRight()
    {
        moveSpeedCurrent += moveSpeed;
        if (moveSpeedCurrent >= moveSpeedMax)
        {
            moveSpeedCurrent = moveSpeedMax;
        }
    }
    private void jump()
    {
        jumpForceCurrent += jumpForce;
        jumping = true;
        _PlayerColision.Grounded = false;
        moveSpeedCurrent = moveSpeedCurrent / 2;
    }
    private void idle()
    {
        moveSpeedCurrent *= moveSpeedDecFactor;
        if (moveSpeedCurrent >= -moveSpeed && moveSpeedCurrent <= moveSpeed)
        {
            moveSpeedCurrent = 0;
        }
    }
}

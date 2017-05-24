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
    private bool jumping = false;
    private bool flipped = false;
    private float moveSpeed = 1;
    private float airMoveSpeed = 0.1f;
    private float gravity = 0.4f;
    private float jumpForceCurrent;
    private float moveSpeedCurrent;
    private float moveSpeedDecFactor;
    
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
            moveSpeedDecFactor = 0.90f;
        }
        else if (_PlayerColision.Grounded)//grounded
        {
            jumping = false;
            jumpForceCurrent = 0;
            moveSpeedDecFactor = 0.50f;            
        }
        moveVector = new Vector2(moveSpeedCurrent, jumpForceCurrent);
        transform.Translate(moveVector * Time.deltaTime);
    }
    private void flipL()
    {
        if (!flipped)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            moveSpeedCurrent = -moveSpeedCurrent;
            flipped = true;
        } 
    }
    private void flipR()
    {
        if (flipped)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            moveSpeedCurrent = -moveSpeedCurrent;
            flipped = false;
        }       
    }    
    private void moveLeft()
    {
        if (_PlayerColision.Grounded)
        {
            moveSpeedCurrent += moveSpeed;
        }
        else if (!_PlayerColision.Grounded)
        {
            moveSpeedCurrent += airMoveSpeed;
        }
        if (moveSpeedCurrent >= moveSpeedMax)
        {
            moveSpeedCurrent = moveSpeedMax;
        }
    }
    private void moveRight()
    {
        if (_PlayerColision.Grounded)
        {
            moveSpeedCurrent += moveSpeed;
        }
        else if (!_PlayerColision.Grounded)
        {
            moveSpeedCurrent += airMoveSpeed;
        }
        if (moveSpeedCurrent >= moveSpeedMax)
        {
            moveSpeedCurrent = moveSpeedMax;
        }
    }
    private void crouch()
    {

    }
    private void standUp()
    {

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

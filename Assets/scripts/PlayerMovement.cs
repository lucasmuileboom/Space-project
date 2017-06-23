using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //hit
    //death
    Animator animatie;
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
    
        //SetInt("Speed", move);
    
    private void Awake()
    {
        _PlayerInput = GetComponent<PlayerInput>();
        _PlayerColision = GetComponent<PlayerColision>();
    }
    private void Start()
    {
       animatie = GetComponent<Animator>();
    }
    private void Update()
    {
        if (!_PlayerInput.right && _PlayerInput.left)
        {
            flipL();
        }
        else if (_PlayerInput.right && !_PlayerInput.left)
        {
            flipR();
        }
        if (jumpForceCurrent > 0)
        {
            animatie.SetBool("jumpUp", true);
            animatie.SetBool("jumpDown", false);
        }
        else if (jumpForceCurrent < 0)
        {
            animatie.SetBool("jumpUp", false);
            animatie.SetBool("jumpDown", true);
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
            animatie.SetBool("grounded", false);
            jumping = true;
            jumpForceCurrent -= gravity;
            moveSpeedDecFactor = 0.99f;
        }
        else if (_PlayerColision.Grounded)//grounded
        {
            animatie.SetBool("jumpUp", false);
            animatie.SetBool("jumpDown", false);
            animatie.SetBool("grounded", true);
            jumping = false;
            jumpForceCurrent = 0;
            moveSpeedDecFactor = 0.3f;            
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
        animatie.SetBool("move", true);
        animatie.SetBool("idle", false);
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
        animatie.SetBool("move", true);
        animatie.SetBool("idle", false);
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
    private void jump()
    {
        animatie.SetBool("idle", false);
        jumpForceCurrent += jumpForce;
        jumping = true;
        _PlayerColision.Grounded = false;
        moveSpeedCurrent = moveSpeedCurrent / 2;
    }
    private void crouch()
    {

    }
    private void standUp()
    {

    }
    private void idle()
    {
        animatie.SetBool("idle", true);
        animatie.SetBool("move", false);
        moveSpeedCurrent *= moveSpeedDecFactor;
        if (moveSpeedCurrent >= -moveSpeed && moveSpeedCurrent <= moveSpeed)
        {
            moveSpeedCurrent = 0;
        }
    }
}

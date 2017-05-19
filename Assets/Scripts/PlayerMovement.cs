using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerInput _PlayerInput;
    private PlayerColision _PlayerColision;
    private Vector2 moveVector;
    private Vector2 jumpReset;

    private int jumpForce;
    private float moveSpeed = 1;
    private int moveSpeedMax = 10;
    private float gravity = 0.4f;
    private float jumpForceCurrent;
    private float moveSpeedCurrent;
    private float moveSpeedDecFactor;
    private bool jump = false;
    private bool flipped;

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
        if (_PlayerInput.left)//left
        {
            flipL();
            moveSpeedCurrent += moveSpeed;
            if (moveSpeedCurrent >= moveSpeedMax)
            {
                moveSpeedCurrent = moveSpeedMax;
            }
        }
        else if (_PlayerInput.right)//right
        {
            flipR();
            moveSpeedCurrent += moveSpeed;
            if (moveSpeedCurrent >= moveSpeedMax)
            {
                moveSpeedCurrent = moveSpeedMax;
            }
        }
        else//decreased movement
        {
            moveSpeedCurrent *= moveSpeedDecFactor;
            if (moveSpeedCurrent >= -moveSpeed && moveSpeedCurrent <= moveSpeed)
            {
                moveSpeedCurrent = 0;
            }
        }
        if (_PlayerInput.up)//jumping
        {
            if (!jump && _PlayerColision.Grounded)
            {
                jumpForceCurrent += jumpForce;
                jump = true;
                _PlayerColision.Grounded = false;
                moveSpeedCurrent = moveSpeedCurrent / 2;
            }
        }
        if (!_PlayerColision.Grounded)//air
        {
            jumpForceCurrent -= gravity;
            moveSpeed = 0.1f;
            moveSpeedDecFactor = 0.90f;
        }
        else if (_PlayerColision.Grounded)//ground
        {
            jump = false;
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
}

﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{

    private IEnemyState currentState;

    public GameObject Target { get; set; }

    [SerializeField]
    private float meleeRange;

    public bool InMeleeRange
    {
        get
        {
            if(Target != null)
            {
                return Vector2.Distance(transform.position, Target.transform.position) <= meleeRange;
            }

            return false;
        }
    }

    public override bool IsDead
    {
        get
        {
            return healt <= 0;
        }
    }

    public override void Start()
    {
        base.Start();
        ChangeState(new Enemy_idle());
    }

    void Update()
    {
        if (!IsDead)
        {
            currentState.Excute();
            LookAtTarget();
        }
        
    }


    private void LookAtTarget()
    {
        if (Target != null)
        {
            float xDir = Target.transform.position.x - transform.position.x;

            if (xDir < 0 && facingRight || xDir > 0 && !facingRight)
            {
                ChangeDirection();
            }
        }
    }

    public void ChangeState(IEnemyState newState)
    {
      if(currentState != null)
        {
            currentState.Exit();
        }

        currentState = newState;

        currentState.Enter(this);
    }

    public Vector2 GetDirection()
    {
        return facingRight ? Vector2.right : Vector2.left;
    }

    public void Move()
    {
        if(!Attack)
        {
            MyAnimator.SetFloat("speed", 1);

            transform.Translate(GetDirection() * (Speed * Time.deltaTime));

        }
    }

    public override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
        currentState.OnTriggerEnter(other);
    }

    public override IEnumerator TakeDamge()
    {
        healt -= 10;

        if (!IsDead)
        {
            MyAnimator.SetTrigger("damage");
        }
        else
        {
            MyAnimator.SetTrigger("dead");
            yield return null;
        }
    }
}

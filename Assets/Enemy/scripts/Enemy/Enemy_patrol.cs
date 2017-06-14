﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_patrol : IEnemyState
{
    private Enemy enemy;

    private float patrolTimer;

    private float patrolDuration = 1;

    public void Enter(Enemy enemy)
    {
        this.enemy = enemy;
    }

    public void Excute()
    {
        patrol();

        enemy.Move();
        if (enemy.Target != null && enemy.InMeleeRange)
        {
            enemy.ChangeState(new Enemy_mellee());
        }
    }

    public void Exit()
    {

    }

    public void OnTriggerEnter(Collider2D other)
    {
        if(other.tag == "Edge")
        {
            enemy.ChangeDirection();
            enemy.Target = null;
        }
    }

    private void patrol()
    {
        patrolTimer += Time.deltaTime;

        if (patrolTimer >= patrolDuration)
        {
            //enemy.MyAnimator.SetFloat("speed", 0);
            enemy.ChangeState(new Enemy_idle());
            patrolTimer = 0;
        }
    }
}

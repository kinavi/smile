﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.EventArgs;

public class Enemy : MonoBehaviour
{
    protected Vector3 TargetDirection;
    //public delegate void PlayerHandler(Enemy enemy, EnemyEventArgs args);
    //public event PlayerHandler Attack;
    protected float Healht;
    protected float Damage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //if(Attack!=null) Attack(this, new EnemyEventArgs(EnemyType.Simple, Damage));
            //CustomEventSystem.AttackTheHero(Damage);
            collision.gameObject.SendMessage("TakeDamage", new EnemyEventArgs(EnemyType.Simple, Damage,transform.position));

        }
    }


}

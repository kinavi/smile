using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.EventArgs;

public class Enemy : MonoBehaviour
{
    public delegate void PlayerHandler(Enemy enemy, EnemyEventArgs args);
    public event PlayerHandler Attack;

    public float Damage;

    // Start is called before the first frame update
    void Start()
    {
        Damage = 5;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if(Attack!=null) Attack(this, new EnemyEventArgs(EnemyType.Simple, Damage));
            //CustomEventSystem.AttackTheHero(Damage);
        }
    }


}

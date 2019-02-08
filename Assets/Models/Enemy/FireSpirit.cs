using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.EventArgs;

public class FireSpirit : Enemy
{
    public GameObject PrefabProjectile;

    public int LimitProjectile;

    public FireBoll[] fireBolls;

    public float SpeedAttack;
    private float TimeAttack;

    public bool IsShooting;

    // Start is called before the first frame update
    void Start()
    {
        IsShooting = false;
        fireBolls = gameObject.GetComponentsInChildren<FireBoll>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(fireBolls.Length != LimitProjectile)
        {

        }

        if (IsShooting)
        {
            if ((Time.time >= TimeAttack + SpeedAttack)&& fireBolls.Length!=0)
            {
                TimeAttack = Time.time;

                foreach(FireBoll fireBoll in fireBolls)
                {
                    fireBoll.Shot(TargetDirection);
                }
                //Instantiate<GameObject>(Hit, (transform.position + TargetDirection.normalized), TargetRotation.normalized).GetComponent<Bolt>().Shot(TargetDirection);
                //* DistanceStartBolt//
            }

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //if(Attack!=null) Attack(this, new EnemyEventArgs(EnemyType.Simple, Damage));
            //CustomEventSystem.AttackTheHero(Damage);
            collision.gameObject.SendMessage("TakeDamage", new EnemyEventArgs(EnemyType.Simple, Damage, transform.position));

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            TargetDirection = collision.gameObject.transform.position - transform.position;
            //TargetRotation = Quaternion.LookRotation(TargetDirection, Vector3.down);
            IsShooting = true;
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            TargetDirection = collision.gameObject.transform.position - transform.position;
            //TargetRotation = Quaternion.LookRotation(Vector3.down, TargetDirection);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            IsShooting = false;
    }
}

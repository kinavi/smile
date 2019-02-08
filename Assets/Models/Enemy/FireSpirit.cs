using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.EventArgs;

public class FireSpirit : Enemy
{
    public GameObject PrefabProjectile;
    public Vector3[] StarPosition;

    public float CooldownSpawnProjectile;

    public List<FireBoll> fireBolls;
    //public FireBoll[] fireBolls;

    public float SpeedAttack;
    private float CooldownAttack;

    public bool IsShooting;

    // Start is called before the first frame update
    void Start()
    {
        CooldownAttack = SpeedAttack;

        Charging();
    }

    // Update is called once per frame
    void Update()
    {
        if (fireBolls.Count == 0)
        {
            CooldownSpawnProjectile -= Time.deltaTime;

            if (CooldownSpawnProjectile < 0)
                Charging();
        }

        if (IsShooting && fireBolls.Count != 0)
        {
            Shooting();
        }
    }

    private void Charging()
    {
        foreach (Vector3 pos in StarPosition)
        {
            fireBolls.Add(Instantiate<GameObject>(PrefabProjectile, transform.position + pos, Quaternion.identity, gameObject.transform).GetComponent<FireBoll>());
        }

        //fireBolls = gameObject.GetComponentsInChildren<FireBoll>();
    }


    private void Shooting()
    {
        CooldownAttack -= Time.deltaTime;

        if (CooldownAttack < 0)
        {
            CooldownAttack = SpeedAttack;

            fireBolls[fireBolls.Count-1].Shot(TargetDirection);

            fireBolls.Remove(fireBolls[fireBolls.Count - 1]);
            //foreach (FireBoll fireBoll in fireBolls)///------
            //{
            //    fireBoll.Shot(TargetDirection);
            //}
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

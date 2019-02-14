using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.EventArgs;

public class FireSpirit : Enemy
{
    public GameObject PrefabProjectile;
    public Vector3[] StarPosition;

    public float CooldownSpawnProjectile;
    public float TimerCooldownSpawnProjectile;

    public List<FireBoll> fireBolls;

    public float SpeedAttack;
    public float CooldownAttack;

    public bool IsShooting;

    public BarUI HealthBar;

    // Start is called before the first frame update
    void Start()
    {
        curHealth = maxHealth;
        if(HealthBar != null)
        {
            HealthBar = GetComponentInChildren<BarUI>();
            HealthBar.SetValue(maxHealth);
        }
        

        //CooldownAttack = SpeedAttack;
        TimerCooldownSpawnProjectile = CooldownSpawnProjectile;

        Charging();
    }

    // Update is called once per frame
    void Update()
    {
        if (fireBolls.Count == 0)
        {
            TimerCooldownSpawnProjectile -= Time.deltaTime;

            //float currentTime=Time.time;

            if (TimerCooldownSpawnProjectile < 0)//Time.time >= currentTime + CooldownSpawnProjectile)
            {
                TimerCooldownSpawnProjectile = CooldownSpawnProjectile;
                Charging();
            }
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
            CooldownAttack = 0;
        }
    }


    private void Shooting()
    {
        CooldownAttack -= Time.deltaTime;

        if (CooldownAttack < 0)
        {
            CooldownAttack = SpeedAttack;

            fireBolls[fireBolls.Count-1].Shot(TargetDirection);

            fireBolls.Remove(fireBolls[fireBolls.Count - 1]);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.SendMessage("Damage", new EnemyEventArgs(EnemyType.Simple, DamagePoint, transform.position));

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            TargetDirection = collision.gameObject.transform.position - transform.position;
            IsShooting = true;
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            TargetDirection = collision.gameObject.transform.position - transform.position;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            IsShooting = false;
    }

    public void Damage(float damage)
    {
        curHealth -= damage;
        if(HealthBar != null)
        {
            HealthBar.СhangeValue(curHealth);
        }
    }
}

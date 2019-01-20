using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Models;
using Assets.EventArgs;

public class Player : MonoBehaviour
{
    //public float InputX;
    //public float InputY;
    //public bool IsWayDiagon;

    public delegate void EnemyHandler();
    public event EnemyHandler Attack;

    public float Health;
    private Rigidbody2D rigidbody;

    

    public float Speed;

    // Start is called before the first frame update
    void Start()
    {
        Health = 10; 
        Speed = 10;
        rigidbody = GetComponent<Rigidbody2D>();

        //CustomEventSystem.TakingDamage += DecreasedHealthPerUnit;
        //Enemy.Attack += TakeDamage;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Horizontal")|| Input.GetButton("Vertical"))
        {
            float x = Input.GetAxisRaw("Horizontal") * Time.deltaTime * Speed;
            float y = Input.GetAxisRaw("Vertical") * Time.deltaTime * Speed;

            if (Input.GetButton("Horizontal") && Input.GetButton("Vertical"))
            {
                x = x * 0.7f;
                y = y * 0.7f;
            }

            Vector3 direction = new Vector3(x, y);
            Vector3 newPosition = direction + transform.position;
            Debug.Log(Vector3.Distance(newPosition, transform.position) / Time.deltaTime);
            rigidbody.MovePosition(newPosition);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="HealthPotion")
        {
            //Анимация лечения

            Health += collision.GetComponent<HealthPotionSmall>().Points;
            Debug.Log("HP +" + collision.GetComponent<HealthPotionSmall>().Points);
            Debug.Log("HP ="+ Health);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Enemy")
        {
            collision.gameObject.GetComponent<Enemy>().Attack += TakeDamage;
            //Толчек 
            //Ранение

        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemy>().Attack -= TakeDamage;
            //Толчек 
            //Ранение

        }
    }

    public void DecreasedHealthPerUnit(float unit)
    {
        Health -= unit;
        Debug.Log("Health = " + Health);
        //проверка на смерть
        if(Health<=0)
        {
            //Срабатывает событие смерти
            Destroy(gameObject);
            CustomEventSystem.SendHeroeIsDeath();
        }
    }

    public void TakeDamage(Enemy enemy, EnemyEventArgs args)
    {
        switch(args.Type)
        {
            case EnemyType.Simple:
                Health -= args.Damage;
                break;
        }
    }
}

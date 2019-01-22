using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Models;
using Assets.EventArgs;

public class Player : MonoBehaviour
{
    #region Сharacteristics 
    public float Health;
    public float Speed;

    [SerializeField]
    private float ForcePush;

    [SerializeField]
    private float Bash;//Сила толчка завист от силы удара. Надо сделать
    #endregion

    public bool IsFreeze;

    private Rigidbody2D rigidbody;

    private void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        Health = 10; 
        Speed = 10;
        ForcePush = 10;
        Bash = 0.2f;

        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!IsFreeze && (Input.GetButton("Horizontal")|| Input.GetButton("Vertical")))
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
            //Debug.Log(Vector3.Distance(newPosition, transform.position) / Time.deltaTime);
            rigidbody.MovePosition(newPosition);
        }
    }

    

    public void SimpleWound(float value)
    {
        Health -= value;
        Debug.Log("Health = " + Health);
        //проверка на смерть
        if (Health <= 0)
        {
            //Срабатывает событие смерти
            Destroy(gameObject);
            //CustomEventSystem.SendHeroeIsDeath();
        }

    }

    public void SympleHealing(float value)
    {
        Health += value;
        Debug.Log("HP +" + value);
        Debug.Log("HP =" + Health);
    }

    void GetPush(Vector3 EnemyPosition)
    {
        Vector3 dirCollision = -(EnemyPosition - transform.position);
        rigidbody.AddForce((dirCollision.normalized) * ForcePush, ForceMode2D.Impulse);
    }
    

    void GetBush()
    {
        StartCoroutine(WaitAndPrint(Bash));
    }


    private IEnumerator WaitAndPrint(float waitTime)
    {
        IsFreeze = true;
        yield return new WaitForSeconds(waitTime);
        IsFreeze = false;
    }

    public void TakeDamage(EnemyEventArgs args)
    {
        switch (args.Type)
        {
            case EnemyType.Simple:
                SimpleWound(args.Damage);
                GetPush(args.Position);
                GetBush();
                Debug.Log(" - " + args.Damage + " hp");
                break;
        }
    }


    public void DrinkElixir(ElixirEventArgs args)
    {
        switch (args.Type)
        {
            case ElixirType.Helth:
                SympleHealing(args.Points);
                Debug.Log(" + " + args.Points + " hp");
                break;
        }
    }

    //public CheckDeath()
    //{

    //}

    #region Events
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.tag == "HealthPotion")
        //{
        //    DrinkElixir
        //}
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {

            //collision.gameObject.GetComponent<Enemy>().Attack += TakeDamage;
            //Толчек 
            //Ранение

        }
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {

            //collision.gameObject.GetComponent<Enemy>().Attack -= TakeDamage;
            //Толчек 
            //Ранение

        }
    }
    #endregion
}

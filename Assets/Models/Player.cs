using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.EventArgs;
using System;

public class Player : MonoBehaviour
{
    #region Сharacteristics 
    public float Health;
    public float Speed;
    #endregion

    #region State
    /// <summary>
    /// Блокировка движения на время
    /// </summary>
    [SerializeField]
    private float Bash;


    #endregion

    #region Moving
    /// <summary>
    /// Сила толчка при столкновении
    /// </summary>
    [SerializeField]
    private float ForcePush;//Сила толчка завист от силы удара. Надо сделать

    /// <summary>
    /// Состояние движения (true - полная блокировка)
    /// </summary>
    private bool IsFreeze;
    #endregion

    #region Hit

    public GameObject Hit;

    Quaternion right = Quaternion.Euler(0, 0, -45f);
    Quaternion left = Quaternion.Euler(180f, 0, 135f);
    Quaternion up = Quaternion.Euler(0, 0, 45f);
    Quaternion down = Quaternion.Euler(180f, 0, 45f);

    public float SpeedAttack;
    private float TimeAttack;

    public float DistanceAttack;
    #endregion

    [SerializeField]
    private Vector3 Direction;

    private Rigidbody2D rb;

    //AnimationControllerHero CustomAnimationController;

    #region Animation
    public delegate void MoveHandler(Vector3 Direction);
    public event MoveHandler OnMove;
    public event MoveHandler OnStay;
    public event MoveHandler OnHit;
    #endregion

    //[SerializeField]
    //bool BehindTheBack;

    //[SerializeField]
    //bool InHand;

    private void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        Health = 10;
        Speed = 5;// 10;
        ForcePush = 50;
        Bash = 0.2f;

        rb = GetComponent<Rigidbody2D>();
        //rigidbody.
    }

    // Update is called once per frame
    void Update()
    {
        if (IsFreeze)
        {
            OnStay(Direction);
        }

        if (!IsFreeze && (Input.GetButton("Horizontal")|| Input.GetButton("Vertical")))
        {
            float x = Input.GetAxisRaw("Horizontal");
            float y = Input.GetAxisRaw("Vertical");

            Direction = new Vector3(x, y).normalized; //* Time.deltaTime * Speed;

            Vector3 Distance = Direction * Time.deltaTime * Speed;

            Vector3 Target = transform.position + Distance;

            //Debug.Log(Vector3.Distance(newPosition, transform.position) / Time.deltaTime);

            rb.MovePosition(Target);

            OnMove(Direction);
        }
        else
            OnStay(Direction);

        if(Input.GetButtonDown("Jump")&&Time.time > TimeAttack + SpeedAttack)
        {
            //IsFreeze = true;
            GetFreezeForSec(SpeedAttack);

            TimeAttack = Time.time;

            if (Direction == Vector3.left)
                Instantiate<GameObject>(Hit, transform.position + Direction * DistanceAttack, left);//* 0.6f
            if (Direction == Vector3.right)
                Instantiate<GameObject>(Hit, transform.position + Direction * DistanceAttack, right);
            if (Direction == Vector3.up)
                Instantiate<GameObject>(Hit, transform.position + Direction * DistanceAttack, up);
            if (Direction == Vector3.down)
                Instantiate<GameObject>(Hit, transform.position + Direction * DistanceAttack, down);

            OnHit(Direction);
        }
        
    }


    public void SimpleWound(float value)
    {
        OnMove(Direction);
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
        Debug.Log("HP +" + value+ " = " + Health);
    }

    void GetPush(Vector3 EnemyPosition)
    {
        Vector3 dirCollision = -(EnemyPosition - transform.position);
        rb.AddForce((dirCollision.normalized) * ForcePush, ForceMode2D.Impulse);
    }
    
    void GetFreezeForSec(float time)
    {
        StartCoroutine(WaitAndPrint(time));
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

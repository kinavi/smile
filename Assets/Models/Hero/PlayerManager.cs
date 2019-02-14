using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.EventArgs;

public enum Direction { Up, Right, Down, Left, UpLeft, UpRight, DownLeft, DownRight }

public class PlayerManager : MonoBehaviour
{
    //public delegate void ChangeHealthHandler(float Ratios);
    //public static event ChangeHealthHandler ReduceHealth;
    //public static event ChangeHealthHandler IncreaseHealth;

    public float curHealth;
    public float maxHealth;

    public float DamagePoint;

    public static Direction direction;

    public BarUI HealthBar;

    private Rigidbody2D rigidbody;

    [SerializeField]
    private float ForcePush;

    void Start()
    {
        curHealth = maxHealth;
        HealthBar.SetValue(maxHealth);

        rigidbody = GetComponent<Rigidbody2D>();
        //HealthBar = new BarUI(curHealth, maxHealth);

        InputController.OnMoveUp += () => direction = Direction.Up;
        InputController.OnMoveUpRight += () => direction = Direction.UpRight;
        InputController.OnMoveRight += () => direction = Direction.Right;
        InputController.OnMoveDownRight += () => direction = Direction.DownRight;
        InputController.OnMoveDown += () => direction = Direction.Down;
        InputController.OnMoveDownLeft += () => direction = Direction.DownLeft;
        InputController.OnMoveLeft += () => direction = Direction.Left;
        InputController.OnMoveUpLeft += () => direction = Direction.UpLeft;
    }

    void OnDestroy()
    {
        InputController.OnMoveUp -= () => direction = Direction.Up;
        InputController.OnMoveUpRight -= () => direction = Direction.UpRight;
        InputController.OnMoveRight -= () => direction = Direction.Right;
        InputController.OnMoveDownRight -= () => direction = Direction.DownRight;
        InputController.OnMoveDown -= () => direction = Direction.Down;
        InputController.OnMoveDownLeft -= () => direction = Direction.DownLeft;
        InputController.OnMoveLeft -= () => direction = Direction.Left;
        InputController.OnMoveUpLeft -= () => direction = Direction.UpLeft;
    }

    public void Damage(EnemyEventArgs args)
    {
        switch (args.Type)
        {
            case EnemyType.Simple:
                curHealth -= args.Damage;
                HealthBar.СhangeValue(curHealth);
                //ReduceHealth(curHealth/maxHealth);
                //SimpleWound(args.Damage);s
                GetPush(args.Position);
                //GetBush();
                Debug.Log(" - " + args.Damage + " hp");
                break;
        }
    }

    void GetPush(Vector3 EnemyPosition)
    {
        Vector3 dirCollision = -(EnemyPosition - transform.position);
        rigidbody.AddForce((dirCollision.normalized) * ForcePush, ForceMode2D.Impulse);
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.SendMessage("Damage", DamagePoint);
        }
    }

}

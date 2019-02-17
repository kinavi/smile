using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.EventArgs;

public enum Direction { Up, Right, Down, Left, UpLeft, UpRight, DownLeft, DownRight }

public class PlayerManager : MonoBehaviour
{
    public float curHealth;
    public float maxHealth;

    public float DamagePoint;

    public static Direction direction;

    public BarUI HealthBar;

    private Rigidbody2D rb;

    public float ForcePush;

    //public float BushTime;

    PlayerEngineController engineController;

    void Start()
    {
        engineController = GetComponent<PlayerEngineController>();
        curHealth = maxHealth;
        HealthBar.SetValue(maxHealth);

        rb = GetComponent<Rigidbody2D>();

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
                GetPush(args.Position);
                Debug.Log(" - " + args.Damage + " hp");
                break;
            case EnemyType.FireBoll:
                curHealth -= args.Damage;
                HealthBar.СhangeValue(curHealth);
                break;
        }
    }

    void GetPush(Vector3 EnemyPosition)
    {
        Vector3 dirCollision = -(EnemyPosition - transform.position);
        rb.AddForce((dirCollision.normalized) * ForcePush*Time.deltaTime, ForceMode2D.Impulse);
        StartCoroutine("WaitEndPushEffect");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.SendMessage("Damage", DamagePoint);
        }
    }

    //void GetBush()
    //{
    //    StartCoroutine(WaitAndPrint(BushTime));
    //}

    //private IEnumerator WaitAndPrint(float waitTime)
    //{
    //    engineController.IsFreeze = true;
    //    yield return new WaitForSeconds(waitTime);
    //    engineController.IsFreeze = false;
    //}

    private IEnumerator WaitEndPushEffect()
    {
        engineController.IsFreeze = true;
        while(rb.velocity!=Vector2.zero)
        {
            yield return null;
        }
        engineController.IsFreeze = false;
    }
}

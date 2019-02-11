using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.EventArgs;

public enum Direction { Up, Right, Down, Left, UpLeft, UpRight, DownLeft, DownRight }

public class PlayerManager : MonoBehaviour
{
    public float curHealth;
    public float maxHealth;

    public static Direction direction;

    void Start()
    {
        curHealth = maxHealth;

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

                //SimpleWound(args.Damage);
                //GetPush(args.Position);
                //GetBush();
                Debug.Log(" - " + args.Damage + " hp");
                break;
        }
    }

}

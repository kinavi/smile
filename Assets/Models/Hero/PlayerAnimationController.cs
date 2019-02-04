using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private Animator animator;

    public Direction direction = Direction.Down;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        InputController.OnMoveDown += MoveDown;
        InputController.OnMoveUp += MoveUp;
        InputController.OnMoveLeft += OnMoveLeft;
        InputController.OnMoveRight += MoveRight;

        InputController.NotMove += OnStay;

    }

    private void OnDestroy()
    {
        InputController.OnMoveDown -= MoveDown;
        InputController.OnMoveUp -= MoveUp;
        InputController.OnMoveLeft -= OnMoveLeft;
        InputController.OnMoveRight -= MoveRight;

        InputController.NotMove -= OnStay;
    }

    void MoveUp()
    {
        direction = Direction.Up;
        animator.Play("PlayerV2_walk_up");
    }

    void MoveRight()
    {
        direction = Direction.Right;
        animator.Play("PlayerV2_walk_right");
    }

    void MoveDown()
    {
        direction = Direction.Down;
        animator.Play("PlayerV2_walk_down");
    }

    void OnMoveLeft()
    {
        direction = Direction.Left;
        animator.Play("PlayerV2_walk_left");
    }


    void OnStay()
    {
        switch (direction)
        {
            case Direction.Up:
                animator.Play("PlayerV2_stay_up");
                break;
            case Direction.Right:
                animator.Play("PlayerV2_stay_right");
                break;
            case Direction.Down:
                animator.Play("PlayerV2_stay_down");
                break;
            case Direction.Left:
                animator.Play("PlayerV2_stay_left");
                break;
        }
    }
}

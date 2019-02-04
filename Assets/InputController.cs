using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


class InputController:MonoBehaviour
{
    public delegate void InputHandler();
    public static event InputHandler OnMove;

    public static event InputHandler OnMoveUp;
    public static event InputHandler OnMoveRight;
    public static event InputHandler OnMoveDown;
    public static event InputHandler OnMoveLeft;

    public static event InputHandler OnMoveUpLeft;
    public static event InputHandler OnMoveUpRight;
    public static event InputHandler OnMoveDownRight;
    public static event InputHandler OnMoveDownLeft;

    public static event InputHandler NotMove;

    public static event InputHandler OnHit;

    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            OnMove();
            OnMoveUp();

            if (Input.GetKey(KeyCode.D))
                OnMoveUpRight();
            if (Input.GetKey(KeyCode.A))
                OnMoveUpLeft();
        }
        if (Input.GetKey(KeyCode.S))
        {
            OnMove();
            OnMoveDown();

            if (Input.GetKey(KeyCode.D))
                OnMoveDownRight();
            if (Input.GetKey(KeyCode.A))
                OnMoveDownLeft();
        }
        if (Input.GetKey(KeyCode.D) && !(Input.GetKey(KeyCode.W)) && !Input.GetKey(KeyCode.S))
        {
            OnMove();
            OnMoveRight();
        }
        if (Input.GetKey(KeyCode.A) && !(Input.GetKey(KeyCode.W)) && !Input.GetKey(KeyCode.S))
        {
            OnMove();
            OnMoveLeft();
        }
        if (!Input.anyKey)
        {
            NotMove();
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            OnHit();
        }

    }



}

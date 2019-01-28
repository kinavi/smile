using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Models.Experiment
{
    class InputHandler:MonoBehaviour
    {
        //The box we control with keys
        public Transform boxTrans;

        public float Speed;

        //The different keys we need
        private Command buttonW, buttonS, buttonA, buttonD, buttonB, buttonZ, buttonR;
        //Stores all commands for replay and undo
        public static List<Command> oldCommands = new List<Command>();
        //Box start position to know where replay begins
        private Vector3 boxStartPos;
        //To reset the coroutine
        private Coroutine replayCoroutine;
        //If we should start the replay
        public static bool shouldStartReplay;
        //So we cant press keys while replaying
        private bool isReplaying;        

        private void Start()
        {
            buttonA = new MoveLeft(Speed);
            buttonD = new MoveRight(Speed);
            buttonW = new MoveUp(Speed);
            buttonS = new MoveBack(Speed);
            buttonZ = new ReplayCommand();

            boxStartPos = boxTrans.position;
        }


        private void Update()
        {
            if (!isReplaying)
            {
                HandleInput();
            }

            StartReplay();
        }

        //Check if we press a key, if so do what the key is binded to 
        public void HandleInput()
        {
            if (Input.GetKey(KeyCode.A))
            {
                buttonA.Execute(boxTrans, buttonA);
            }
            if (Input.GetKey(KeyCode.B))
            {
                buttonB.Execute(boxTrans, buttonB);
            }
            if (Input.GetKey(KeyCode.D))
            {
                buttonD.Execute(boxTrans, buttonD);
            }
            if (Input.GetKey(KeyCode.R))
            {
                buttonR.Execute(boxTrans, buttonZ);
            }
            if (Input.GetKey(KeyCode.S))
            {
                buttonS.Execute(boxTrans, buttonS);
            }
            if (Input.GetKey(KeyCode.W))
            {
                buttonW.Execute(boxTrans, buttonW);
            }
            if (Input.GetKey(KeyCode.Z))
            {
                buttonZ.Execute(boxTrans, buttonZ);
            }
        }

        //Checks if we should start the replay
        void StartReplay()
        {
            if (shouldStartReplay && oldCommands.Count > 0)
            {
                shouldStartReplay = false;

                //Stop the coroutine so it starts from the beginning
                if (replayCoroutine != null)
                {
                    StopCoroutine(replayCoroutine);
                }

                //Start the replay
                replayCoroutine = StartCoroutine(ReplayCommands(boxTrans));
            }
        }

        //The replay coroutine
        private IEnumerator ReplayCommands(Transform boxTrans)
        {
            //So we can't move the box with keys while replaying
            isReplaying = true;

            //Move the box to the start position
            boxTrans.position = boxStartPos;

            for (int i = 0; i < oldCommands.Count; i++)
            {
                //Move the box with the current command
                oldCommands[i].Move(boxTrans);

                yield return null;//new WaitForSeconds(0.3f);
            }

            //We can move the box again
            isReplaying = false;
        }
    }
}

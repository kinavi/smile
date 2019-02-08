using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public bool IsShoot;
    public float TimeLive;
    public float SpeedBolt;

    protected Vector3 TargetDirection;
    protected float TimeStart;
    //protected float TimeEnd;

    public virtual void Shot(Vector3 targetDirection) {
        print("Выстрел");

        TargetDirection = targetDirection;

        IsShoot = true;

        //TimeStart = Time.time;
        //TimeEnd = TimeStart + TimeLive;


    }
}

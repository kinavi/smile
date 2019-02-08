using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Vector3 TargetDirection;
    public bool IsShoot;


    protected float TimeStart;
    protected float TimeEnd;

    public virtual void Shot(Vector3 targetDirection) {
        print("Выстрел");

        TargetDirection = targetDirection;

        IsShoot = true;

        TimeStart = Time.time;
        //TimeEnd = TimeStart + TimeLive;


    }
}

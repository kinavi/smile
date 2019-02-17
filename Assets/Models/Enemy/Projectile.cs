using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    protected bool IsShoot;
    public float TimeLive;
    public float SpeedBolt;

    protected Vector3 TargetDirection;

    public virtual void Shot(Vector3 targetDirection) {
        //print("Выстрел");

        TargetDirection = targetDirection;

        IsShoot = true;
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBoll : Projectile
{
    public float TimeLive;
    public float SpeedBolt;

    // Start is called before the first frame update
    void Start()
    {
        IsShoot = false;

    }

    // Update is called once per frame
    void Update()
    {
        float time = Time.time;

        if (IsShoot)
        {
            transform.SetParent(null);
            //transform.Translate(TargetDirection.normalized * SpeedBolt * Time.deltaTime);
            transform.position += TargetDirection.normalized * SpeedBolt * Time.deltaTime;
            //Vector3 direction = TargetDirection - transform.position;
            float angle = (Mathf.Atan2(TargetDirection.y, TargetDirection.x) * Mathf.Rad2Deg) + 90;//Если обхект смотрит вниз то +90, если вправо 0
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = rotation;

            if (time >= TimeStart + TimeLive)
            {
                Destroy(gameObject);
            }
        }
    }

    public override void Shot(Vector3 TargetDirection)
    {
        base.Shot(TargetDirection);
    }
}

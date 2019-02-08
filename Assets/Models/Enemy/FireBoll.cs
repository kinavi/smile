using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBoll : Projectile
{
    //float time;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (IsShoot)
        {
            transform.SetParent(null);
            transform.position += TargetDirection.normalized * SpeedBolt * Time.deltaTime;
            float angle = (Mathf.Atan2(TargetDirection.y, TargetDirection.x) * Mathf.Rad2Deg) + 90;//Если обхект смотрит вниз то +90, если вправо 0
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward); 

            TimeLive -= Time.deltaTime;

            print(TimeLive);

            if (TimeLive < 0)
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

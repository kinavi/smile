using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.EventArgs;

public class FireBoll : Projectile
{
    public float DamagePoint;

    // Update is called once per frame
    void Update()
    {
        if (IsShoot)
        {
            transform.SetParent(null);
            transform.position += TargetDirection.normalized * SpeedBolt * Time.deltaTime;
            float angle = (Mathf.Atan2(TargetDirection.y, TargetDirection.x) * Mathf.Rad2Deg) + 90;// xЕсли обхект смотрит вниз то +90, если вправо 0
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward); 

            print(TimeLive);

            Destroy(gameObject,TimeLive);
        }
    }

    public override void Shot(Vector3 TargetDirection)
    {
        base.Shot(TargetDirection);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player")
        {
            collision.gameObject.SendMessage("Damage", new EnemyEventArgs(EnemyType.FireBoll, DamagePoint, transform.position));
            Destroy(gameObject);
        }
    }
}

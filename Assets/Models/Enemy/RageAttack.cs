using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RageAttack : MonoBehaviour
{
    private Vector3 TargetDirection;
    private Quaternion TargetRotation;

    //public float DistanceStartBolt;

    public float SpeedAttack;
    private float TimeAttack;

    public GameObject Hit;



    private bool IsShooting;

    // Start is called before the first frame update
    void Start()
    {
        IsShooting = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(IsShooting)
        {
            if (Time.time >= TimeAttack + SpeedAttack)
            {
                TimeAttack = Time.time;
                Instantiate<GameObject>(Hit, (transform.position + TargetDirection.normalized), TargetRotation.normalized).GetComponent<Bolt>().Shot(TargetDirection);
                //* DistanceStartBolt//
            }
            
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player")
        {
            TargetDirection = collision.gameObject.transform.position - transform.position;
            TargetRotation = Quaternion.LookRotation(TargetDirection,Vector3.down);
            IsShooting = true;
        }
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            TargetDirection = collision.gameObject.transform.position - transform.position;
            TargetRotation = Quaternion.LookRotation(Vector3.down, TargetDirection);
        }
            
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            IsShooting = false;
    }
}

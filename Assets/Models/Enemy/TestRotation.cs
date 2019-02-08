using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRotation : MonoBehaviour
{
    public float speed = 5f;
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = target.position - transform.position;
        //transform.LookAt(direction);
        float angle = (Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg)+90;//Если обхект смотрит вниз то +90, если вправо 0
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed*Time.deltaTime);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
       if(collision.tag=="Player")
        {
            //target = collision.transform;
           
        }
      
    }
}

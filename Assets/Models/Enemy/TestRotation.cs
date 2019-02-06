using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRotation : MonoBehaviour
{

    public Vector3 tmp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //transform.LookAt(collision.transform.position - transform.position, tmp);
        //transform.LookAt(collision.transform.position, tmp);
        //transform.forward;
        //transform.Rotate((collision.transform.position - transform.position).normalized,Space.World);
        //float z = 
        //Quaternion tmp = Quaternion.LookRotation((collision.transform.position - transform.position).normalized, transform.position);
        transform.rotation = Quaternion.LookRotation((transform.position- collision.transform.position), Vector3.forward);
        transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);
        //transform.rotation = new Quaternion(0, 0, tmp.x, 0);
        //transform.Rotate(Vector3.left*Time.deltaTime);
        //transform.rotation = Quaternion.LookRotation(Vector3.down, (collision.transform.position - transform.position).normalized);//.Rotate(collision.transform.position - transform.position);
        Debug.Log("+");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Models;

public class Player : MonoBehaviour
{
    //public float InputX;
    //public float InputY;
    //public bool IsWayDiagon;

    public float Health;
    private Rigidbody2D rigidbody;

    public float Speed;

    // Start is called before the first frame update
    void Start()
    {
        Health = 10;
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Horizontal")|| Input.GetButton("Vertical"))
        {
            float x = Input.GetAxisRaw("Horizontal") * Time.deltaTime * Speed;
            float y = Input.GetAxisRaw("Vertical") * Time.deltaTime * Speed;

            if (Input.GetButton("Horizontal") && Input.GetButton("Vertical"))
            {
                x = x * 0.7f;
                y = y * 0.7f;
            }

            Vector3 direction = new Vector3(x, y);
            Vector3 newPosition = direction + transform.position;
            Debug.Log(Vector3.Distance(newPosition, transform.position) / Time.deltaTime);
            rigidbody.MovePosition(newPosition);

            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="HealthPotion")
        {
            //Анимация лечения
            Health += collision.GetComponent<HealthPotionSmall>().Points;
            Debug.Log("HP +" + collision.GetComponent<HealthPotionSmall>().Points);
            Debug.Log("HP ="+ Health);
        }
    }
}

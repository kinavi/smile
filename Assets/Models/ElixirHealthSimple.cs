using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.EventArgs;

public class ElixirHealthSimple : MonoBehaviour
{
    [SerializeField]
    private float PointHealth;

   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.gameObject.SendMessage("DrinkElixir", new ElixirEventArgs(ElixirType.Helth, PointHealth));
            RemoveItem();
        }
    }

    private void RemoveItem()
    {
        Destroy(gameObject);
    }
}

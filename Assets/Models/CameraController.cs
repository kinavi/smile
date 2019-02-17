using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //Transform transform;
    PlayerManager player;

    // Start is called before the first frame update
    void Start()
    {
        //transform = GetComponent<Transform>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();

    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = player.transform.position;
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10);
    }
}

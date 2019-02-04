using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitSimple : MonoBehaviour
{

    private Animator animator;
    private Player player;

    //Quaternion right = Quaternion.Euler(0, 0, -45f);
    //Quaternion left = Quaternion.Euler(180f, 0, 135f);
    //Quaternion up = Quaternion.Euler(0, 0, 45f);
    //Quaternion down = Quaternion.Euler(180f, 0, 45f);


    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
        animator = GetComponent<Animator>();

        //player.OnHit += HitAnimation;
    }

    private void OnDestroy()
    {
        //player.OnHit -= HitAnimation;
    }

    void HitAnimation(Vector3 Direction)
    {
        //if(direction==Vector3.left)
        //    GameObject.Instantiate<GameObject>(player.Hit, player.transform.position + direction * 0.6f, left);
        //if(direction == Vector3.right)
        //    GameObject.Instantiate<GameObject>(player.Hit, player.transform.position + direction * 0.6f, right);
        //if (direction == Vector3.up)
        //    GameObject.Instantiate<GameObject>(player.Hit, player.transform.position + direction * 0.6f, up);
        //if (direction == Vector3.down)
        //    GameObject.Instantiate<GameObject>(player.Hit, player.transform.position + direction * 0.6f, down);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

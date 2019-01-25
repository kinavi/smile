using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    //[SerializeField]
    private Player player;//Плохой тон

    //[SerializeField]
    private SpriteRenderer spriteRenderer;

    public Vector3 OffsetPosition_up;
    public Vector3 OffsetPosition_left;
    public Vector3 OffsetPosition_down;
    public Vector3 OffsetPosition_right;

    public Vector3 OffsetRotation_up;
    public Vector3 OffsetRotation_left;
    public Vector3 OffsetRotation_down;
    public Vector3 OffsetRotation_right;

    [SerializeField]
    bool InHand;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("PlayerVer2").GetComponent<Player>();

        player.OnMove += MoveWeapon;//MoveAnimation;
        player.OnStay += StayAnimation;
        player.OnHit += HitAnimation;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnDestroy()
    {
        player.OnMove -= MoveWeapon;//MoveAnimation;
        player.OnStay -= StayAnimation;
        //player.OnStay -= //StayAnimation;
        player.OnHit -= HitAnimation;
    }

    void MoveWeapon(Vector3 Direction)
    {
        spriteRenderer.sortingOrder = 5;

        if (Direction == Vector3.up|| (Direction.x > 0 && Direction.y > 0) || (Direction.x < 0 && Direction.y > 0))
        {
            spriteRenderer.sortingOrder = 10;
            transform.position = (player.transform.position - Direction * 0.1f) + OffsetPosition_up;//* 0.2f
            transform.rotation = Quaternion.Euler(OffsetRotation_up);
        }
        if (Direction == Vector3.left)
        {
            transform.position = (player.transform.position - Direction * 0.1f)+ OffsetPosition_left;//- Direction * 0.2f
            transform.rotation = Quaternion.Euler(OffsetRotation_left);
        }
        if (Direction == Vector3.down||(Direction.x < 0 && Direction.y < 0) || (Direction.x > 0 && Direction.y < 0))
        {
            transform.position = (player.transform.position - Direction * 0.1f)+ OffsetPosition_down;
            transform.rotation= Quaternion.Euler(OffsetRotation_down);
        }
        if (Direction == Vector3.right)
        {
            transform.position = (player.transform.position - Direction * 0.1f)+ OffsetPosition_right;
            transform.rotation = Quaternion.Euler(OffsetRotation_right);
        }
        //else
        //{
        //    if ((Direction.x > 0 && Direction.y > 0) || (Direction.x < 0 && Direction.y > 0))
        //        //animator.Play("Player_up");
        //    if ((Direction.x < 0 && Direction.y < 0) || (Direction.x > 0 && Direction.y < 0))
        //        //animator.Play("Player_down");
        //}


        //if (Direction == Vector3.down)
        //    transform.position = player.transform.position - Direction * 0.2f;
        ////animator.Play("Player_down");
        //if (Direction == Vector3.left)
        //    animator.Play("Player_left");
        //if (Direction == Vector3.up)
        //    animator.Play("Player_up");
        //if (Direction == Vector3.right)
        //    animator.Play("Player_right");
        //else
        //{
        //    if ((Direction.x > 0 && Direction.y > 0) || (Direction.x < 0 && Direction.y > 0))
        //        animator.Play("Player_up");
        //    if ((Direction.x < 0 && Direction.y < 0) || (Direction.x > 0 && Direction.y < 0))
        //        animator.Play("Player_down");
        //}

        //if ((Direction.x > 0 && Direction.y > 0) || (Direction.x < 0 && Direction.y > 0)||(Direction == Vector3.up))
        //    spriteRenderer.sortingOrder = 10;
        //if(!InHand)
        //    transform.position = player.transform.position - Direction * 0.2f;
    }

    void StayAnimation(Vector3 Direction)
    {
        //if (!InHand)
        //    MoveWeapon(Direction);//transform.position = player.transform.position - Direction * 0.2f;
    }


    void HitAnimation(Vector3 Direction)
    {
        TakeInHand();

        //transform.position = player.transform.position + Direction;
    }

    void TakeInHand()
    {
        StartCoroutine(WaitAnaimation(player.SpeedAttack));
    }

    private IEnumerator WaitAnaimation(float waitTime)
    {
        InHand = true;
        yield return new WaitForSeconds(waitTime);
        InHand = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

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

    private Animator animator;

    [SerializeField]
    bool InHand;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("PlayerVer2").GetComponent<Player>();
        animator = GetComponent<Animator>();

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
            transform.position = (player.transform.position - Direction * 0.1f)+ OffsetPosition_left;//- direction * 0.2f
            transform.rotation = Quaternion.Euler(OffsetRotation_left);
        }
        if (Direction == Vector3.down||(Direction.x < 0 && Direction.y < 0) || (Direction.x > 0 && Direction.y < 0))
        {
            transform.position = (player.transform.position - Direction * 0.1f)+ OffsetPosition_down;
            transform.rotation = Quaternion.Euler(OffsetRotation_down);
        }
        if (Direction == Vector3.right)
        {
            transform.position = (player.transform.position - Direction * 0.1f)+ OffsetPosition_right;
            transform.rotation = Quaternion.Euler(OffsetRotation_right);
        }
    }

    void StayAnimation(Vector3 Direction)
    {
        //if (!InHand)
        //    MoveWeapon(direction);//transform.position = player.transform.position - direction * 0.2f;
    }


    void HitAnimation(Vector3 Direction)
    {
        //TakeInHand(direction);

        StartCoroutine(WaitAnaimation(player.SpeedAttack, Direction));

        //transform.position = player.transform.position + direction;



    }

    void TakeInHand(Vector3 Direction)
    {
        StartCoroutine(WaitAnaimation(player.SpeedAttack, Direction));
    }

    private IEnumerator WaitAnaimation(float waitTime, Vector3 Direction)
    {
        animator.enabled = true;
        InHand = true;

        if (Direction==Vector3.left)
        {
            animator.Play("Wave_left");
        }
        if (Direction == Vector3.right)
        {
            animator.Play("Wave_right");
        }

        yield return new WaitForSeconds(waitTime);

        InHand = false;

        animator.StopPlayback();

        animator.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //if(animator.is)
        //{

        //}
        
    }
}

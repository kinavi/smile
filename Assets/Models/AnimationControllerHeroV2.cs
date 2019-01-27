using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControllerHeroV2 : MonoBehaviour
{
    private Animator animator;
    private Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
        animator = GetComponent<Animator>();

        player.OnMove += MoveAnimation;
        player.OnStay += StayAnimation;
        player.OnHit += HitAnimation;
    }

    private void OnDestroy()
    {
        player.OnMove -= MoveAnimation;
        player.OnStay -= StayAnimation;
        player.OnHit -= HitAnimation;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void HitAnimation(Vector3 Direction)
    {

    }

    void MoveAnimation(Vector3 Direction)
    {
        if (Direction == Vector3.down || (Direction.x < 0 && Direction.y < 0) || (Direction.x > 0 && Direction.y < 0))
            animator.Play("PlayerV2_walk_down");//PlayerV2_walk_down
        if (Direction == Vector3.left)
            animator.Play("PlayerV2_walk_left");
        if (Direction == Vector3.up || (Direction.x > 0 && Direction.y > 0) || (Direction.x < 0 && Direction.y > 0))
            animator.Play("PlayerV2_walk_up");
        if (Direction == Vector3.right)
            animator.Play("PlayerV2_walk_right");
    }

    void StayAnimation(Vector3 Direction)
    {

        if (Direction == Vector3.down || (Direction.x < 0 && Direction.y < 0) || (Direction.x > 0 && Direction.y < 0))
            animator.Play("PlayerV2_stay_down");
        if (Direction == Vector3.left)
            animator.Play("PlayerV2_stay_left");
        if (Direction == Vector3.up || (Direction.x > 0 && Direction.y > 0) || (Direction.x < 0 && Direction.y > 0))
            animator.Play("PlayerV2_stay_up");
        if (Direction == Vector3.right)
            animator.Play("PlayerV2_stay_right");
    }

    //void MoveAnimation(Vector3 Direction)
    //{
    //    animator.SetBool("StayDown", false);
    //    animator.SetBool("StayLeft", false);
    //    animator.SetBool("StayUp", false);
    //    animator.SetBool("StayRight", false);

    //    if (Direction == Vector3.down || (Direction.x < 0 && Direction.y < 0) || (Direction.x > 0 && Direction.y < 0))
    //    {

    //        animator.SetBool("GoDown",true);
    //    }

    //        //animator.Play("PlayerV2_walk_down");//PlayerV2_walk_down
    //    if (Direction == Vector3.left)
    //    {

    //        animator.SetBool("GoLeft", true);
    //    }

    //    //animator.Play("PlayerV2_walk_left");
    //    if (Direction == Vector3.up || (Direction.x > 0 && Direction.y > 0) || (Direction.x < 0 && Direction.y > 0))
    //    {

    //        animator.SetBool("GoUp", true);
    //    }

    //    //animator.Play("PlayerV2_walk_up");
    //    if (Direction == Vector3.right)
    //    {

    //        animator.SetBool("GoRight", true);
    //    }

    //    //animator.Play("PlayerV2_walk_right");
    //    //else
    //    //{
    //    //    if ((Direction.x > 0 && Direction.y > 0) || (Direction.x < 0 && Direction.y > 0))
    //    //        //animator.Play("PlayerV2_walk_up");
    //    //    if ((Direction.x < 0 && Direction.y < 0) || (Direction.x > 0 && Direction.y < 0))
    //    //        //animator.Play("PlayerV2_walk_down");
    //    //}
    //}

    //void StayAnimation(Vector3 Direction)
    //{
    //    animator.SetBool("GoDown", false);
    //    animator.SetBool("GoLeft", false);
    //    animator.SetBool("GoUp", false);
    //    animator.SetBool("GoRight", false);

    //    if (Direction == Vector3.down || (Direction.x < 0 && Direction.y < 0) || (Direction.x > 0 && Direction.y < 0))
    //    {
    //        animator.SetBool("StayDown", true);

    //    }
    //    //animator.Play("PlayerV2_stay_down");
    //    if (Direction == Vector3.left)
    //    {
    //        animator.SetBool("StayLeft", true);

    //    }
    //    //animator.Play("PlayerV2_stay_left");
    //    if (Direction == Vector3.up || (Direction.x > 0 && Direction.y > 0) || (Direction.x < 0 && Direction.y > 0))
    //    {
    //        animator.SetBool("StayUp", true);

    //    }
    //    //animator.Play("PlayerV2_stay_up");
    //    if (Direction == Vector3.right)
    //    {
    //        animator.SetBool("StayRight", true);

    //    }
    //    //animator.Play("PlayerV2_stay_right");
    //    //else
    //    //{
    //    //    if ((Direction.x > 0 && Direction.y > 0) || (Direction.x < 0 && Direction.y > 0))
    //    //        animator.Play("PlayerV2_stay_up");
    //    //    if ((Direction.x < 0 && Direction.y < 0) || (Direction.x > 0 && Direction.y < 0))
    //    //        animator.Play("PlayerV2_stay_down");
    //    //}
    //}
}

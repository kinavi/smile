using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEngineController : MonoBehaviour
{
    [SerializeField]
    private Vector3 direction;

    private Rigidbody2D rigidbody;
    public float Speed;

    public GameObject objHit;
    public float SpeedAttack;
    private float TimeAttack;
    public float DistanceAttack;

    Quaternion right = Quaternion.Euler(0, 0, -45f);
    Quaternion left = Quaternion.Euler(180f, 0, 135f);
    Quaternion up = Quaternion.Euler(0, 0, 45f);
    Quaternion down = Quaternion.Euler(180f, 0, 45f);

    Quaternion upright = Quaternion.Euler(0, 0, 0);
    Quaternion upleft = Quaternion.Euler(0, 0, 90);
    Quaternion downright = Quaternion.Euler(180f, 0, 0);
    Quaternion downleft = Quaternion.Euler(180f, 0, 90);



    // Start is called before the first frame update
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();

        InputController.OnMove += Move;
        InputController.OnHit += Hit;
    }

    private void OnDestroy()
    {
        InputController.OnMove -= Move;
        InputController.OnHit -= Hit;
    }

    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        direction = new Vector3(x, y).normalized; 

        Vector3 Distance = direction * Time.deltaTime * Speed;

        Vector3 Target = transform.position + Distance;

        rigidbody.MovePosition(Target);
    }

    void Hit()
    {
        if(Time.time > TimeAttack + SpeedAttack)
        {
            TimeAttack = Time.time;

            switch(PlayerManager.direction)
            {
                case Direction.Up:
                    Instantiate<GameObject>(objHit, transform.position + direction * DistanceAttack, up);
                    break;
                case Direction.Down:
                    Instantiate<GameObject>(objHit, transform.position + direction * DistanceAttack, down);
                    break;
                case Direction.Left:
                    Instantiate<GameObject>(objHit, transform.position + direction * DistanceAttack, left);
                    break;
                case Direction.Right:
                    Instantiate<GameObject>(objHit, transform.position + direction * DistanceAttack, right);
                    break;
                case Direction.UpLeft:
                    Instantiate<GameObject>(objHit, transform.position + direction * DistanceAttack, upleft);
                    break;
                case Direction.UpRight:
                    Instantiate<GameObject>(objHit, transform.position + direction * DistanceAttack, upright);
                    break;
                case Direction.DownLeft:
                    Instantiate<GameObject>(objHit, transform.position + direction * DistanceAttack, downleft);
                    break;
                case Direction.DownRight:
                    Instantiate<GameObject>(objHit, transform.position + direction * DistanceAttack, downright);
                    break;
            }
        }
    }
}

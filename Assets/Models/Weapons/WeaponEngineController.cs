using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponEngineController : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    public Vector3 OffsetPosition_up;
    public Vector3 OffsetPosition_left;
    public Vector3 OffsetPosition_down;
    public Vector3 OffsetPosition_right;

    public Vector3 OffsetPosition_upleft;
    public Vector3 OffsetPosition_upright;

    public Vector3 OffsetPosition_downleft;
    public Vector3 OffsetPosition_downright;

    public Vector3 OffsetRotation_up;
    public Vector3 OffsetRotation_left;
    public Vector3 OffsetRotation_down;
    public Vector3 OffsetRotation_right;


    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        InputController.OnMove += MoveWeapon;
    }

    private void OnDestroy()
    {
        InputController.OnMove -= MoveWeapon;
    }

    void MoveWeapon()
    {
        spriteRenderer.sortingOrder = 5;

        switch (PlayerManager.direction)
        {
            case Direction.Up:
                spriteRenderer.sortingOrder = 10;
                transform.localPosition = OffsetPosition_up;
                transform.rotation = Quaternion.Euler(OffsetRotation_up);
                break;
            case Direction.UpRight:
                spriteRenderer.sortingOrder = 10;
                transform.localPosition = OffsetPosition_upright;
                transform.rotation = Quaternion.Euler(OffsetRotation_up);
                break;
            case Direction.Right:
                transform.localPosition = OffsetPosition_right;
                transform.rotation = Quaternion.Euler(OffsetRotation_right);
                break;
            case Direction.DownRight:
                transform.localPosition = OffsetPosition_downright;
                transform.rotation = Quaternion.Euler(OffsetRotation_down);
                break;
            case Direction.Down:
                transform.localPosition = OffsetPosition_down;
                transform.rotation = Quaternion.Euler(OffsetRotation_down);
                break;
            case Direction.DownLeft:
                transform.localPosition = OffsetPosition_downleft;
                transform.rotation = Quaternion.Euler(OffsetRotation_down);
                break;
            case Direction.Left:
                transform.localPosition = OffsetPosition_left;
                transform.rotation = Quaternion.Euler(OffsetRotation_left);
                break;
            case Direction.UpLeft:
                spriteRenderer.sortingOrder = 10;
                transform.localPosition = OffsetPosition_upleft;
                transform.rotation = Quaternion.Euler(OffsetRotation_up);
                break;
        }
    }


}

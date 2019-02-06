using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolt : MonoBehaviour
{
    private float TimeStart;
    private float TimeEnd;
    public float TimeLive;
    public float SpeedBolt;
    private Vector3 TargetDirection;
    //public bool IsShoting;

    //public delegate void CreateHandler();
    //public static event CreateHandler Shot;

    // Start is called before the first frame update
    void Start()
    {
        TimeStart = Time.time;
        TimeEnd = TimeStart + TimeLive;
    }

    // Update is called once per frame
    void Update()
    {      
        float time = Time.time;

        if (time >= TimeEnd)
        {
            Destroy(gameObject);
        }
        if (TargetDirection!=null)
        {
            transform.Translate(TargetDirection.normalized * SpeedBolt * Time.deltaTime);
        }
    }

    public void Shot(Vector3 targetDirection)
    {
        TargetDirection = targetDirection;
        //IsShoting = true;
    }



}

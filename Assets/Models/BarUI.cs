using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarUI : MonoBehaviour
{
    private float Value;
    private float MaxValue;

    private float DeltaValue;
    public float SpeedChange;

    private RectTransform СhangeObj;
    private RectTransform BarObj;
    private Text text;

    public void SetValue(float maxvalue)
    {
        this.Value = maxvalue;
        this.MaxValue = maxvalue;
        this.DeltaValue = maxvalue;
    }

    private void Start()
    {
        foreach(RectTransform rectTransform in this.GetComponentsInChildren<RectTransform>())
        {
            if(rectTransform.gameObject.name=="Bar")
            {
                BarObj = rectTransform;//this.GetComponentsInChildren<RectTransform>()[1];
            }
            if(rectTransform.gameObject.name == "Change")
            {
                СhangeObj = rectTransform;
            }
        }
        
        text = this.GetComponentInChildren<Text>();
    }

    public virtual void СhangeValue(float value)
    {
        this.Value = value;
        StartCoroutine("StartChangeBar");
    }

    private void Update()
    {
        if(Value>=0)
        {
            BarObj.transform.localScale = new Vector3(Value / MaxValue, 1, 1);
            text.text = Value.ToString();
        }
        else
            Value = 0;
    }

    private IEnumerator StartChangeBar()
    {
        while (DeltaValue > Value)
        {
            DeltaValue -= SpeedChange*Time.deltaTime;
            СhangeObj.transform.localScale = new Vector3(DeltaValue / MaxValue, 1, 1);
            yield return null;
        }
        if(DeltaValue < Value)
            DeltaValue = Value;

    }
}

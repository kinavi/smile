using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarUI : MonoBehaviour
{
    public float Value;
    public float MaxValue;

    public RectTransform BarObj;
    public Text text;

    //public BarUI(float value, float maxvalue)
    //{
    //    BarObj = this.GetComponentInChildren<RectTransform>();
    //    text = this.GetComponentInChildren<Text>();

    //    this.Value = value;
    //    this.MaxValue = maxvalue;
    //}
    public void SetValue(float value, float maxvalue)
    {
        this.Value = value;
        this.MaxValue = maxvalue;
    }

    private void Start()
    {
        BarObj = this.GetComponentsInChildren<RectTransform>()[1];
        text = this.GetComponentInChildren<Text>();

    }

    public virtual void СhangeValue(float value)
    {
        this.Value = value;
    }

    public virtual void Update()
    {
        BarObj.transform.localScale = new Vector3(Value / MaxValue, 1, 1);
        text.text = Value.ToString();

        if (Value >= MaxValue)
            Value = MaxValue;

        if (Value <= 0)
            Value = 0;
    }
}

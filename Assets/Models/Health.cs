using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public delegate void ChangeHealthHandler(float Ratios);
    public static event ChangeHealthHandler ReduceHealth;
    public static event ChangeHealthHandler IncreaseHealth;

    public float curHealth = 100;
    public GameObject healthObj;
    public Text healthText;
    public float maxHealth;

    public PlayerManager player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
        curHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        healthObj.transform.localScale = new Vector3(curHealth / maxHealth, 1, 1);
        healthText.text = curHealth.ToString();

        if (curHealth >= maxHealth)
            curHealth = maxHealth;

        if (curHealth <= 0)
            curHealth = 0;

    }

    //void ReduceHealth()
    //{

    //}

    public void Damage(float damage)
    {
        curHealth -= damage;
    }
}

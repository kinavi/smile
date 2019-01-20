using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Assets.EventArgs;

public class CustomEventSystem : MonoBehaviour {

    public static CustomEventSystem instance = null;

    public delegate void ChangingHealth(float Value, string Name, Vector3 Position);// - уменьшаяет, + увеличивает
    //public delegate void 
    public static event ChangingHealth DecreasedHealth;
    //public static event ChangingHealth DecreasedHealth;// Снижение здоровья
    public static event ChangingHealth IncreasedHealth;// Увеличение здоровья
    //public static event ChangingHealth 

    public delegate void HeroeHandler();
    public static event HeroeHandler HeroeIsDeath;

    public delegate void EnemyHandler(float unit);
    public static event EnemyHandler TakingDamage;


    //-----
    //public delegate void PlayerHandler(Enemy enemy, EnemyEventArgs args);
    //public static event PlayerHandler Attack;

    //public delegate void BottleHandler();
    //public static event BottleHandler


    // Метод, выполняемый при старте игры
    void Start()
    {
        // Теперь, проверяем существование экземпляра
        if (instance == null)
        { // Экземпляр менеджера был найден
            instance = this; // Задаем ссылку на экземпляр объекта
        }
        else if (instance == this)
        { // Экземпляр объекта уже существует на сцене
            Destroy(gameObject); // Удаляем объект
        }

        // Теперь нам нужно указать, чтобы объект не уничтожался
        // при переходе на другую сцену игры
        DontDestroyOnLoad(gameObject);

        // И запускаем собственно инициализатор
        InitializeManager();

    }

    // Метод инициализации менеджера
    private void InitializeManager()
    {
        /* TODO: Здесь мы будем проводить инициализацию */
    }

    public static void SendHeroeIsDeath()
    {
        HeroeIsDeath();
    }

    public static void AttackTheHero(float damage)
    {
        TakingDamage(damage);
    }

}

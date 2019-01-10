using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Models
{
    public class HealthPotionSmall:MonoBehaviour
    {
        [SerializeField]
        public float Points;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Player")
            {
                //Анимация подбора
                Destroy(gameObject);
            }
        }
    }

}

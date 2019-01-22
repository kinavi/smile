using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.EventArgs
{
    public enum EnemyType { Simple }

    public class EnemyEventArgs
    {
        public EnemyType Type { get; }
        public float Damage { get; }

        public Vector3 Position { get; }

        public EnemyEventArgs(EnemyType type, float damage, Vector3 position)
        {
            Type = type;
            Damage = damage;
            Position = position;
        }

    }
}

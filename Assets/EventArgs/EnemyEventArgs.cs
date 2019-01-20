using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.EventArgs
{
    public enum EnemyType { Simple }

    public class EnemyEventArgs
    {
        public EnemyType Type { get; }
        public float Damage { get; }

        public EnemyEventArgs(EnemyType type, float damage)
        {
            Type = type;
            Damage = damage;
        }

    }
}

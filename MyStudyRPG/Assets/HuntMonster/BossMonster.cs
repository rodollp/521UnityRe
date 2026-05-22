using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;
namespace Assets.HuntMonster
{
    internal class BossMonster : Monster
    {
        [SerializeField] private int _shield;

        public int Shield
        {
            get => _shield;
            protected set => _shield = Mathf.Max(0, value);
        }



        public override void TakeDamage(int damage)
        {
            if (Shield > 0)
            {
                if (Shield >= damage)
                {
                    Shield -= damage;

                    Debug.Log($"{Name}의 보호막이 피해를 막았습니다! 남은 보호막 : {Shield}");

                    return;
                }
                else
                {
                    damage -= Shield;
                    Shield = 0;

                    Debug.Log($"{Name}의 보호막이 파괴되었습니다!");
                }
            }

            base.TakeDamage(damage);
        }

        protected override void OnDead()
        {
            Debug.Log("화려한 이펙트와 함께 보스 처치!");
            base.OnDead();   

        }
    }
}

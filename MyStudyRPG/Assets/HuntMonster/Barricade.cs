using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
namespace Assets.HuntMonster
{
    internal class Barricade : MonoBehaviour ,IDamageable
    {
        [SerializeField] private int barrHp;

        public int Hp
        {
            get { return barrHp; }
            set
            {
                if (value <= 0)
                {
                    value = 0;
                }
            }
        }

        public void TakeDamage(int damage)
        {
            Hp -= damage;
            Debug.Log($"장애물은 {damage}의 피해를 받습니다. 구조물 체력 : {Hp}");
            if (IsDead)
            {
                Debug.Log("장애물이 파손되었습니다");
            }

        }

        public bool IsDead
        {
            get { return Hp <= 0; }
        }
    }
}

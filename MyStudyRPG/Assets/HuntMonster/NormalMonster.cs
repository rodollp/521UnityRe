using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Assets.HuntMonster;
namespace Assets.HuntMonster
{
    internal class NormalMonster : Monster
    {

        protected override void OnDead()
        {
            base.OnDead();
            Debug.Log("아이템을 떨굽니다");
        }

    }
}

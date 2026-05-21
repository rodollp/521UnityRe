using System;
using UnityEngine;

namespace Assets.HuntMonster
{
    [Serializable]
    public struct Reward
    {
        public string itemName;
        public int amount;

        public Reward(string itemName, int amount)
        {
            this.itemName = itemName;
            this.amount = amount;

        }

    }
}
using Assets.HuntMonster;
using UnityEngine;

namespace HuntMonster
{
    public class GameSystem : MonoBehaviour
    {
        [SerializeField] Monster[] monsters;
        [SerializeField] Barricade[] barricades;

        private IDamageable[] targets;
        void Start()
        {
            targets = new IDamageable[monsters.Length + barricades.Length];

        }


    }

}
using Assets.HuntMonster;
using MonsterHunt;
using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
namespace HuntMonster
{
    public class GameSystem : MonoBehaviour
    {
        [SerializeField] Player player;

        [SerializeField] List<Monster> monsters;
        [SerializeField] Barricade[] barricades;

        public Player Player => player;
        private IDamageable[] targets;

        private Dictionary<string, Monster> findMons = new Dictionary<string, Monster>();
        private Queue<Monster> spawnQueue = new Queue<Monster>();
        private Storage<Monster> monsterStorage = new Storage<Monster>();
        private Stack<string> logs = new Stack<string>();
        

        void PrintLog()
        {
            Debug.Log("====로그확인===");

            while (logs.Count > 0)
            {
                Debug.Log(logs.Pop());
            }
        }

        private int playerDamage = 200;
        void Start()
        {
            targets = new IDamageable[monsters.Count + barricades.Length];

            

            for (int i = 0; i < monsters.Count; i++)
            {
                targets[i] = monsters[i];
                monsterStorage.Save(monsters[i]);
                spawnQueue.Enqueue(monsters[i]);
            }

            for (int k = 0; k < monsterStorage.Count; k++)
            {
                Monster m = monsterStorage.Get(k);
                
                Debug.Log($"{m.Name} 꺼내기!");
            }


            int barricadeindex = 0;
            for (int j = monsters.Count; j < targets.Length; j++, barricadeindex++)
            {
                targets[j] = barricades[barricadeindex];
            }


            for (int i = 0; i < targets.Length; i++)
            {
                targets[i].TakeDamage(playerDamage);
                logs.Push($"{targets[i]}은 {playerDamage}만큼 피해를 받습니다");
                
                if (targets[i] is Monster monster && monster.IsDead)
                { 
                    int exp = 100;
                    int level = Player.Level;

                    LevelUp(ref exp, ref level);
                    logs.Push("플레이어 레벨업!");

                    Player.Level = level;
                    if (TryGetLoot(monster, out string lootName))
                    {
                        Debug.Log($"{lootName}획득");
                        logs.Push($"아이템 {lootName} 획득");
                    }
                }

            }

            PrintLog();

        }


        void Spawn<T>(T entity) where T : IDamageable
        {
            Debug.Log($"{entity} 생성");
        }

        void LevelUp(ref int exp, ref int level)
        {

            while (exp >= 100)
            {
                level++;

                Debug.Log($"레벨업 현재 레벨 : {level}");

                exp -= 100;
            }
        }

        private bool TryGetLoot(Monster m, out string lootName)
        {

            if (m.IsDead)
            {
                lootName = m.reward.itemName;
                return true;
            }
            lootName = "없음";
            return false;
        }

        private Monster FindMonster(string name)
        {
            if (findMons.TryGetValue(name, out Monster monster))
            {
                return monster;
            }
            return null;
        }

    }

}
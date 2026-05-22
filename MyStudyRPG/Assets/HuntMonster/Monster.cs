using Assets.HuntMonster;
using HuntMonster;
using UnityEngine;

public class Monster : MonoBehaviour , IDamageable
{
    [SerializeField] private string monsterName;
    [SerializeField] private int _Hp;

    [SerializeField] public Reward reward;
    [SerializeField] public Point point;

    public Reward Reward => reward;
    public Point Point => point;
    public string Name { get { return monsterName; } }

    public int Hp
    {
        get { return _Hp; }

        set
        {
            _Hp = Mathf.Max(value, 0);
        }
    }


    public virtual void TakeDamage(int damage)
    {
        _Hp -= damage;
        Debug.Log($"{monsterName}는(은) {damage}의 피해를 받았습니다");
        if (_Hp <= 0)
        {
            OnDead();
        }

        
    }

    public bool IsDead
    {
        get
        {
            return _Hp <= 0;
        }
    }

    protected virtual void OnDead()
    {
        
        Debug.Log($"보상 : {reward.itemName}, 골드{reward.amount} ");
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Data_Units
{
    public int Key;
    public string Name;
    public int Attack;
    public int AttackSpeed;
    public int MaxHp;
    public int Hp;
    public string Rating;

    public Data_Units() { }
    public Data_Units(int _key, string _name, int _attack, int _attackspeed, int _maxhp, int _hp, string _rating)
    {
        this.Key = _key;
        this.Name = _name;
        this.Attack = _attack;
        this.AttackSpeed = _attackspeed;
        this.MaxHp = _maxhp;
        this.Hp = _hp;
        this.Rating = _rating;
    }
}

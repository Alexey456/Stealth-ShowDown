using System.Xml.Linq;
using UnityEngine;

public class Character
{
    private string _name;
    private int _exp = 0;

    public Character(string name) { 
        this._name = name;
    }

    public string Name { get => _name;  set => _name = value;  }
    public int Exp { get => _exp; set => _exp = value; }
    public virtual void CharacterInfo()
    {
        Debug.LogFormat("{0} - {1}", _name, _exp);
    }
}

public class Paladin : Character
{
    Weapon _weapon;
    public Paladin(string name,Weapon _weapon) : base(name) {
        this._weapon = _weapon;
    }
    public override void CharacterInfo() {
        base.CharacterInfo();
        Debug.LogFormat("Weapon - " + _weapon.name);
    }
}
public struct Weapon
{
    public string name;
    public int damage;

    public Weapon(string name, int damage)
    {
        this.name = name;
        this.damage = damage;
    }

    public void WeaponInfo()
    {
        Debug.LogFormat("{0} - {1}",name, damage);
    }
}

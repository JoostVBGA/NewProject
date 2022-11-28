using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Fighter", menuName = "Fighter/Create new fighter")]

public class FighterBase : ScriptableObject
{
    [SerializeField] string fighterName;

    [TextArea]
    [SerializeField] string fighterDescription;

    [SerializeField] GameObject fighterModel;

    [SerializeField] FighterElementType elementType;
    [SerializeField] FighterWeaponType weaponType;

    //Base Stats

    [SerializeField] int maxHP;
    [SerializeField] int maxMana;
    [SerializeField] int speed;
    [SerializeField] int damage;
    [SerializeField] int defense;
    [SerializeField] int attack;
    [SerializeField] int stamina;
    [SerializeField] int luck;
    [SerializeField] int drive;

    public string Name
    {
        get { return fighterName; }
    }

    public string Description
    {
        get { return fighterDescription; }
    }

    public GameObject Model
    {
        get { return fighterModel; }
    }

    public FighterElementType ElementType
    {
        get { return elementType; }
    }

    public FighterWeaponType WeaponType
    {
        get { return weaponType; }
    }

    public int MaxHP
    {
        get { return maxHP; }
    }

    public int MaxMana
    {
        get { return maxMana; }
    }

    public int Speed
    {
            get { return speed; }
    }

    public int Damage
    {
        get { return damage; }
    }

    public int Defense
    {
        get { return defense; }
    }

    public int Attack
    {
        get { return attack; }
    }

    public int Stamina
    {
        get { return stamina; }
    }

    public int Luck
    {
        get { return luck; }
    }

    public int Drive
    {
        get { return drive; }
    }
}

public enum FighterElementType
{
    None,
    Fire,
    Wind,
    Ground,
    Water,
}
public enum FighterWeaponType
{
    Spear,
    Sword,
    Wand,
    Shield,
    Fists,
    Axe,
    Pole,
}
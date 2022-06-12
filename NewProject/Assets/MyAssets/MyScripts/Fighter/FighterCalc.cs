using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterCalc
{
    FighterBase _base;
    int level;

    public FighterCalc(FighterBase pBase, int pLevel)
    {
        _base = pBase;
        level = pLevel;

    }

    public int MaxHP
    {
        get { return Mathf.FloorToInt((_base.MaxHP * level) / 100f) + 10; }
    }

    public int MaxMana
    {
        get { return Mathf.FloorToInt((_base.MaxMana * level) / 100f) + 10; }
    }
    public int Speed
    {
        get { return Mathf.FloorToInt((_base.Speed * level) / 100f) + 5; }
    }
    public int Damage
    {
        get { return Mathf.FloorToInt((_base.Damage * level) / 100f) + 5; }
    }
    public int Defense
    {
        get { return Mathf.FloorToInt((_base.Defense * level) / 100f) + 5; }
    }
    public int Attack
    {
        get { return Mathf.FloorToInt((_base.Attack * level) / 100f) + 5; }
    }
    public int Stamina
    {
        get { return Mathf.FloorToInt((_base.Stamina * level) / 100f) + 5; }
    }
    public int Luck
    {
        get { return Mathf.FloorToInt((_base.Luck * level) / 100f) + 5; }
    }
    public int Drive
    {
        get { return Mathf.FloorToInt((_base.Drive * level) / 100f) + 5; }
    }
}

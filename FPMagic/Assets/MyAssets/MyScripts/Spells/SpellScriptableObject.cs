using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Spell",menuName = "Spells" )]
public class SpellScriptableObject : ScriptableObject
{
    public float ManaCost = 5f;
    public float LifeTime = 2f;
    public float Speed = 15f;
    public float Power = 10f;
    public float MaxSpeed = 50f;
    public float MaxPower = 80f;


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Spell",menuName = "Spells" )]
public class SpellScriptableObject : ScriptableObject
{
    public float ManaCost = 5f;
    public float LifeTime = 2f;
    public float MaxSpeed = 50f;
    public float MaxPower = 80f;
    public float SpellRadius = 0.5f;
    public float StartSpeed = 1f;
    public float StartPower = 1f;
    public float IncrementPower = 0.2f;
    public float IncrementSpeed = 0.2f;
}

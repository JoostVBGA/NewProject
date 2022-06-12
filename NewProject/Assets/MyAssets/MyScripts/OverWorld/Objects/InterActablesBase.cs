using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InterActable", menuName = "InterActable/Create new InterActable")]

public class InterActablesBase : ScriptableObject
{
    [SerializeField] string interActableName;

    [TextArea]
    [SerializeField] string interActableDescription;

    [SerializeField] ScriptableObject interActableItem;

    [SerializeField] ObjectType interActableType;

    //LockMethods
    [SerializeField] private LockType1 lockType1;
    [SerializeField] LockType2 lockType2;

    //Locks

    [SerializeField] private ScriptableObject ItemBarrier1;
    [SerializeField] int lvlBarrier1;
    [SerializeField] private ScriptableObject PlayerBarrier1;
    [SerializeField] private ScriptableObject ItemBarrier2;
    [SerializeField] int lvlBarrier2;
    [SerializeField] private ScriptableObject PlayerBarrier2;


    public string Name
    {
        get { return interActableName; }
    }

    public string Description
    {
        get { return interActableDescription; }
    }

    public ScriptableObject Item
    {
        get { return interActableItem; }
    }
    public enum ObjectType
    {
        Chest,
        Door,
    }
 
    public enum LockType1
    {
        None,
        Item,
        Level,
        Player,
    }
    public enum LockType2
    {
        None,
        Item,
        Level,
        Player,
    }
}


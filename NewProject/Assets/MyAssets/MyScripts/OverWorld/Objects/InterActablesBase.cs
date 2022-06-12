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
}

public enum ObjectType
{
    Chest,
}

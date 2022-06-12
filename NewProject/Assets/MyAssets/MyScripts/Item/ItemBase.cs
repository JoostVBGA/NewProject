using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Item/Create new item")]

public class ItemBase : ScriptableObject
{
    [SerializeField] string itemName;

    [TextArea]
    [SerializeField] string itemDescription;

    [SerializeField] Sprite itemSprite;

    [SerializeField] ItemType itemType;

    //Base Stats

    [SerializeField] int addMaxHP;
    [SerializeField] int addMaxMana;
    [SerializeField] int addSpeed;
    [SerializeField] int addDamage;
    [SerializeField] int addDefense;
    [SerializeField] int addAttack;
    [SerializeField] int addStamina;
    [SerializeField] int addLuck;
    [SerializeField] int addDrive;

    public string Name
    {
        get { return itemName; }
    }

    public string Description
    {
        get { return itemDescription; }
    }

    public Sprite sprite
    {
        get { return itemSprite; }
    }

    public ItemType ItemType
    {
        get { return itemType; }
    }

    public int AddMaxHP
    {
        get { return addMaxHP; }
    }

    public int AddMaxMana
    {
        get { return addMaxMana; }
    }

    public int AddSpeed
    {
        get { return addSpeed; }
    }

    public int AddDamage
    {
        get { return addDamage; }
    }

    public int AddDefense
    {
        get { return addDefense; }
    }

    public int AddAttack
    {
        get { return addAttack; }
    }

    public int AddStamina
    {
        get { return addStamina; }
    }

    public int AddLuck
    {
        get { return addLuck; }
    }

    public int AddDrive
    {
        get { return addDrive; }
    }
}

public enum ItemType
{
    Accessory,
    Weapon,
}

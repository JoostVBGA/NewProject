using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMagicSystem : MonoBehaviour
{

    [SerializeField] private Spell spell1;
    [SerializeField] private Spell spell2;
    [SerializeField] private Spell spellToCast;
    [SerializeField] private Transform castPoint;

    private bool isCraftingMagic = false;
    private GameInputs controls;

    //[SerializeField] private float maxMana = 100f;

    //[SerializeField] private float currentMana;

    //[SerializeField] private float manaRechargeRate = 2f;

    [SerializeField] public float CurrentPower;
    [SerializeField] public float CurrentSpeed;
    
    

    private void Awake()
    {
        controls = new GameInputs();
    }

    private void Update()
    {
        Ability();
        Cast();
    }
    private void Ability()
    {
        if (controls.Player.StartMagic.triggered)
        {
            if (!isCraftingMagic) 
            {
                isCraftingMagic = true;
                Debug.Log("CraftingMagic");
                //SpellCraftUI/Animation

            }
            else
            {
                isCraftingMagic = false;
                Debug.Log("NotCraftingMagic");
            }
        }

        if (controls.Player.Opt1.triggered && isCraftingMagic)
        {
            spellToCast = spell1;
            Debug.Log("Spell1");
            CurrentSpeed = spell1.SpellToCast.StartSpeed;
            Debug.Log(CurrentSpeed);
        }

        if (controls.Player.Opt2.triggered && isCraftingMagic)
        {
            spellToCast = spell2;
            Debug.Log("Spell2");
            CurrentSpeed = spell2.SpellToCast.StartSpeed;
            Debug.Log(CurrentSpeed);
        }

    }

    private void Cast()
    {
        if (controls.Player.UseMagic.triggered && isCraftingMagic)
        {
            Instantiate(spellToCast, castPoint.position, castPoint.rotation);
            isCraftingMagic = false;
        }
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }
}

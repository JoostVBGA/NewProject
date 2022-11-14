using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMagicSystem : MonoBehaviour
{
    [Header("SpellSlots")]
    [SerializeField] private Spell spell1;
    [SerializeField] private Spell spell2;
    [SerializeField] private Spell spell3;
    [SerializeField] private Spell spell4;
    [SerializeField] private Spell spell5;

    [Header("WorkingInfo")]
    [SerializeField] private Spell spellToCast;
    [SerializeField] private Transform castPoint;
    [SerializeField] private float maxMana = 100f;
    [SerializeField] private float currentMana;
    [SerializeField] private float manaRechargeRate = 7f;
    [SerializeField] private float timeToWaitForRecharge = 1f;
    private float currentManaRechargeTimer;
    private bool spellIsSet = false;
    private bool isCraftingMagic = false;
    private GameInputs controls;

    [Header("PublicInfo")]
    [SerializeField] public float CurrentPower;
    [SerializeField] public float CurrentSpeed;

    private void Awake()
    {
        controls = new GameInputs();
        currentMana = maxMana;
    }

    private void Update()
    {
        ManaRecharge();
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
            CurrentPower = spell1.SpellToCast.StartPower;
            spellIsSet = true;
}

        if (controls.Player.Opt2.triggered && isCraftingMagic)
        {
            spellToCast = spell2;
            Debug.Log("Spell2");
            CurrentSpeed = spell2.SpellToCast.StartSpeed;
            CurrentPower = spell2.SpellToCast.StartPower;
            spellIsSet = true;
        }

    }

    private void ManaRecharge()
    {
        if (currentMana < maxMana && !isCraftingMagic)
        {
            currentManaRechargeTimer += Time.deltaTime;

            if (currentManaRechargeTimer > timeToWaitForRecharge)
            {
                currentMana += manaRechargeRate * Time.deltaTime;
                if (currentMana > maxMana) currentMana = maxMana;
            }
        }
    }
    private void Cast()
    {

        if (controls.Player.UseMagic.triggered && spellIsSet)
        {
            bool hasEnoughMana = currentMana - spellToCast.SpellToCast.ManaCost >= 0f;

            if (hasEnoughMana == true)
            {
                Instantiate(spellToCast, castPoint.position, castPoint.rotation);

                currentMana -= spellToCast.SpellToCast.ManaCost;

                currentManaRechargeTimer = 0;
            }
            
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

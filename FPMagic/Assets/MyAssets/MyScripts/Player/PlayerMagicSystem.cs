using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMagicSystem : MonoBehaviour
{
    [SerializeField] private Spell spellToCast;

    [SerializeField] private float maxMana = 100f;

    [SerializeField] private float currentMana;

    [SerializeField] private float manaRechargeRate = 2f;

    [SerializeField] private Transform castPoint;

    private bool castingMagic = false;

    private GameInputs controls;

    private void Awake()
    {
        controls = new GameInputs();
    }

    private void Update()
    {
        Ability();

        if (controls.Player.UseMagic.triggered)
        {
            castSpell();
        }
    }
    private void Ability()
    {
        if (controls.Player.StartMagic.triggered)
        {
            if (!castingMagic) 
            {
                castingMagic = true;
                Debug.Log("CraftingMagic");
                craftSpell();
                //SpellCraftUI/Animation

            }
            else
            {
                castingMagic = false;
                Debug.Log("NotCraftingMagic");
            }
        }
    }

    void craftSpell()
    {
        if (controls.Player.Opt1.triggered)
        {

        }

        if (controls.Player.Opt2.triggered)
        {

        }
    }

    void castSpell()
    {
        Instantiate(spellToCast, castPoint.position, castPoint.rotation);
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

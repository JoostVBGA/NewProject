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

    public float currentSpellSpeed;

    public float currentSpellPower;

    public float FinalPower = 1f;

    public float FinalSpeed = 1f;

    private bool isCastingMagic = false;

    private GameInputs controls;

    private void Awake()
    {
        controls = new GameInputs();
    }

    private void Update()
    {
        Ability();

        if (controls.Player.UseMagic.triggered && isCastingMagic)
        {
            castSpell();
            isCastingMagic = false;
        }
    }
    private void Ability()
    {
        if (controls.Player.StartMagic.triggered)
        {
            if (!isCastingMagic) 
            {
                isCastingMagic = true;
                Debug.Log("CraftingMagic");
                //SpellCraftUI/Animation

            }
            else
            {
                isCastingMagic = false;
                Debug.Log("NotCraftingMagic");
            }
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

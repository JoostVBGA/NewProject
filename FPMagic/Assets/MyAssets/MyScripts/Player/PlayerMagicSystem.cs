using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMagicSystem : MonoBehaviour
{
    [SerializeField] private Spell spellToCast;
    [SerializeField] private Transform castPoint;
    private bool isCastingMagic = false;
    private GameInputs controls;
    //[SerializeField] private float maxMana = 100f;

    //[SerializeField] private float currentMana;

    //[SerializeField] private float manaRechargeRate = 2f;

    private float currentSpeed;

    private float currentPower;

    public float FinalPower = 1f;

    public float FinalSpeed = 1f;


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

        if (controls.Player.Opt1.triggered && isCastingMagic)
        {

        }

        if (controls.Player.Opt2.triggered && isCastingMagic)
        {

        }

    }

    private void Cast()
    {
        if (controls.Player.UseMagic.triggered && isCastingMagic)
        {
            Instantiate(spellToCast, castPoint.position, castPoint.rotation);
            isCastingMagic = false;
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

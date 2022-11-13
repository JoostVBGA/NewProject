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

    public float CurrentPower = 1f;

    public float CurrentSpeed = 1f;


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
            //spellInfo = spellToCast.GetComponent<Spell>();
            //CurrentSpeed = spellInfo.StartSpeed 
        }

        if (controls.Player.Opt2.triggered && isCraftingMagic)
        {
            spellToCast = spell2;
            Debug.Log("Spell1");
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

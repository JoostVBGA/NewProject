using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMagicSystem : MonoBehaviour
{
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

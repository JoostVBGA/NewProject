using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Spell : MonoBehaviour
{

    private GameInputs controls;

    public SpellScriptableObject SpellToCast;

    public float currentSpellSpeed;

    public float currentSpellPower;

    public float startSpellSpeed;

    public float startSpellPower;

    public float maxSpellPower;

    public float maxSpellSpeed;

    public float incrementSpellPower;

    public float incrementSpellSpeed;

    private void Update()
    {
        if (!controls.Player.UseMagic.triggered)
        {
            transform.Translate(transform.Vector3.forward * currentSpellSpeed * Time.deltaTime);
        }

    }

    private void SpellCrafting()
    {
        startSpellPower = currentSpellPower;

        startSpellSpeed = currentSpellSpeed;

        if (controls.Player.MagicPower.triggered)
        {

            if (currentSpellPower >= maxSpellPower)
            {
                return;
            }

            currentSpellPower + incrementSpellPower = currentSpellPower;
        }

        if (controls.Player.MagicSpeed.triggered)
        {

            if (currentSpellPower >= maxSpellPower)
            {
                return;
            }

            currentSpellSpeed + incrementSpellSpeed = currentSpellSpeed;
        }
    }
}

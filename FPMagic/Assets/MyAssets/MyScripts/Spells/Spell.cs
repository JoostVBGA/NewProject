using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(SphereCollider))]

[RequireComponent(typeof(Rigidbody))]
public class Spell : MonoBehaviour
{

    private GameInputs controls;

    public SpellScriptableObject SpellToCast;

    public float currentSpellSpeed;

    public float currentSpellPower;

    public float accResetTimeSeconds { get; private set; } = 0.5f;

    private SphereCollider myCollider;

    private Rigidbody myRigidbody;

    private void Awake()
    {
        myCollider = GetComponent<SphereCollider>();
        myCollider.isTrigger = true;
        myCollider.radius = SpellToCast.SpellRadius;

        myRigidbody = GetComponent<Rigidbody>();
        myRigidbody.isKinematic = true;

        Destroy(this.gameObject, SpellToCast.LifeTime);
    }

    private void Update()
    {
        if (SpellToCast.Speed > 0) 
        { 
            transform.Translate(transform.forward * currentSpellSpeed * Time.deltaTime); 
        }
    }

    private void SpellCrafting()
    {
        //currentSpellPower = SpellToCast.StartPower;

        //currentSpellSpeed = SpellToCast.StartSpeed;

        if (controls.Player.MagicPower.triggered)
        {

            if (currentSpellPower >= SpellToCast.MaxPower)
            {
                return;
            }

            //currentSpellPower + SpellToCast.IncrementPower = currentSpellPower;
        }

        if (controls.Player.MagicSpeed.triggered)
        {

            if (currentSpellPower >= SpellToCast.MaxPower)
            {
                return;
            }

            //new currentSpellSpeed = (currentSpellSpeed + SpellToCast.IncrementSpeed);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //apply effects and damage 

        //Destroy(this.gameObject);
    }
}

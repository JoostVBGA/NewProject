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

    public PlayerMagicSystem SpellCraft;

    public float currentSpellSpeed;

    public float currentSpellPower;

    public float accResetTimeSeconds { get; private set; } = 0.5f;

    private SphereCollider myCollider;

    private Rigidbody myRigidbody;

    private Camera mainCamera;

    private void Awake()
    {
        myCollider = GetComponent<SphereCollider>();
        myCollider.isTrigger = true;
        myCollider.radius = SpellToCast.SpellRadius;

        myRigidbody = GetComponent<Rigidbody>();
        myRigidbody.isKinematic = true;

        Destroy(this.gameObject, SpellToCast.LifeTime);

        mainCamera = Camera.main;

        //currentSpellSpeed = PlayerMagicSystem.FinalSpeed;

        Destroy(this.gameObject, SpellToCast.LifeTime);
    }

    private void Update()
    {
        if (SpellToCast.StartSpeed > 0) 
        {
            transform.Translate(transform.forward * currentSpellSpeed * Time.deltaTime); 
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //apply effects and damage 

        Destroy(this.gameObject);
    }
}

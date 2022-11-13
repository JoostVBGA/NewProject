using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]
public class Spell : MonoBehaviour
{
    PlayerMagicSystem playerMagicSystem;

    [SerializeField] GameObject Player;

    public SpellScriptableObject SpellToCast;

    private GameInputs controls;

    private SphereCollider myCollider;

    private Rigidbody myRigidbody;

    private Camera mainCamera;

    private float finalSpeed;

    private float finalPower;
    public float accResetTimeSeconds { get; private set; } = 0.5f;

    private void Awake()
    {
        myCollider = GetComponent<SphereCollider>();
        myCollider.isTrigger = true;
        myCollider.radius = SpellToCast.SpellRadius;

        myRigidbody = GetComponent<Rigidbody>();
        myRigidbody.isKinematic = true;

        Destroy(this.gameObject, SpellToCast.LifeTime);

        mainCamera = Camera.main;

        playerMagicSystem = Player.GetComponent<PlayerMagicSystem>();

        finalSpeed = playerMagicSystem.CurrentSpeed;

        finalPower = playerMagicSystem.CurrentPower;

    }

    private void Update()
    {
        if (SpellToCast.StartSpeed > 0) 
        {
            transform.Translate(Vector3.forward * finalSpeed * Time.deltaTime); 
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //apply effects and damage 
        if (!other.gameObject.CompareTag("Enemy"))
        {
            HealthComponent enemyHealth = GetComponent<HealthComponent>();
            enemyHealth.TakeDamage(finalPower);
        }
        Destroy(this.gameObject);

    }
}

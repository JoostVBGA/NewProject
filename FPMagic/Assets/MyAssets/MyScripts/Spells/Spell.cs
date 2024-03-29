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

    [SerializeField] private float finalSpeed;
    [SerializeField] private float finalPower;
    [SerializeField] private float finalSize;
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

        playerMagicSystem = GameObject.Find("PlayerEmpty").GetComponent<PlayerMagicSystem>();

        finalSpeed = playerMagicSystem.CurrentSpeed;
        finalPower = playerMagicSystem.CurrentPower;
        transform.localScale = transform.localScale * playerMagicSystem.CurrentSize; ;

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
        if (other.gameObject.CompareTag("Enemy"))
        {
            CS_HealthComponent enemyHealth = other.GetComponent<CS_HealthComponent>();
            enemyHealth.TakeDamage(finalPower);
        }
            

        Destroy(this.gameObject);
    }
}

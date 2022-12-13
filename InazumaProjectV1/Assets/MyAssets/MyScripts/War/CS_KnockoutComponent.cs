using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_KnockoutComponent : MonoBehaviour
{
    [SerializeField] private float KnockoutTime;
    private bool startedTimer = false;
    private void OnEnable()
    {
        startedTimer = true;
      
        gameObject.GetComponent<CapsuleCollider>().enabled = false;
        
        Debug.Log("KnockoutTriggerd" + gameObject.name);
        KnockoutTime = 10;
    }
    private void Update()
    {
        if (KnockoutTime > 0 && startedTimer)
        {
            KnockoutTime -= Time.deltaTime;
            if (KnockoutTime < 0)
            {
                this.GetComponent<CS_KnockoutComponent>().enabled = false;
                Debug.Log("KnockOutOver");

                gameObject.GetComponent<CapsuleCollider>().enabled = true;
            }
        }
    }
}

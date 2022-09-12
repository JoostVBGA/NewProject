using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{
    public SpellScriptableObject SpellToCast;

    private void Update()
    {
        transform.Translate(transform.Vector3.forward * SpellToCast.Speed * Time.deltaTime);
    }
}

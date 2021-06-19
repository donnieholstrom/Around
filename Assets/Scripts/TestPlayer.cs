using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayer : MonoBehaviour
{
    void OnEnable()
    {
        PlayerEventManager.damagePlayer += TakeDamage;
    }

    // Update is called once per frame
    void OnDisable()
    {
        PlayerEventManager.damagePlayer -= TakeDamage;
    }

    void TakeDamage(int damage)
    {
        Debug.Log("Took " + damage + " damage.");
    }
        
}
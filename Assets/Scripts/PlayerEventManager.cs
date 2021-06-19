using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEventManager : MonoBehaviour
{
    public delegate void DamagePlayer(int damage);
    public static event DamagePlayer damagePlayer;

    public static void DoDamage(int damage)
    {
        damagePlayer?.Invoke(damage);
    }
        
}
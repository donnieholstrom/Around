using System;
using UnityEngine;

public class HighscoreManager : MonoBehaviour
{
    [NonSerialized]
    public int highscore;
    
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
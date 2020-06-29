using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int cyclesCompleted;
    public TextMeshProUGUI cyclesLabel;

    private void Awake()
    {
        cyclesCompleted = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Line"))
        {
            cyclesCompleted++;
            cyclesLabel.text = cyclesCompleted.ToString();
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Base : MonoBehaviour
{
    public float health;
    public Slider bar;
    public float credits = 100;
    public TextMeshProUGUI amount;

    void Start()
    {
        bar.maxValue = health;
    }
    public void hit(float damage)
    {
        health -= damage;
        bar.value = health;
        if (health <= 0)
        {
            Die();
        }
       
    }
    public void Die()
    {

    }
}

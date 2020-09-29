using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Base : MonoBehaviour
{
    public float health;
    public Slider bar;

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

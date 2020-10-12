using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Base : Parent
{
    public float health;
    public Slider bar;
    public float credits = 100;
    public TextMeshProUGUI amount;
    public Manager manager;
    public enemy enemyprefab;
    public GameObject Spawns;
    public GameObject sp;
    bool spawn = false;
    public float rate = 2f;
    float r;
    int total = 0;

    void Awake()
    {
        manager.PlaceScene();
        bar.maxValue = health;
        r = rate;
    }
    void FixedUpdate()
    {
        if (spawn && total < 0)
        {
            r -= Time.fixedDeltaTime;
            if (r <= 0)
            {
                enemy clone;
                clone = Instantiate(enemyprefab, sp.transform.position, Quaternion.identity);
                clone.goal = this;
                clone.gameObject.transform.SetParent(manager.content.transform);
                total--;
                if (total <= 0)
                {
                    manager.roundend = true;
                    spawn = false;
                }
            }
        }
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
        manager.Lose();
    }
    public void Round(int num)
    {
        spawn = true;
        int dir = Random.Range(0, 360);
        Spawns.transform.eulerAngles = new Vector3(0, dir, 0);
        total = num * 5;
    }
}

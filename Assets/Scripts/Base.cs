using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Base : Parent
{
    public float health = 400;
    public Slider bar;
    
    public TextMeshProUGUI amount;
    public Manager manager;
    public enemy enemyprefab;
    public GameObject Spawns;
    public List<GameObject> sp = new List<GameObject>();
    public bool spawn = false;
    public float rate = 2f;
    float r;
    int total = 0;

    void Awake()
    {
        //manager.PlaceScene();
        bar.maxValue = health;
        r = rate;
    }
    void FixedUpdate()
    {
        if (spawn && total > 0)
        {
            r -= Time.fixedDeltaTime;
            if (r <= 0)
            {
                int l = Random.Range(0, sp.Capacity);
                    
                enemy clone;
                clone = Instantiate(enemyprefab, sp[l].transform.position, Quaternion.identity);
                clone.goal = this;
                //clone.gameObject.transform.SetParent(manager.content.transform);
                clone.gameObject.transform.SetParent(gameObject.transform);
                total--;
                r = rate;
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
    public void heal(float h)
    {
        health += h;
        if (health > 400)
        {
            health = 400;
        }
        bar.value = health;
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

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tower : MonoBehaviour
{
    public blast projectile;
    public GameObject SpawnPoint;
    public float shotspeed = 1f;
    float current = 0f;
    public Collider area;
    public List<GameObject> enemies = new List<GameObject>();
    public int index = 0;
    public GameObject parent;
    
    
   
    
    void FixedUpdate()
    {
        if (enemies[index] != null)
        {
            current -= Time.fixedDeltaTime;
            if (current <= 0)
            {
                blast clone;
                clone = Instantiate(projectile, SpawnPoint.transform.position, transform.rotation);
                clone.Target = enemies[index].gameObject;
                //clone.gameObject.transform.SetParent(parent.transform, true);
                current = shotspeed;
            }
        }
        else
        {
            UnTarget();
        }
        
    }
    public void Target (GameObject target)
    {
        enemies.Add(target);
        enemies.Capacity++;
        
    }
    
    public void UnTarget()
    {
        if (enemies[index] == null)
        {
            
            int p = 0;
            foreach (GameObject i in enemies)
            {

                if (i != null)
                {
                    index = p;
                    return;
                }
                p++;
            }
            enemies.Clear();
            index = 0;
            enemies.Capacity = 0;

        }
    }  
}

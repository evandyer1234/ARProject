using System.Collections;
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
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
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
            }
        }
        
    }
    public void Target (GameObject target)
    {
        enemies.Capacity++;
        enemies.Add(target);
    }
    public void UnTarget(GameObject target)
    {
        if (enemies[index] == null)
        {

        }
    }
    
}

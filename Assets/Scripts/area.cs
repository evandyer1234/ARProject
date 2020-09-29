using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class area : MonoBehaviour
{
    public tower t;

    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider collision)
    {
        enemy e = collision.gameObject.GetComponent<enemy>();
        if (e != null)
        {
            t.Target(collision.gameObject);
        }
    }
    void OnTriggerExit(Collider collision)
    {
        enemy e = collision.gameObject.GetComponent<enemy>();
        if (e != null)
        {
            t.Target(collision.gameObject);
        }
    }
}

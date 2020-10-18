using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class area : MonoBehaviour
{
    public tower t;

    
    
    void OnTriggerEnter(Collider collision)
    {
        Debug.Log("EnemyEntered");
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
            t.UnTarget();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dead : MonoBehaviour
{
    Animator animator;
    public float death = 3f;

    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }
    void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
        animator.SetBool("dead", true);
        Destroy(gameObject, death);
        
    }


    
}

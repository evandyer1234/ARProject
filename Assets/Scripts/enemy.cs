using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : Parent
{
    Animator animator;
    public float health = 10f;
    public float speed = 2f;
    public float damage = 1f;
    public float attackrate = 0.5f;
    float ar;
    public Base goal;
    Vector3 MoveDirection;
    public float WithinRange = 2f;
    public GameObject deadguy;
   
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }
    
    void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
        ar = attackrate;
    }
    void FixedUpdate()
    {
        if (!IsCloseToTarget())
        {
            MoveDirection = (goal.gameObject.transform.position - transform.position).normalized;
            
            transform.position += (Time.fixedDeltaTime * MoveDirection * speed);
            gameObject.transform.forward = MoveDirection;
        }
        else
        {
            ar -= Time.fixedDeltaTime;
            if (ar <= 0)
            {
                int f = Random.Range(0, 3);
                goal.hit(damage);
                ar = attackrate;
                if (f == 0)
                {
                    animator.SetTrigger("Attack");
                }
                else if (f == 1)
                {
                    animator.SetTrigger("Attack2");
                }
                else if (f == 2)
                {
                    animator.SetTrigger("Attack3");
                }
            }
        }
        
    }

    public bool IsCloseToTarget()
    {

        if (GetDistanceTo(goal.gameObject) < WithinRange)
        {
            return true;
        }
        else
        {
            return false;
        }

    }
    public float GetDistanceTo(GameObject Other)
    {
        float distanceTo = (Other.transform.position - transform.position).magnitude;

        return distanceTo;
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            
            goal.heal(2f);
            GameObject clone;
            clone = Instantiate(deadguy, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(this.gameObject);
        }
    }
}

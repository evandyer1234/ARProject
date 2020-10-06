using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : Parent
{
    public float health = 10f;
    public float speed = 10f;
    public float damage = 1f;
    public float attackrate = 0.5f;
    float ar;
    public Base goal;
    Vector3 MoveDirection;
    public float WithinRange = 2f;

    void Awake()
    {
        ar = attackrate;
    }
    void FixedUpdate()
    {
        if (!IsCloseToTarget())
        {
            MoveDirection = (goal.gameObject.transform.position - transform.position).normalized;
            transform.position += (Time.fixedDeltaTime * MoveDirection * speed);
            gameObject.transform.eulerAngles = MoveDirection;
        }
        else
        {
            ar -= Time.fixedDeltaTime;
            if (ar <= 0)
            {
                goal.hit(damage);
                ar = attackrate;
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
            Destroy(this.gameObject);
        }
    }
}

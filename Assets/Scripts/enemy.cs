using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public float health = 10f;
    public float speed = 10f;
    public GameObject Base;
    Vector3 MoveDirection;
    public float WithinRange = 2f;

   
    void FixedUpdate()
    {
        if (!IsCloseToTarget())
        {
            MoveDirection = (Base.transform.position - transform.position).normalized;
            transform.position += (Time.fixedDeltaTime * MoveDirection * speed);
            gameObject.transform.eulerAngles = MoveDirection;
        }
    }

    public bool IsCloseToTarget()
    {

        if (GetDistanceTo(Base) < WithinRange)
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
}

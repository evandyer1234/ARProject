using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blast : Parent
{
    public float damage = 1f;
    public float speed = 10f;
    public GameObject Target;
    Vector3 MoveDirection;
    public float WithinRange = 2f;


    void FixedUpdate()
    {
        if (Target == null)
        {
            Destroy(this.gameObject);
        }
        if (!IsCloseToTarget())
        {
            MoveDirection = (Target.transform.position - transform.position).normalized;
            transform.position += (Time.fixedDeltaTime * MoveDirection * speed);
            gameObject.transform.eulerAngles = MoveDirection;
        }
        else
        {
            enemy e = Target.GetComponent<enemy>();
            if (e != null)
            {
                e.TakeDamage(damage);
                Destroy(this.gameObject);
            }
        }
       
    }

    public bool IsCloseToTarget()
    {
        Debug.Log(GetDistanceTo(Target));
        if (GetDistanceTo(Target) < WithinRange)
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

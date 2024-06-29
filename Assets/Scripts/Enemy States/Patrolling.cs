using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Patrolling : State
{
    [SerializeField] private Transform[] points;
    [SerializeField] private float patrolSpeed;
     public int counter = 0;

    public override void Enter()
    {
        if (!anim.IsInTransition(0))
        {
            anim.CrossFade("Patrolling", 0.25f);
        }
        base.Enter();
    }

    public override void Tick()
    {
        ChangePatrollPoints();
        Wondering();
        if(main.followPlayer == true)
        {
            isCompleted = true;
        }
    }



    public override void Exit()
    {
        base.Exit();
    }

    private void Wondering()
    {
        main.lookToTarget(points[counter].transform.position);
        Vector3 direction = points[counter].transform.position - this.transform.position;
        rb.velocity = direction.normalized * patrolSpeed;
    }

    private void ChangePatrollPoints()
    {
        if (Vector3.SqrMagnitude(points[counter].transform.position - this.transform.position) <= 0.5f)
        {
            counter++;
            if (counter == points.Length)
            {
                counter = 0;
            }
        }
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Follow : State
{
    [SerializeField] private float followSpeed;
    public override void Enter()
    {
        if (!anim.IsInTransition(0))
        {
            anim.CrossFade("FollowingPlayer", 0.25f);
        }
    }

    public override void Tick()
    {
        main.lookToTarget(main.player.transform.position);
        if (main.AttackPlayer == true || main.followPlayer == false)
        {
            isCompleted = true;
        }
        else
        {
            seekPlayer(main.player.transform);
        }
    }

    public override void Exit()
    {
        base.Exit();
    }

    private void seekPlayer(Transform target)
    {
        Vector3 direction = target.position - this.transform.position;
        direction.y = 0f;
        rb.velocity = direction.normalized * followSpeed;
    }
}

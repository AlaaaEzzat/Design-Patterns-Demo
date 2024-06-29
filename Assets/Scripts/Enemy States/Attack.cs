using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Attack : State
{
    [SerializeField] private GameObject magicEffect;
    [SerializeField] private Transform startAttackPos;
    [SerializeField] ObjectPool<GameObject> pool;
    [SerializeField] private float waitBeforeAttack;

    public override void Enter()
    {
        rb.velocity = Vector3.zero;
        if (!anim.IsInTransition(0))
        {
            anim.CrossFade("AttackingPlayer", 0.25f);
        }
        base.Enter();
    }

    public override void Tick()
    {
        main.lookToTarget(main.player.transform.position);
        attacking();

        if (main.AttackPlayer == false)
        {
            isCompleted = true;
        }
    }

    public override void Exit()
    {
        base.Exit();
    }


    private void attacking()
    {
        if(main.canAttack)
        {
            ObjectPoolingManager.SpawnGameObject(magicEffect, startAttackPos.position, this.transform.rotation);
            main.canAttack = false;
        }
    }
}

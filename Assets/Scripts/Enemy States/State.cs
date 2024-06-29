using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour
{
    public bool isCompleted { get; protected set; }

    protected Rigidbody rb;
    protected Animator anim;
    protected EnemyStateMachine main;

    public virtual void Enter() { }
    public virtual void Tick() { }
    public virtual void fixedTick() { }
    public virtual void Exit() { }

    public void SetUp(Rigidbody rb , Animator anim ,EnemyStateMachine state)
    {
        this.rb = rb;
        this.anim = anim;
        main = state;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : MonoBehaviour
{
    [Header("Components")]
    public Animator anim;
    public Rigidbody rb;

    [Header("States")]
    private State state;
    [SerializeField] private State patollState;
    [SerializeField] private State followState;
    [SerializeField] private State attackState;


    [Header("GroundCheck")]
    [SerializeField] private Vector3 groundOffset;
    [SerializeField] private float checkGroundRadius;
    [SerializeField] private LayerMask groundLayer;
    public bool grounded { get; private set; }

    [Header("CheckPlayer")]
    [SerializeField] private float followRange;
    [SerializeField] private float attackRange;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private float RotationSpeed;
    public bool AttackPlayer;
    public bool followPlayer;
    public GameObject player;
    public bool canAttack;


    private void Start()
    {
        patollState.SetUp(rb, anim, this);
        followState.SetUp(rb, anim, this);
        attackState.SetUp(rb, anim, this);
        state = patollState;
    }

    private void FixedUpdate()
    {
        checkPlayerInRange();
        checkPlayerInAttackRange();
        checkGrounded();

        state.fixedTick();
    }

    private void Update()
    {
        if (state.isCompleted)
        {
            ChangeStates();
        }
        state.Tick();
    }

    private void ChangeStates()
    {
        if(grounded && !followPlayer && !AttackPlayer)
        {
            state = patollState;
        }
        else if(followPlayer && !AttackPlayer)
        {
            state = followState;
        }
        else if(AttackPlayer)
        {
            state = attackState;
        }
        state.Enter();
    }

    private void checkPlayerInAttackRange()
    {
        AttackPlayer = Physics.CheckSphere(transform.position, attackRange, playerLayer);
    }

    private void checkPlayerInRange()
    {
        followPlayer = Physics.CheckSphere(transform.position, followRange, playerLayer);
    }

    private void checkGrounded()
    {
        grounded = Physics.CheckSphere(transform.position + groundOffset, checkGroundRadius, groundLayer);
    }

    public void lookToTarget(Vector3 target)
    {
        var lookPos = target - transform.position;
        lookPos.y = 0;
        var rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * RotationSpeed);
    }

    public void AttackAnim()
    {
        canAttack = true;
    }

}

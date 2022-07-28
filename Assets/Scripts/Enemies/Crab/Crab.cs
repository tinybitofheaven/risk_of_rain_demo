using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crab : Entity
{
    public Crab_IdleState idleState { get; private set; }
    public Crab_MoveState moveState { get; private set; }
    public Crab_AggroState aggroState { get; private set; }
    public Crab_MeleeAttackState meleeAttackState { get; private set; }


    [SerializeField]
    private D_IdleState idleStateData;
    [SerializeField]
    private D_MoveState moveStateData;
    [SerializeField]
    private D_AggroState aggroStateData;
    [SerializeField]
    private D_MeleeAttackState meleeAttackStateData;

    [SerializeField]
    private Transform meleeAttackPosition;

    public override void Start()
    {
        base.Start();
        moveState = new Crab_MoveState(this, stateMachine, "move", moveStateData, this);
        idleState = new Crab_IdleState(this, stateMachine, "idle", idleStateData, this);
        aggroState = new Crab_AggroState(this, stateMachine, "move", aggroStateData, this);
        meleeAttackState = new Crab_MeleeAttackState(this, stateMachine, "meleeAttack", meleeAttackPosition, meleeAttackStateData, this);

        stateMachine.Initialize(moveState);
    }

    public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.DrawWireSphere(meleeAttackPosition.position, meleeAttackStateData.attackRadius);
    }
}

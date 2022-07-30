using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Imp : Entity
{
    public Imp_IdleState idleState { get; private set; }
    public Imp_MoveState moveState { get; private set; }
    public Imp_AggroState aggroState { get; private set; }
    public Imp_MeleeAttackState meleeAttackState { get; private set; }
    public Imp_TeleportState teleportState { get; private set; }


    [SerializeField]
    private D_IdleState idleStateData;
    [SerializeField]
    private D_MoveState moveStateData;
    [SerializeField]
    private D_AggroState aggroStateData;
    [SerializeField]
    private D_MeleeAttackState meleeAttackStateData;
    [SerializeField]
    private D_TeleportState teleportStateData;

    [SerializeField]
    private Transform meleeAttackPosition;

    public override void Start()
    {
        base.Start();
        moveState = new Imp_MoveState(this, stateMachine, "move", moveStateData, this);
        idleState = new Imp_IdleState(this, stateMachine, "idle", idleStateData, this);
        aggroState = new Imp_AggroState(this, stateMachine, "move", aggroStateData, this);
        meleeAttackState = new Imp_MeleeAttackState(this, stateMachine, "meleeAttack", meleeAttackPosition, meleeAttackStateData, this);
        teleportState = new Imp_TeleportState(this, stateMachine, "teleport", teleportStateData, this);

        stateMachine.Initialize(moveState);
    }

    public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.DrawWireSphere(meleeAttackPosition.position, meleeAttackStateData.attackRadius);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Imp : Entity
{
    public Imp_IdleState idleState { get; private set; }
    public Imp_MoveState moveState { get; private set; }
    public Imp_AggroState aggroState { get; private set; }

    [SerializeField]
    private D_IdleState idleStateData;
    [SerializeField]
    private D_MoveState moveStateData;
    [SerializeField]
    private D_AggroState aggroStateData;

    public override void Start()
    {
        base.Start();
        moveState = new Imp_MoveState(this, stateMachine, "move", moveStateData, this); //TODO: add animation
        idleState = new Imp_IdleState(this, stateMachine, "idle", idleStateData, this);
        aggroState = new Imp_AggroState(this, stateMachine, "aggro", aggroStateData, this);

        stateMachine.Initialize(moveState);
    }
}

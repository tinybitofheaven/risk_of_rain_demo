using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Imp_MoveState : MoveState
{
    private Imp imp;
    public Imp_MoveState(Entity entity, FSM stateMachine, string animBoolName, D_MoveState stateData, Imp imp) : base(entity, stateMachine, animBoolName, stateData)
    {
        this.imp = imp;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (isDetectingWall || !isDetectingLedge)
        {
            imp.idleState.SetFlipAfterIdle(true);
            stateMachine.ChangeState(imp.idleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}

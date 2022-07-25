using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Imp_AggroState : AggroState
{
    private Imp imp;
    public Imp_AggroState(Entity entity, FSM stateMachine, string animBoolName, D_AggroState stateData, Imp imp) : base(entity, stateMachine, animBoolName, stateData)
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
        if (!isPlayerInMaxAggroRange)
        {
            imp.idleState.SetFlipAfterIdle(false);
            stateMachine.ChangeState(imp.idleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

}

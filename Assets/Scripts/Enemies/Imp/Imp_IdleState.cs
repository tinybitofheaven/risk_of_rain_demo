using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Imp_IdleState : IdleState
{
    private Imp imp;

    public Imp_IdleState(Entity entity, FSM stateMachine, string animBoolName, D_IdleState stateData, Imp imp) : base(entity, stateMachine, animBoolName, stateData)
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
        if (isIdleTimeOver)
        {
            stateMachine.ChangeState(imp.moveState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}

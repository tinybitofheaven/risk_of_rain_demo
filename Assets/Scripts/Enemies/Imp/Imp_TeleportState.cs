using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Imp_TeleportState : TeleportState
{
    protected Imp imp;

    public Imp_TeleportState(Entity entity, FSM stateMachine, string animBoolName, D_TeleportState stateData, Imp imp) : base(entity, stateMachine, animBoolName, stateData)
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
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}

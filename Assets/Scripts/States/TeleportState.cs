using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportState : State
{
    protected D_TeleportState stateData;
    protected float usedTime;
    // protected 
    public TeleportState(Entity entity, FSM stateMachine, string animBoolName, D_TeleportState stateData) : base(entity, stateMachine, animBoolName)
    {
        this.stateData = stateData;
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

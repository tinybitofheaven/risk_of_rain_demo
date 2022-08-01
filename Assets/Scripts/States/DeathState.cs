using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathState : State
{
    protected D_DeathState stateData;
    public DeathState(Entity entity, FSM stateMachine, string animBoolName, D_DeathState stateData) : base(entity, stateMachine, animBoolName)
    {
        this.stateData = stateData;
    }

    public override void Checks()
    {
        base.Checks();
    }

    public override void Enter()
    {
        base.Enter();
        entity.SetVelocity(0f);
        entity.atsm.deathState = this;
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

    public virtual void TriggerDeath()
    {
    }

    public virtual void FinishDeath()
    {
        entity.Destroy();
    }
}

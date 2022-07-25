using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AggroState : State
{
    protected D_AggroState stateData;
    protected bool isPlayerInMinAggroRange;
    protected bool isPlayerInMaxAggroRange;

    public AggroState(Entity entity, FSM stateMachine, string animBoolName, D_AggroState stateData) : base(entity, stateMachine, animBoolName)
    {
        this.stateData = stateData;
    }

    public override void Enter()
    {
        base.Enter();
        entity.SetVelocity(0f);
        isPlayerInMinAggroRange = entity.CheckMinAggroRange();
        isPlayerInMaxAggroRange = entity.CheckMaxAggroRange();
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
        isPlayerInMinAggroRange = entity.CheckMinAggroRange();
        isPlayerInMaxAggroRange = entity.CheckMaxAggroRange();
    }
}

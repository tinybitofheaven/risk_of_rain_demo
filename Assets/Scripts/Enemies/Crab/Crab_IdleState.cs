﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crab_IdleState : IdleState
{
    private Crab crab;
    public Crab_IdleState(Entity entity, FSM stateMachine, string animBoolName, D_IdleState stateData, Crab crab) : base(entity, stateMachine, animBoolName, stateData)
    {
        this.crab = crab;
    }

    public override void Checks()
    {
        base.Checks();
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
        if (isPlayerInMinAggroRange)
        {
            stateMachine.ChangeState(crab.aggroState);
        }
        else if (isIdleTimeOver)
        {
            stateMachine.ChangeState(crab.moveState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}

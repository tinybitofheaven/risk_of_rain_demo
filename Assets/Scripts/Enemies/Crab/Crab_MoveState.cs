using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crab_MoveState : MoveState
{
    private Crab crab;
    public Crab_MoveState(Entity entity, FSM stateMachine, string animBoolName, D_MoveState stateData, Crab crab) : base(entity, stateMachine, animBoolName, stateData)
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
        else if (isDetectingWall || !isDetectingLedge)
        {
            crab.idleState.SetFlipAfterIdle(true);
            stateMachine.ChangeState(crab.idleState);
        }
        else if (isMoveTimeOver)
        {
            crab.idleState.SetFlipAfterIdle(Random.value > 0.5f); //randomly set flip if movetime is over
            stateMachine.ChangeState(crab.idleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}

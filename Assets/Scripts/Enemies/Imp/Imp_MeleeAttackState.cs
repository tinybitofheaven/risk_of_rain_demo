using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Imp_MeleeAttackState : MeleeAttackState
{
    private Imp imp;
    public Imp_MeleeAttackState(Entity entity, FSM stateMachine, string animBoolName, Transform attackPosition, D_MeleeAttackState stateData, Imp imp) : base(entity, stateMachine, animBoolName, attackPosition, stateData)
    {
        this.imp = imp;
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
        if (isAnimationFinished)
        {
            stateMachine.ChangeState(imp.aggroState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void TriggerAttack()
    {
        base.TriggerAttack();
    }

    public override void FinishAttack()
    {
        base.FinishAttack();
    }

}

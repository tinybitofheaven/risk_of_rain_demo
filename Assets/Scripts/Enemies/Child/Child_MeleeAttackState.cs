using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Child_MeleeAttackState : MeleeAttackState
{
    private Child child;

    public Child_MeleeAttackState(Entity entity, FSM stateMachine, string animBoolName, Transform attackPosition, D_MeleeAttackState stateData, Child child) : base(entity, stateMachine, animBoolName, attackPosition, stateData)
    {
        this.child = child;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (isAnimationFinished)
        {
            stateMachine.ChangeState(child.aggroState);
        }
    }
}

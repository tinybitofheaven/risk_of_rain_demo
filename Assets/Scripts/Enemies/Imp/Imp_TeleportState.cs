﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Imp_TeleportState : TeleportState
{
    protected Imp imp;

    public Imp_TeleportState(Entity entity, FSM stateMachine, string animBoolName, D_TeleportState stateData, Imp imp) : base(entity, stateMachine, animBoolName, stateData)
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

    public override void TriggerTeleport()
    {
        base.TriggerTeleport();
        Vector2 playerPos = entity.playerGO.transform.parent.Find("Ground Check Point").transform.position; //TODO: broken
        Vector2 newPosition = new Vector2(playerPos.x - (0.1f * entity.facingDirection), playerPos.y + entity.spriteHeight / 2);
        entity.SetPosition(newPosition);
    }

    public override void FinishTeleport()
    {
        base.FinishTeleport();
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Child : Entity
{
    public Child_IdleState idleState { get; private set; }
    public Child_MoveState moveState { get; private set; }
    public Child_AggroState aggroState { get; private set; }
    public Child_MeleeAttackState meleeAttackState { get; private set; }
    public Child_DeathState deathState { get; private set; }
    public Child_SpawnState spawnState { get; private set; }


    [SerializeField]
    private D_IdleState idleStateData;
    [SerializeField]
    private D_MoveState moveStateData;
    [SerializeField]
    private D_AggroState aggroStateData;
    [SerializeField]
    private D_MeleeAttackState meleeAttackStateData;
    [SerializeField]
    private D_DeathState deathStateData;
    [SerializeField]
    private D_SpawnState spawnStateData;

    [SerializeField]
    private Transform meleeAttackPosition;

    public override void Start()
    {
        base.Start();
        moveState = new Child_MoveState(this, stateMachine, "move", moveStateData, this);
        idleState = new Child_IdleState(this, stateMachine, "idle", idleStateData, this);
        aggroState = new Child_AggroState(this, stateMachine, "move", aggroStateData, this);
        spawnState = new Child_SpawnState(this, stateMachine, "spawn", spawnStateData, this);
        deathState = new Child_DeathState(this, stateMachine, "death", deathStateData, this);

        meleeAttackState = new Child_MeleeAttackState(this, stateMachine, "meleeAttack", meleeAttackPosition, meleeAttackStateData, this);

        stateMachine.Initialize(spawnState);
    }

    public override void Die()
    {
        base.Die();
        stateMachine.ChangeState(deathState);
    }

    public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.DrawWireSphere(meleeAttackPosition.position, meleeAttackStateData.attackRadius);
    }
}

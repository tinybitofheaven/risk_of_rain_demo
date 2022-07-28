using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationToStateMachine : MonoBehaviour
{
    public AttackState attackState;
    public TeleportState teleportState;

    private void TriggerAttack()
    {
        attackState.TriggerAttack();
    }

    private void FinishAttack()
    {
        attackState.FinishAttack();
    }

    private void TriggerTeleport()
    {
        teleportState.TriggerTeleport();
    }

    private void FinishTeleport()
    {
        teleportState.FinishTeleport();
    }
}

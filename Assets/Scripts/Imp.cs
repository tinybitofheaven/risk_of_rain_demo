using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Imp : MonoBehaviour
{
    enum State { IDLE, AGGRO, ATTACK, DEATH, TELEPORT }
    private State currState;

    //stats
    private int health;
    private int damage;

    //range
    private float aggroRange;
    private float attackRange;
    private float teleportRange;

    private void Start()
    {
        currState = State.IDLE;
        health = 100;
        damage = 20;

        //todo
        aggroRange = 2.0f; //radius
        attackRange = 0.5f;
        teleportRange = 1.0f;
    }

    private void Update()
    {
        if (health == 0)
        {
            currState = State.DEATH;
        }

        switch (currState)
        {
            case State.IDLE:
                //random chance to walk
                //random direction
                //pick frames to walk

                //if player in range
                //state = aggro
                break;
            case State.AGGRO:
                //random chance to state = teleport
                //else head towards player until in attack range
                //if in range
                //state = attack
                break;
            case State.ATTACK:
                //pick one of attack moves
                //state = aggro
                break;
            case State.DEATH:
                //play death animation
                //kill imp
                break;
            case State.TELEPORT:
                //find space in range to teleport that is closest to player
                break;
        }
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newMoveStateData", menuName = "Data/State Data/Move State")]
public class D_MoveState : ScriptableObject //data container for saving data independent of class instances
{
    public float movementSpeed = 3;
}

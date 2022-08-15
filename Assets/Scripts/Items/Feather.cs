using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feather : Item
{
    private int totalJumps;
    private int jumpsLeft;

    public Feather()
    {
        _name = "feather";
    }

    public void ResetExtraJumps()
    {
        totalJumps = ItemManager.FindInstance().ItemCount(_name);
        jumpsLeft = totalJumps;
    }

    public bool CanExtraJump()
    {
        if (jumpsLeft > 0)
        {
            jumpsLeft--;
            return true;
        }
        else
        {
            return false;
        }
    }
}

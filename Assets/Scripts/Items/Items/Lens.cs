using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lens : Item
{
    private int count;

    public Lens()
    {
        _name = "lens";
    }

    private void GetNum()
    {
        count = ItemManager.FindInstance().ItemCount(_name);
    }

    public float GetCritChance()
    {
        GetNum();
        return 0.07f * count;
    }
}

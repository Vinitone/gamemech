using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : MonoBehaviour, IDrinkable
{
    public int restoreAmmount = 100;
    private PlayerEconomy _stat = null;
    
    public void drink()
    {
        if (this._stat != null)
        {
            this._stat.health += restoreAmmount;
        }
    }

    public void setStat(PlayerEconomy stat)
    {
        this._stat = stat;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    private GameObject _potion = null;
    private PlayerEconomy _stat;

    public bool isEmpty()
    {
        return _potion == null;
    }

    public void setStat(PlayerEconomy stat)
    {
        this._stat = stat;
    }

    public void error()
    {
        //this.GetComponent<Animator>().SetTrigger("error");
    }

    public void addPotion(GameObject potion)
    {
        IDrinkable drinkable = potion.GetComponent<IDrinkable>();

        if (drinkable != null)
        {
            GameObject instantiatedPotion = Instantiate(potion, this.gameObject.transform, false);
            this._potion = instantiatedPotion;
        }
    }

    public void drink()
    {
        if (this.isEmpty())
        {
            this.error();
            Debug.Log("Tried to drink a potion that i don't have from slot");
        }
        else
        {
            IDrinkable drinkable = this._potion.GetComponent<IDrinkable>();
            
            drinkable.setStat(this._stat);
            drinkable.drink();
            
            Destroy(this._potion);
            this._potion = null;
            
            Debug.Log("Drank a potion from slot");
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

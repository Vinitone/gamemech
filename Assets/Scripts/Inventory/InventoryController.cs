using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    private KeyCode[] keyCodes = {
        KeyCode.Alpha1,
        KeyCode.Alpha2,
        KeyCode.Alpha3,
        KeyCode.Alpha4,
        KeyCode.Alpha5,
        KeyCode.Alpha6,
        KeyCode.Alpha7,
        KeyCode.Alpha8,
        KeyCode.Alpha9,
    };
    
    [Range(1,9)]
    public int slots = 3;

    public GameObject healthPotion;
    public GameObject staminaPotion;
    public GameObject slot;
    public GameObject pool;
    private IList<Slot> _slots = new List<Slot>(); 

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < this.slots; i++)
        {
            GameObject instantiatedSlot = Instantiate(this.slot, this.pool.transform, false);

            Slot component = instantiatedSlot.GetComponent<Slot>();
            
            component.setStat(this.gameObject.GetComponent<PlayerEconomy>());
            
            this._slots.Add(component);

            RectTransform buttonTransform = instantiatedSlot.GetComponentInChildren<RectTransform>();
            Vector3 buttonPosition = buttonTransform.localPosition;
            
            float negativeMargin = (50 * this.slots) / 2 - 25;
            float positionX = buttonPosition.x - negativeMargin + (i * 50);

            buttonTransform.localPosition = new Vector3(positionX, buttonPosition.y, buttonPosition.z);
        }

        this.addPotion(this.healthPotion);
        this.addPotion(this.staminaPotion);
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Slot instantiatedSlot in this._slots)
        {
            if (Input.GetKeyDown(this.keyCodes[this._slots.IndexOf(instantiatedSlot)]))
            {
                instantiatedSlot.drink();
            }
        }
    }

    public bool addPotion(GameObject potion)
    {
        foreach(Slot listedSlot in this._slots)
        {
            if (listedSlot.isEmpty())
            {
                listedSlot.addPotion(potion);
                return true;
            }
            else
            {
                continue;
            }
        }

        return false;
    }
}

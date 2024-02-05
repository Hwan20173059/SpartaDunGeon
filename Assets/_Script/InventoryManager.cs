using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class ItemSlot
{
    public Item item;
    public int count;
}

public class InventoryManager : MonoBehaviour
{
    public ItemSlotUI[] slotsUI;
    public ItemSlot[] slots;

    private void Start()
    {
        slots = new ItemSlot[slotsUI.Length];

        for(int i = 0; i < slots.Length; i++)
        {
            slots[i] = new ItemSlot();
            slotsUI[i].index = i;
            slotsUI[i].Clear();
        }
    }

    public void SelectItem(int index)
    {
        if (slots[index].item == null)
            return;

        
    }
    
    public void AddItem(Item _item,int i)
    {
        slots[i].item = _item;
    }
}

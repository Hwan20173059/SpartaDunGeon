using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public ShopSlotUI[] shopSlots;
    public Item[] items;

    public GameObject shopWindow;

    private void Start()
    {
        for (int i = 0; i < shopSlots.Length; i++)
        {
            shopSlots[i].Clear();
        }

        // юсюг
        Set(0);
        Set(1);
        Set(2);
    }

    public void Set(int index)
    {
        shopSlots[index].Set(items[index]);
    }

}

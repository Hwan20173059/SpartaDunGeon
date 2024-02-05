using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlotUI : MonoBehaviour
{
    public Button button;
    public Image icon;
    public Image equipIcon;
    public Item item;

    public int index;
    public bool equipped;

    public void OnEquipped()
    {
        equipped = true;
        equipIcon.enabled = true;
    }

    public void OffEquipped()
    {
        equipped = false;
        equipIcon.enabled = false;
    }

    public void Set(Item _item)
    {
        item = _item;
        icon.gameObject.SetActive(true);
        icon.sprite = item.sprite;
    }

    public void Clear()
    {
        icon.gameObject.SetActive(false);
        equipIcon.gameObject.SetActive(false);
    }
}

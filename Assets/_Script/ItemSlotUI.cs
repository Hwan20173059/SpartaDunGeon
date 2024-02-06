using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlotUI : MonoBehaviour
{
    public Button button;
    public Image icon;
    public Image equipIcon;

    public Item item;
    public bool equipped;

    public void Set(Item item)
    {
        this.item = item;
        icon.sprite = item.sprite;
        icon.gameObject.SetActive(true);
    }

    public void Clear()
    {
        icon.gameObject.SetActive(false);
        equipIcon.gameObject.SetActive(false);
    }

    public void isEquipped()
    {
        equipIcon.gameObject.SetActive(true);
        equipped = true;
    }

    public void unEquipped()
    {
        equipIcon.gameObject.SetActive(false);
        equipped = false;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InventoryManager : MonoBehaviour
{
    public ItemSlotUI[] uiSlots;
    public Item[] items;

    public GameObject inventoryWindow;

    [Header("Selected Item")]
    public Item selectedItem;
    public Image selectedItemSprite;
    public Text selectedItemName;
    public Text selectedItemDescription;
    public Text selectedItemEffect;
    public int selectedIndex;

    public GameObject useButton;
    public GameObject equipButton;
    public GameObject unEquipButton;

    private void Start()
    {
        for (int i = 0; i < uiSlots.Length; i++)
        {
            uiSlots[i].Clear();
        }
        ClearSeletecItemWindow();
    }

    private void ClearSeletecItemWindow()
    {
        selectedItemSprite.sprite = null;
        selectedItem = null;
        selectedItemName.text = string.Empty;
        selectedItemDescription.text = string.Empty;

        selectedItemEffect.text = string.Empty;

        useButton.SetActive(false);
        equipButton.SetActive(false);
        unEquipButton.SetActive(false);
    }

    public void AddItem(Item item)
    {
        for(int i = 0; i < uiSlots.Length; i++)
        {
            if(uiSlots[i].item == null)
            {
                uiSlots[i].Set(item);
                return;
            }
        }
    }

    public void Set(int index)
    {
        selectedItem = uiSlots[index].item;
        selectedItemSprite.sprite = uiSlots[index].item.sprite;
        selectedItemName.text = uiSlots[index].item.name;
        selectedItemDescription.text = uiSlots[index].item.description;
        selectedIndex = index;

        selectedItemEffect.text = uiSlots[index].item.effect + " + " + uiSlots[index].item.value;

        if (uiSlots[index].item.type == 1 || uiSlots[index].item.type == 2)
        {
            if (uiSlots[index].equipped == true)
            {
                useButton.SetActive(false);
                equipButton.SetActive(false);
                unEquipButton.SetActive(true);
            }
            else
            {
                useButton.SetActive(false);
                unEquipButton.SetActive(false);
                equipButton.SetActive(true);
            }
        }
        else
        {
            unEquipButton.SetActive(false);
            equipButton.SetActive(false);
            useButton.SetActive(true);
        }
    }

    public void Equip(int index)
    {
        uiSlots[index].isEquipped();
    }

    public void UnEquip(int index)
    {
        uiSlots[index].unEquipped();
    }

    public int getValue(int index)
    {
        return uiSlots[index].item.value;
    }

    public string getEffect(int index)
    {
        return uiSlots[index].item.effect;
    }
}
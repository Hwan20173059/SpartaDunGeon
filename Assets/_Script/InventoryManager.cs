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
    private Item selectedItem;
    public Image selectedItemSprite;
    public Text selectedItemName;
    public Text selectedItemDescription;
    public Text selectedItemEffect;

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

    public void AddItem(Item item, int index)
    {
        uiSlots[index].Set(item);
    }

    public void Set(int index)
    {
        selectedItemSprite.sprite = uiSlots[index].item.sprite;
        selectedItem = uiSlots[index].item;
        selectedItemName.text = uiSlots[index].item.name;
        selectedItemDescription.text = uiSlots[index].item.description;

        selectedItemEffect.text = uiSlots[index].item.effect + " + " + uiSlots[index].item.value;

        if (uiSlots[index].item.type == 1 || uiSlots[index].item.type == 2)
        {
            if(uiSlots[index].equipped == true)
                unEquipButton.SetActive(true);
            else
                equipButton.SetActive(true);
        }
        else
            useButton.SetActive(true);
    }

    void UpdateUI()
    {
        
    }

    public void Equip(int index)
    {
        uiSlots[index].isEquipped();
    }

    public void UnEquip(int index)
    {

    }

    public void OnUnEquipButton()
    {

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
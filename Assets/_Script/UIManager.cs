using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private int _index;

    [Header("Manager")]
    public CharacterManager CharacterManager;
    public InventoryManager InventoryManager;
    public ShopManager shopManager;

    [Header("Character")]
    public Image characterImage;
    public Text nameText;
    public Text classText;
    public Text levelText;
    public Text goldText;
    public Slider expSlider;
    public Text expText;
    public Text shopGoldText;
    public Text PopUpWindowText;

    [Header("State")]
    public Text atkText;
    public Text defText;
    public Text healthText;
    public Text criticalText;

    [Header("UI")]
    public GameObject buttons;
    public GameObject inventory;
    public GameObject state;
    public GameObject equipUI;
    public GameObject ShopUI;
    public GameObject PopUpWindow;

    [Header("testItem")]
    public Item oldSword;
    public Item oldArmor;

    private void Start()
    {
        CharacterManager.expUpdate();
        uiUpdate();
    }

    public void uiUpdate()
    {
        nameText.text = CharacterManager.name;
        classText.text = CharacterManager.Class;
        goldText.text = CharacterManager.gold + "G";
        shopGoldText.text = CharacterManager.gold + "G";
        levelText.text = "Lv. " + CharacterManager.level.ToString();
        expSlider.value = (float)CharacterManager.curExp / CharacterManager.maxExp;
        expText.text = CharacterManager.curExp.ToString() + " / " + CharacterManager.maxExp.ToString();

        if (CharacterManager.equipAtk > 0)
            atkText.text = "공격력 : " + CharacterManager.atk.ToString() + " + " + CharacterManager.equipAtk.ToString();
        else
            atkText.text = "공격력 : " + CharacterManager.atk.ToString();

        if (CharacterManager.equipDef > 0)
            defText.text = "방어력 : " + CharacterManager.def.ToString() + " + " + CharacterManager.equipDef.ToString();
        else
            defText.text = "방어력 : " + CharacterManager.def.ToString();

        healthText.text = "체력 : " + CharacterManager.curHP.ToString() + "/" + CharacterManager.maxHP.ToString();
        criticalText.text = "회심률 : " + CharacterManager.cri.ToString();
    }

    public void OnItemSlotButton()
    {

    }

    public void OnInventoryButton()
    {
        buttons.SetActive(false);
        inventory.SetActive(true);
    }

    public void OnInventoryExitButton()
    {
        inventory.SetActive(false);
        buttons.SetActive(true);
    }

    public void OnEquipUIButton(int index)
    {
        InventoryManager.Set(index);
        equipUI.SetActive(true);
    }

    public void OnExitEquipUIButton()
    {
        equipUI.SetActive(false);
    }

    public void OnEquipButton()
    {
        int index = InventoryManager.selectedIndex;

        InventoryManager.Equip(index);

        if (InventoryManager.selectedItem.type == 1)
            CharacterManager.equipWeapon = true;
        else if (InventoryManager.selectedItem.type == 2)
            CharacterManager.equipArmor = true;


        if (InventoryManager.getEffect(index) == "공격력")
        {
            CharacterManager.equipAtk += InventoryManager.getValue(index);
        }
        else if (InventoryManager.getEffect(index) == "방어력")
        {
            CharacterManager.equipDef += InventoryManager.getValue(index);
        }

        uiUpdate();
        equipUI.SetActive(false);
    }

    public void OnUnEquipButton()
    {
        int index = InventoryManager.selectedIndex;

        InventoryManager.UnEquip(index);
        if (InventoryManager.getEffect(index) == "공격력")
        {
            CharacterManager.equipAtk -= InventoryManager.getValue(index);
        }
        else if (InventoryManager.getEffect(index) == "방어력")
        {
            CharacterManager.equipDef -= InventoryManager.getValue(index);
        }

        uiUpdate();
        equipUI.SetActive(false);
    }

    public void OnBuyButton()
    {

        if (shopManager.shopSlots[_index].CanBuy(CharacterManager.gold))
        {
            CharacterManager.gold -= shopManager.shopSlots[_index].Item.price;
            InventoryManager.AddItem(shopManager.shopSlots[_index].Item);
            PopUpWindow.SetActive(false);
            uiUpdate();
        }
        else
            return;
        
    }

    public void OnStateButton()
    {
        buttons.SetActive(false);
        state.SetActive(true);
    }

    public void OnStateExitButton()
    {
        state.SetActive(false);
        buttons.SetActive(true);        
    }

    public void OnTestEXPButton()
    {
        CharacterManager.increaseExp();
        uiUpdate();
    }

    public void OnTestHealButton()
    {
        CharacterManager.increaseHP();
        uiUpdate();
    }

    public void OnTestDamageButton()
    {
        CharacterManager.decreaseHP();
        uiUpdate();
    }

    public void OnTestGetItemButton()
    {
        InventoryManager.AddItem(oldSword);
        InventoryManager.AddItem(oldArmor);
    }

    public void OnShopButton()
    {
        buttons.SetActive(false);
        ShopUI.SetActive(true);
    }

    public void OnShopExitButton()
    {
        buttons.SetActive(true);
        ShopUI.SetActive(false);
    }

    public void OpenPopUpWindow(int index)
    {
        PopUpWindow.SetActive(true);
        _index = index;
    }

    public void PopUpWindowCancle()
    {
        PopUpWindow.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Manager")]
    public CharacterManager CharacterManager;
    public InventoryManager InventoryManager;

    [Header("Character")]
    public Image characterImage;
    public Text nameText;
    public Text classText;
    public Text levelText;
    public Text goldText;
    public Slider expSlider;
    public Text expText;

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
        levelText.text = "Lv. " + CharacterManager.level.ToString();
        expSlider.value = (float)CharacterManager.curExp / CharacterManager.maxExp;
        expText.text = CharacterManager.curExp.ToString() + " / " + CharacterManager.maxExp.ToString();

        atkText.text = "공격력 : " + CharacterManager.atk.ToString();
        defText.text = "방어력 : " + CharacterManager.def.ToString();
        healthText.text = "체력 : " + CharacterManager.maxHP.ToString() + "/" + CharacterManager.curHP.ToString();
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

    public void OnEquipButton(int index)
    {
        InventoryManager.Equip(index);
        if (InventoryManager.getEffect(index) == "공격력")
        {
            CharacterManager.equipAtk += InventoryManager.getValue(index);
        }
        else if (InventoryManager.getEffect(index) == "방어력")
        {
            CharacterManager.equipDef += InventoryManager.getValue(index);
        }
    }

    public void OnUnEquipButton(int index)
    {
        InventoryManager.Set(index);
        equipUI.SetActive(true);
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
        InventoryManager.AddItem(oldSword,0);
        InventoryManager.AddItem(oldArmor,1);
    }
}

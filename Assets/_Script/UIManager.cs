using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Manager")]
    public CharacterManager CharacterManager;

    [Header("Character")]
    public Image characterImage;
    public Text nameText;
    public Text classText;
    public Text levelText;
    public Text goldText;

    [Header("State")]
    public Text atkText;
    public Text defText;
    public Text healthText;
    public Text criticalText;

    [Header("UI")]
    public GameObject buttons;
    public GameObject inventory;
    public GameObject state;

    public void uiUpdate()
    {
        nameText.text = CharacterManager.name;
        classText.text = CharacterManager.Class;
        goldText.text = CharacterManager.gold + "G";
        levelText.text = "Lv. " + CharacterManager.level.ToString();
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
}

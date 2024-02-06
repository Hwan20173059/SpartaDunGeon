using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopSlotUI : MonoBehaviour
{
    public Item Item;
    public Image ItemSprite;
    public Text ItemName;
    public Text ItemDescription;
    public Text ItemEffect;
    public Text ItemPrice;

    public GameObject buyButton;

    public void Set(Item item)
    {
        this.Item = item;
        ItemSprite.sprite = item.sprite;
        ItemSprite.gameObject.SetActive(true);

        ItemName.text = item.name;
        ItemDescription.text = item.description;
        ItemPrice.text = item.price.ToString() + "G";

        ItemEffect.text = item.effect + " + " + item.value;
    }

    public void Clear()
    {
        ItemSprite.sprite = null;
        Item = null;
        ItemName.text = string.Empty;
        ItemDescription.text = string.Empty;
        ItemPrice.text = string.Empty;

        ItemEffect.text = string.Empty;
    }

    public bool CanBuy(int money)
    {
        if (money > Item.price)
            return true;
        else
            return false;
    }
}

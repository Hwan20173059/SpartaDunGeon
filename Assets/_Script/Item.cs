using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    [Header("index")]
    public int id;

    [Header("image")]
    public Sprite sprite;

    [Header("info")]
    public string name;
    public string description;
    public int type;

    [Header("effect")]
    public string effect;
    public int value;
    
}

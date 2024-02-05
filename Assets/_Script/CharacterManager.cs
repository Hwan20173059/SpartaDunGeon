using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    [Header("Name")]
    public string name;

    [Header("Level")]
    public int level;
    public int maxExp;
    public int curExp;

    [Header("State")]
    public string Class;
    public int maxHP;
    public int curHP;
    public int atk;
    public int def;

    [Header("Gold")]
    public int gold;
    
    public void expUpdate()
    {
        maxExp = level;

        if(curExp >= maxExp)
        {
            level++;
            curExp -= maxExp;
        }
    }
}

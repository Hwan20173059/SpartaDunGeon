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
    public int cri;

    [Header("Gold")]
    public int gold;

    [Header("Equip")]
    public bool equipWeapon;
    public bool equipArmor;
    public int equipAtk;
    public int equipDef;
    public int equipCri;

    public void expUpdate()
    {
        if(curExp >= maxExp)
        {
            level++;
            curExp -= maxExp;
        }
        maxExp = level;
    }

    public void hpUpdate()
    {
        if (curHP > maxHP)
        {
            curHP = maxHP;
        }

        if(curHP <= 0)
        {
            curHP = 0;
        }
    }

    public void increaseExp()
    {
        curExp++;
        expUpdate();
    }

    public void increaseHP()
    {
        curHP++;
        hpUpdate();
    }

    public void decreaseHP()
    {
        curHP -= 10;
        hpUpdate();
    }
}

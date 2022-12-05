using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    public Slider hpBar;

    private float curHP;

    public void SetTotalHP(int hp)
    {
        hpBar.maxValue = hp; // 아직 호출하지 않았다.
        hpBar.value = hp;
    }
 
    public void SetCurHP(int hp)
    {
        curHP = hp; // 그래서 지금 체력이 몇이냐?를 알려준다.
    }

    private void Update()
    {
        if (hpBar.value > curHP)
        {
            hpBar.value -= 0.01f;
        }
        if (hpBar.value < curHP)
        {
            hpBar.value += 0.01f;
        }
    }
}

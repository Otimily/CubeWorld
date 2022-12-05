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
        hpBar.maxValue = hp; // ���� ȣ������ �ʾҴ�.
        hpBar.value = hp;
    }
 
    public void SetCurHP(int hp)
    {
        curHP = hp; // �׷��� ���� ü���� ���̳�?�� �˷��ش�.
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeEnemy : MonoBehaviour
{
    public string EnemyName;

    public int HP = 10;
    public int Atk = 3;

    public int Cost = 60;

    [HideInInspector]
    public UINickname UINickname;
    HpBar uiHpBar;

    private void Start()
    {
        // ���� �Ҵ�
        Object nickname = Resources.Load("UINicknameenemy");
        GameObject uiObject = (GameObject)Instantiate(nickname, transform);


        UINickname = GetComponentInChildren<UINickname>();
        UINickname.SetName(EnemyName);

        // ���ҽ� �ε�
        Object hpBar = Resources.Load("UIHPBar");
        Instantiate(hpBar, transform);


        // ������ ����
        uiHpBar = GetComponentInChildren<HpBar>();

        // Ȱ��
        uiHpBar.SetTotalHP(HP);
        uiHpBar.SetCurHP(HP);
    }


    public void Ondamaged(CubeCharacter player)
    {
        HP -= player.Atk; //��������ŭ ������ �ϰڴ�.

        uiHpBar.SetCurHP(HP);

        if (HP <= 0)
        {
            HP = 0;
            player.GetMoney(Cost);
            Die();
        }
    }

    public void Die()
    {
        Debug.Log("YOU DIE" + EnemyName);
        Destroy(gameObject);
    }

}

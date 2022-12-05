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
        // 동적 할당
        Object nickname = Resources.Load("UINicknameenemy");
        GameObject uiObject = (GameObject)Instantiate(nickname, transform);


        UINickname = GetComponentInChildren<UINickname>();
        UINickname.SetName(EnemyName);

        // 리소스 로드
        Object hpBar = Resources.Load("UIHPBar");
        Instantiate(hpBar, transform);


        // 실제로 생성
        uiHpBar = GetComponentInChildren<HpBar>();

        // 활용
        uiHpBar.SetTotalHP(HP);
        uiHpBar.SetCurHP(HP);
    }


    public void Ondamaged(CubeCharacter player)
    {
        HP -= player.Atk; //데미지만큼 차감을 하겠다.

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

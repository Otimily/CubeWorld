using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeCharacter : MonoBehaviour
{

    public string playerName;
    public float speed = 1;

    public int HP = 20;
    public int Atk = 4;

    public int money = 0;

    UINickname uINickname;
    HpBar uiHpBar;

    UINickname UINickname;



    private void Start()
    {
        PlayerManager.Player = this;

        Object nickname = Resources.Load("UINickname");
        Instantiate(nickname, transform);

        UINickname = GetComponentInChildren<UINickname>();
        UINickname.SetName(playerName);

        // 리소스 로드
        Object hpBar = Resources.Load("UIHPBar");
        Instantiate(hpBar, transform);


        // 실제로 생성
        uiHpBar = GetComponentInChildren<HpBar>();

        // 활용
        uiHpBar.SetTotalHP(HP);
        uiHpBar.SetCurHP(HP);

        ////하지만 플레이어가 적을 생성해주는것은 흑막같은 행위이다.
        //Object enemy = Resources.Load("CubeEnemy");

        //for (int i =0; i < 10; i++)
        //{
        //    float x = Random.Range(-10, 10.0f);
        //    float z = Random.Range(-10, 10.0f);

        //    Instantiate(enemy, new Vector3(x, 0.5f, z), Quaternion.identity);
        //}

    }

    void Update()
    {
        float v = Input.GetAxis("Vertical"); //가로
        float h = Input.GetAxis("Horizontal"); //세로

        transform.position += new Vector3(h, 0, v) * 0.01f * speed;
        //                                         *곱하면 여기서 그만큼 속도가 줄어든다. 1*0.01같은 개념이다.

        // Debug.Log($"Vertical : {v}    Horizontal : {h}");

    }
    private void OnCollisionEnter(Collision collision)
    {
        CubeNPC npc = collision.gameObject.GetComponent<CubeNPC>();
        if (npc)
        {
            Debug.Log("NPC와 충돌 했습니다. - " + npc.npcName);

            UINickname.SetColor(Color.magenta);
            npc.UINickname.SetColor(Color.magenta);

            npc.UseNPC(this);
        }

        CubeEnemy enemy = collision.gameObject.GetComponent<CubeEnemy>();
        if (enemy)
        {
            Debug.Log("Enemy와 충돌 했습니다. - " + enemy.EnemyName);

            UINickname.SetColor(Color.red);
            enemy.UINickname.SetColor(Color.red);

            Ondamaged(enemy.Atk); //적에게 대미지를 넣은 만큼 공격이 들어간다
            enemy.Ondamaged(this);
        }

    }

    private void OnCollisionExit(Collision collision)
    {
        CubeNPC npc = collision.gameObject.GetComponent<CubeNPC>();
        if (npc)
        {

            UINickname.SetOriginColor();
            npc.UINickname.SetOriginColor();

            ShopManager.CloseShopUI();
        }

        CubeEnemy enemy = collision.gameObject.GetComponent<CubeEnemy>();
        if (enemy)
        {

            UINickname.SetOriginColor();
            enemy.UINickname.SetOriginColor();

            Ondamaged(enemy.Atk);
            enemy.Ondamaged(this);
            uiHpBar.SetCurHP(HP);

        }
    }

    public void Ondamaged(int damage)
    {
        HP -= damage; //데미지만큼 차감을 하겠다.

        if (HP <= 0)
        {
            HP = 0;
            Die();
        }
    }

    void Die()
    {
        Debug.Log("YOU DIE" + playerName);
        Destroy(gameObject);
    }

    public bool CanBuy(int money)
    {
        //롤 -> 외상 가능
        //외상 -10원

        if (this.money >= (money - 10))
            return true;
        else
            return false;
    }

    public void GetMoney(int money)
    {
        this.money += money;
    }

    public void SpendMoney(int money)
    {
        this.money -= money;

        if (this.money < 0)
        {
            this.money = 0;
        }
    }

    public void HealHp(int healAmount)
    {
        HP += healAmount;
        uiHpBar.SetCurHP(HP);

    }

    public void IncreaseAtk(int value)
    {
        Atk += value;
    }
    public void IncreaseBuff(int value)
    {
        HP += value;
    }

}

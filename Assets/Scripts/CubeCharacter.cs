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

        // ���ҽ� �ε�
        Object hpBar = Resources.Load("UIHPBar");
        Instantiate(hpBar, transform);


        // ������ ����
        uiHpBar = GetComponentInChildren<HpBar>();

        // Ȱ��
        uiHpBar.SetTotalHP(HP);
        uiHpBar.SetCurHP(HP);

        ////������ �÷��̾ ���� �������ִ°��� �渷���� �����̴�.
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
        float v = Input.GetAxis("Vertical"); //����
        float h = Input.GetAxis("Horizontal"); //����

        transform.position += new Vector3(h, 0, v) * 0.01f * speed;
        //                                         *���ϸ� ���⼭ �׸�ŭ �ӵ��� �پ���. 1*0.01���� �����̴�.

        // Debug.Log($"Vertical : {v}    Horizontal : {h}");

    }
    private void OnCollisionEnter(Collision collision)
    {
        CubeNPC npc = collision.gameObject.GetComponent<CubeNPC>();
        if (npc)
        {
            Debug.Log("NPC�� �浹 �߽��ϴ�. - " + npc.npcName);

            UINickname.SetColor(Color.magenta);
            npc.UINickname.SetColor(Color.magenta);

            npc.UseNPC(this);
        }

        CubeEnemy enemy = collision.gameObject.GetComponent<CubeEnemy>();
        if (enemy)
        {
            Debug.Log("Enemy�� �浹 �߽��ϴ�. - " + enemy.EnemyName);

            UINickname.SetColor(Color.red);
            enemy.UINickname.SetColor(Color.red);

            Ondamaged(enemy.Atk); //������ ������� ���� ��ŭ ������ ����
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
        HP -= damage; //��������ŭ ������ �ϰڴ�.

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
        //�� -> �ܻ� ����
        //�ܻ� -10��

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

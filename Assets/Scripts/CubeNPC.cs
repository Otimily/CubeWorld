using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum NpcType
{
    Shop,
    Heal,
    Move,
    support
}

public class CubeNPC : MonoBehaviour
{

    public string npcName;
    public NpcType npcType = NpcType.Heal;

    NPCGuid guid;

    [HideInInspector]
    public UINickname UINickname;


    private void Start()
    {
        guid = GetComponent<NPCGuid>();
        Object nickname = Resources.Load("UINicknamenpc");
        GameObject uiObject = (GameObject)Instantiate(nickname, transform);


        UINickname = GetComponentInChildren<UINickname>();
        UINickname.SetName(npcName);
    }

    public void UseNPC(CubeCharacter player)
    {
        // switch case �� �Ἥ npc�� ����� ���� ��

        switch (npcType)
        {
            case NpcType.Shop:
                UseShopNPC();
                break;

            case NpcType.Heal:
                UseHealNPC(player);
                break;

        }

        // if �� �Ἥ npc�� ����� ���� ��

        if (npcType == NpcType.Move)
            Debug.Log("�ȳ��ϼ���. �̵��� �����ִ� NPC�Դϴ�. ���� ���ðھ��?");

        if (npcType == NpcType.support)
            Debug.Log("�ȳ��ϼ���. ��带 ��ϴ� NPC�Դϴ�. ������ ���͵帱���?");

    }

    //public void StoreNPC()
    //{
    //    // npcType
    //    // �ȳ��ϼ���. ������ ��ϴ� NPC�Դϴ�.

    //    if (npcType == NpcType.Shop)
    //        Debug

    //    Debug.Log("�ȳ��ϼ���. ������ ��ϴ� NPC�Դϴ�. ������ �ŷ��Ͻðھ��?");
    //}

    //public void HealNPC()
    //{
    //    // npcType
    //    // �ȳ��ϼ���. ȸ���� �����ִ� NPC�Դϴ�.
    //    Debug.Log("�ȳ��ϼ���. ȸ���� �����ִ� NPC�Դϴ�. ȸ���Ͻðڽ��ϱ�?");
    //}

    //public void MoveNPC()
    //{
    //    // npcType
    //    // �ȳ��ϼ���. �̵��� �����ִ� NPC�Դϴ�.
    //    Debug.Log("�ȳ��ϼ���. ȸ���� �����ִ� NPC�Դϴ�. ȸ���Ͻðڽ��ϱ�?");
    //}

    //public void GildNPC()
    //{
    //    // npcType
    //    // �ȳ��ϼ���. ������ �����ִ� NPC�Դϴ�.
    //    Debug.Log("�ȳ��ϼ���. ȸ���� �����ִ� NPC�Դϴ�. ȸ���Ͻðڽ��ϱ�?");
    //}

    void UseShopNPC()
    {
        Debug.Log("�ȳ��ϼ���. ������ ��ϴ� NPC�Դϴ�. ������ �ŷ��Ͻðھ��?");
        
        guid.guid();
        
        ShopManager.OpenShopUI();
    }

    void UseHealNPC(CubeCharacter player)
    {
        Debug.Log("�ȳ��ϼ���. ȸ���� �����ִ� NPC�Դϴ�. ȸ���� �Ͻðڽ��ϱ�?");

        // if
        // ���� ����ϸ� ȸ��
        int healCost = 30;

        if (player.money >= 30)
        {
            // ���� ���
            player.SpendMoney(healCost);

            //ȸ��
            int healAmout = 5;
            player.HealHp(healAmout);

            Object effect = Resources.Load("HealEffect"); // 1. ���ҽ� �ε�
            Instantiate(effect, player.transform); // 2. �ε��� ���ҽ� ������ ����

        }
        else
        {
            //ȸ��X
            Debug.Log("CS�� �� ��������.");
        }

        // ���� ������� ������ ȸ��X

    }    
}

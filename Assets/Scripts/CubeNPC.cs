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
        // switch case 를 써서 npc의 기능을 적을 때

        switch (npcType)
        {
            case NpcType.Shop:
                UseShopNPC();
                break;

            case NpcType.Heal:
                UseHealNPC(player);
                break;

        }

        // if 를 써서 npc의 기능을 적을 때

        if (npcType == NpcType.Move)
            Debug.Log("안녕하세요. 이동을 도와주는 NPC입니다. 어디로 가시겠어요?");

        if (npcType == NpcType.support)
            Debug.Log("안녕하세요. 길드를 운영하는 NPC입니다. 무엇을 도와드릴까요?");

    }

    //public void StoreNPC()
    //{
    //    // npcType
    //    // 안녕하세요. 상점을 운영하는 NPC입니다.

    //    if (npcType == NpcType.Shop)
    //        Debug

    //    Debug.Log("안녕하세요. 상점을 운영하는 NPC입니다. 무엇을 거래하시겠어요?");
    //}

    //public void HealNPC()
    //{
    //    // npcType
    //    // 안녕하세요. 회복을 도와주는 NPC입니다.
    //    Debug.Log("안녕하세요. 회복을 도와주는 NPC입니다. 회복하시겠습니까?");
    //}

    //public void MoveNPC()
    //{
    //    // npcType
    //    // 안녕하세요. 이동을 도와주는 NPC입니다.
    //    Debug.Log("안녕하세요. 회복을 도와주는 NPC입니다. 회복하시겠습니까?");
    //}

    //public void GildNPC()
    //{
    //    // npcType
    //    // 안녕하세요. 버프을 도와주는 NPC입니다.
    //    Debug.Log("안녕하세요. 회복을 도와주는 NPC입니다. 회복하시겠습니까?");
    //}

    void UseShopNPC()
    {
        Debug.Log("안녕하세요. 상점을 운영하는 NPC입니다. 무엇을 거래하시겠어요?");
        
        guid.guid();
        
        ShopManager.OpenShopUI();
    }

    void UseHealNPC(CubeCharacter player)
    {
        Debug.Log("안녕하세요. 회복을 도와주는 NPC입니다. 회복을 하시겠습니까?");

        // if
        // 돈이 충분하면 회복
        int healCost = 30;

        if (player.money >= 30)
        {
            // 돈을 사용
            player.SpendMoney(healCost);

            //회복
            int healAmout = 5;
            player.HealHp(healAmout);

            Object effect = Resources.Load("HealEffect"); // 1. 리소스 로드
            Instantiate(effect, player.transform); // 2. 로드한 리소스 실제로 생성

        }
        else
        {
            //회복X
            Debug.Log("CS를 더 먹으세요.");
        }

        // 돈이 충분하지 않으면 회복X

    }    
}

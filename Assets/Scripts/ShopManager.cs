using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    static GameObject shop = null;

    public Text txtMoney;

    public static ShopItem[] itemDatas =
    {
        new ShopItem("bag1","아이템 1", 10, 0, 3),
        new ShopItem("bag2","아이템 2", 20, 0, 5),
        new ShopItem("ch1","아이템 3", 30, 6, 0),
        new ShopItem("ch2","아이템 4", 40, 8, 0)
    };


    public static void OpenShopUI()
    {
        // 상점이 null 일때만 ui 생성
        if (shop == null)
        {
            Object shopObject = Resources.Load("UIShop");
            shop =(GameObject)Instantiate(shopObject);

        }

        shop.SetActive(true);
    }

    public static void CloseShopUI()
    {
        if (shop != null)
        {
            shop.SetActive(false);
        }
    }

    public static void BuyItem(CubeCharacter player, ShopItem item)
    {
        Debug.Log("안녕하세요. 무엇을 거래하시겠어요?");

        if (player.money - item.itemPrice >= 0)
        {
            // 돈을 사용
            player.money = player.money - item.itemPrice;

            //공력력or체력 증가
            int attackAmout = 5;
            
            Debug.Log( item.resName + "아이템을 구매하셨군요. 감사합니다!");
        }

        else
        {
            // 구매 실패
            Debug.Log("금액이 부족하군요. 다른건 어때요?");
        }
    }

}

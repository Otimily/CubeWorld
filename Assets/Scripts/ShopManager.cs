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
        new ShopItem("bag1","������ 1", 10, 0, 3),
        new ShopItem("bag2","������ 2", 20, 0, 5),
        new ShopItem("ch1","������ 3", 30, 6, 0),
        new ShopItem("ch2","������ 4", 40, 8, 0)
    };


    public static void OpenShopUI()
    {
        // ������ null �϶��� ui ����
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
        Debug.Log("�ȳ��ϼ���. ������ �ŷ��Ͻðھ��?");

        if (player.money - item.itemPrice >= 0)
        {
            // ���� ���
            player.money = player.money - item.itemPrice;

            //���·�orü�� ����
            int attackAmout = 5;
            
            Debug.Log( item.resName + "�������� �����ϼ̱���. �����մϴ�!");
        }

        else
        {
            // ���� ����
            Debug.Log("�ݾ��� �����ϱ���. �ٸ��� ���?");
        }
    }

}

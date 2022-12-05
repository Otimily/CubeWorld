using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;



public class UIShopItem : MonoBehaviour
{
    // �ڱ� �ڽ��� ������ butten
    public Button btnItem;

    // �̹���
    public Image imgItem;

    // text �̸�
    public TMP_Text txtName;

    // text ����
    public TMP_Text txtPrice;

    // text ����
    public TMP_Text txtBuff;

    // text ���ݷ�
    public TMP_Text txtAtk;

    public void SetReference()
    {
        
        btnItem = GetComponent<Button>();
        btnItem.onClick.AddListener(BuyItem);

        // texts - 3
        // 0 : txtItemName
        // 1 : txtItemCost
        // 2 : txtItemOption
        TMP_Text[] TMP_Texts = GetComponentsInChildren<TMP_Text>();



        txtName = TMP_Texts[0];
        txtPrice = TMP_Texts[1];
        txtBuff = TMP_Texts[2];
        txtAtk = TMP_Texts[3];

    }

    public void SetItemInfo(string itemImage, string itemName, int itemPrice, string itemBuff, int itemAtk)
    {
        // "Emage/XXX"       
        txtName.text = itemName;
        //txtPrice.text = itemPrice + "g";
        txtPrice.text = $"{itemPrice}g";
        txtBuff.text = itemBuff;
        txtAtk.text = $"{itemAtk}";

        Sprite sprite = Resources.Load<Sprite>("Emage/" + itemImage);
        imgItem.sprite = sprite;
    }


    ShopItem itemData;
    public void SetItemInfo(ShopItem data)
    {
        itemData = data;
        txtName.text = itemData.itemName;
        txtPrice.text = $"{itemData.itemPrice}g";
        txtBuff.text = $"{itemData.itemBuff}";
        txtAtk.text = $"{itemData.itemAtk}";

        Sprite sprite = Resources.Load<Sprite>("Emage/" + itemData.resName);
        imgItem.sprite = sprite;
    }
    void BuyItem()
    {
        Debug.Log("�������� �����߽��ϴ�.");
        Debug.Log("$������ �̸� : {txtName.text} ������ ���� : {txtPrice.text}");

        //������ üũ�� �ؾ��ϰ�
        //price -> ������ üũ

        //ĳ���Ͱ� ������ �ִ� ���� ������ üũ
        //PlayerManager.Player.money

        if (itemData.itemPrice <= PlayerManager.Player.money) 
        {
            PlayerManager.Player.SpendMoney(itemData.itemPrice);
            PlayerManager.Player.IncreaseAtk(itemData.itemAtk);
            PlayerManager.Player.IncreaseBuff(itemData.itemBuff);
            Debug.Log($"������ �̸� : {name}�� �����߽��ϴ�.");
        }
        else
        {
            //���� ����
            Debug.Log($"���� �����մϴ�. �ʿ��� �� : {txtPrice}   ������ : {PlayerManager.Player.money}");
        }

        //���� ����ϴٸ� ĳ������ ���� �������� ���ݸ�ŭ �����ϰ�
        //������ �̸� : 000 �� �����߽��ϴ�.

        //������� �ʴٸ�
        //���� �����մϴ�. �ʿ��� �� : 00      ������ : 00

    }



}

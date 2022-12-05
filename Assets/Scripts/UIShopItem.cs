using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;



public class UIShopItem : MonoBehaviour
{
    // 자기 자신을 가지는 butten
    public Button btnItem;

    // 이미지
    public Image imgItem;

    // text 이름
    public TMP_Text txtName;

    // text 가격
    public TMP_Text txtPrice;

    // text 버프
    public TMP_Text txtBuff;

    // text 공격력
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
        Debug.Log("아이템을 구매했습니다.");
        Debug.Log("$아이템 이름 : {txtName.text} 아이템 가격 : {txtPrice.text}");

        //얼마인지 체크를 해야하고
        //price -> 얼마인지 체크

        //캐릭터가 가지고 있는 돈이 얼마인지 체크
        //PlayerManager.Player.money

        if (itemData.itemPrice <= PlayerManager.Player.money) 
        {
            PlayerManager.Player.SpendMoney(itemData.itemPrice);
            PlayerManager.Player.IncreaseAtk(itemData.itemAtk);
            PlayerManager.Player.IncreaseBuff(itemData.itemBuff);
            Debug.Log($"아이템 이름 : {name}을 구매했습니다.");
        }
        else
        {
            //구매 실패
            Debug.Log($"돈이 부족합니다. 필요한 돈 : {txtPrice}   소지금 : {PlayerManager.Player.money}");
        }

        //돈이 충분하다면 캐릭터의 돈을 아이템의 가격만큼 차감하고
        //아이템 이름 : 000 을 구매했습니다.

        //충분하지 않다면
        //돈이 부족합니다. 필요한 돈 : 00      소지금 : 00

    }



}

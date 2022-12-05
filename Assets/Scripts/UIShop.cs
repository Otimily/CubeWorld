using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIShop : MonoBehaviour
{
    public Transform itemRoot;

    public Button btnConfirm;
    public Button[] btnItems;
    public Button[] btns;

    //public UIShopItem[] uiItems;


    private void Start()
    {
        btns = GetComponentsInChildren<Button>();
        btnConfirm = btns[0];

        //uiItems = GetComponentsInChildren<UIShopItem>();

        for (int i = 0; i < ShopManager.itemDatas.Length; i++)
        {
            ShopItem item = ShopManager.itemDatas[i];
            //uiItems[0].SetItemInfo(item.itemName, item.itemPrice,item.itemBuff); //10원

            //리소스 로드
            Object itemObject = Resources.Load("btnItem");
            //로드된 것을 생성
            GameObject itemGameObject = (GameObject)Instantiate(itemObject, itemRoot);

            UIShopItem uIShopItem = itemGameObject.GetComponent<UIShopItem>(); //생성된 리소스에서 필요한 속성 찾기
            uIShopItem.SetReference();
            uIShopItem.SetItemInfo(item); // 찾아준 속성에 정보 입력
        }

    }
}

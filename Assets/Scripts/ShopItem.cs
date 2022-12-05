using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem
{
    public string resName;
    public string itemName;
    public int itemPrice;
    public int itemBuff;
    public int itemAtk;

    public ShopItem(string image, string name, int price, int buff, int atk)
    {
        resName = image;
        itemName = name;
        itemPrice = price;
        itemBuff = buff;
        itemAtk = atk;
    }
}

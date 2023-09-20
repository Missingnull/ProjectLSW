using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerShopController : MonoBehaviour
{
    VisualElement root;
    Label dialog;
    Button Item0;
    Button Item1;
    Button Item2;
    Button Item3;

    int playerCash = 200;
    int shopCash = 100;

    void Awake()
    {
        // Register inventory and shop items
        root = GetComponent<UIDocument>().rootVisualElement;
        dialog = root.Q<Label>("Label_Dialog");
        Item0 = root.Q<Button>("VE_Item0");
        Item1 = root.Q<Button>("VE_Item1");
        Item2 = root.Q<Button>("VE_Item2");
        Item3 = root.Q<Button>("VE_Item3");

        // Update player and shop cash labels
        UpdateWallets();
    }

    private void OnEnable()
    {
        // Process input
        Item1.clicked += () => ProcessTransaction(Item1);
        Item2.clicked += () => ProcessTransaction(Item2);
        Item3.clicked += () => ProcessTransaction(Item3);
    }

    private void ProcessTransaction(Button item)
    {
        int price = int.Parse(item.text);

        // Sell item
        if (item.parent.parent.name == "VE_PlayerItems") // item.(item row).(player/shop inventory)
        {
            if (price <= shopCash)
            {
                shopCash = shopCash - price;
                playerCash = playerCash + price;
                UpdateWallets();
                root.Q<GroupBox>("GB_ShopItemsRow1").Insert(0, item);
                dialog.text = "Changed your mind, eh? Heh heh";
            }
            else
            {
                dialog.text = "Sorry, I can't afford that.";
            }
        }

        // Purchase Item
        else if (item.parent.parent.name == "VE_ShopItems")
        {
            if (price <= playerCash)
            {
                playerCash = playerCash - price;
                shopCash = shopCash + price;
                UpdateWallets();
                root.Q<GroupBox>("GB_PlayerItemsRow1").Insert(1, item);
                dialog.text = "Heh heh heh thank you!";
            }
            else
            {
                dialog.text = "Sorry, but you don't seem to have the cash.";
            }
        }
    }

    private void UpdateWallets()
    {
        root.Q<Label>("Label_PlayerCashValue").text = "$" + playerCash.ToString();
        root.Q<Label>("Label_ShopCashValue").text = "$" + shopCash.ToString();
    }
}

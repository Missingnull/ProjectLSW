using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerShopController : MonoBehaviour
{
    VisualElement root;
    Button Item0;
    Button Item1;
    Button Item2;
    Button Item3;

    int playerCash = 100;
    int shopCash = 300;

    void Awake()
    {
        // Register inventory and shop items
        root = GetComponent<UIDocument>().rootVisualElement;
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

    private void ProcessTransaction(VisualElement item)
    {
        // Sell item
        if (item.parent.parent.name == "VE_PlayerItems") // item.(item row).(player/shop inventory)
        {
            root.Q<GroupBox>("GB_ShopItemsRow1").Insert(0, item);
        }
        // Purchase Item
        else if (item.parent.parent.name == "VE_ShopItems")
        {
            root.Q<GroupBox>("GB_PlayerItemsRow1").Insert(1, item);
        }
    }

    private void UpdateWallets()
    {
        root.Q<Label>("Label_PlayerCashValue").text = "$" + playerCash.ToString();
        root.Q<Label>("Label_ShopCashValue").text = "$" + shopCash.ToString();
    }
}

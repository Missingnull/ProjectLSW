using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerShopController : MonoBehaviour
{
    VisualElement root;
    Button shopItem1;

    int playerCash = 100;
    int shopCash = 300;

    void Awake()
    {
        // Register inventory and shop items
        root = GetComponent<UIDocument>().rootVisualElement;
        shopItem1 = root.Q<Button>("VE_ShopItem1");

        // Update player and shop cash labels
        UpdateWallets();
    }

    private void OnEnable()
    {
        // Process input
        shopItem1.clicked += () => root.Q<GroupBox>("GB_PlayerItemsRow1").Insert(0, shopItem1);
    }

    private void UpdateWallets()
    {
        root.Q<Label>("Label_PlayerCashValue").text = "$" + playerCash.ToString();
        root.Q<Label>("Label_ShopCashValue").text = "$" + shopCash.ToString();
    }
}

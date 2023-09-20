using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIController : MonoBehaviour
{
    VisualElement root;
    Button shopItem1;

    int playerCash = 100;
    int shopCash = 300;

    void Awake()
    {
        // Register inventory and shop items
        root = GetComponent<UIDocument>().rootVisualElement;
        shopItem1 = root.Q<Button>("ShopItem1");

        // Update player and shop cash labels
        UpdateWallets();
    }

    private void OnEnable()
    {
        // Process input
        shopItem1.clicked += () => root.Q<GroupBox>("GroupPlayerItemsRow1").Insert(0, shopItem1);
    }

    private void UpdateWallets()
    {
        root.Q<Label>("LabelPlayerCashValue").text = "$" + playerCash.ToString();
        root.Q<Label>("LabelShopCashValue").text = "$" + shopCash.ToString();
    }
}

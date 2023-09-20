using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UIElements;
using Cursor = UnityEngine.Cursor;

public class PlayerShopController : MonoBehaviour
{
    VisualElement root;
    Label dialog;
    Button Item0;
    Button Item1;
    Button Item2;
    Button Item3;
    Button EquipItem0;
    Button EquipItem1;
    Button EquipItem2;
    Button EquipItem3;

    public GameObject playerBody;
    public Sprite item0Sprite;
    public Sprite item1Sprite;
    public Sprite item2Sprite;
    public Sprite item3Sprite;

    int playerCash = 200;
    int shopCash = 100;

    Vector2 bugfix = new Vector2(0,0);

    void Awake()
    {
        // Register inventory and shop items
        root = GetComponent<UIDocument>().rootVisualElement;
        dialog = root.Q<Label>("Label_Dialog");

        Item0 = root.Q<Button>("Button_Item0");
        Item1 = root.Q<Button>("Button_Item1");
        Item2 = root.Q<Button>("Button_Item2");
        Item3 = root.Q<Button>("Button_Item3");

        EquipItem0 = (Button)Item0.ElementAt(0);
        EquipItem1 = (Button)Item1.ElementAt(0);
        EquipItem2 = (Button)Item2.ElementAt(0);
        EquipItem3 = (Button)Item3.ElementAt(0);

        // Update player and shop cash labels
        UpdateWallets();
    }

    private void OnEnable()
    {
        // Dixing a Unity bug
        Cursor.SetCursor(null, bugfix, 0);

        // Process input
        Item1.clicked += () => ProcessTransaction(Item1);
        Item2.clicked += () => ProcessTransaction(Item2);
        Item3.clicked += () => ProcessTransaction(Item3);

        EquipItem0.clicked += () => EquipItem(item0Sprite);
        EquipItem1.clicked += () => EquipItem(item1Sprite);
        EquipItem2.clicked += () => EquipItem(item2Sprite);
        EquipItem3.clicked += () => EquipItem(item3Sprite);
    }

    private void ProcessTransaction(Button item)
    {
        int price = int.Parse(item.text);

        // Sell item
        if (item.parent.parent.name == "VE_PlayerItems") // item.(item row).(player/shop inventory)
        {
            if (price <= shopCash)
            {
                shopCash -= price;
                playerCash += price;
                UpdateWallets();
                root.Q<GroupBox>("GB_ShopItemsRow1").Insert(0, item);
                item.ElementAt(0).visible = false;
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
                playerCash -= price;
                shopCash += price;
                UpdateWallets();
                root.Q<GroupBox>("GB_PlayerItemsRow1").Insert(1, item);
                item.ElementAt(0).visible = true;
                dialog.text = "Heh heh heh thank you!";
            }
            else
            {
                dialog.text = "Sorry, but you don't seem to have the cash.";
            }
        }
    }

    private void EquipItem(Sprite sprite)
    {
        playerBody.GetComponent<SpriteRenderer>().sprite = sprite;
    }

    private void UpdateWallets()
    {
        root.Q<Label>("Label_PlayerCashValue").text = "$" + playerCash.ToString();
        root.Q<Label>("Label_ShopCashValue").text = "$" + shopCash.ToString();
    }
}

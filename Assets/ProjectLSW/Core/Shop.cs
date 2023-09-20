using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Shop : MonoBehaviour
{
    public GameObject player;
    public PlayerController playerController;
    public BoxCollider2D boxCollider;
    public TextMesh textLabel;
    public UIDocument UIDocument;

    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Detect the player entering/leaving the vicinity,
    // and listen/stop listening to 'interact' event

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.attachedRigidbody.CompareTag("Player"))
        {
            playerController.interact.AddListener(ShowShopUI);
            textLabel.text = "Press [F] to Shop";
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.attachedRigidbody.CompareTag("Player"))
        {
            playerController.interact.RemoveListener(ShowShopUI);
            textLabel.text = "Come back anytime!";
        }
    }

    public void ShowShopUI()
    {
        UIDocument.enabled = true;
        UIDocument.GetComponent<UIController>().enabled = true;
    }
}

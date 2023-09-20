using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public BoxCollider2D boxCollider;
    public TextMesh textLabel;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // Detect the player entering or leaving the vicinity

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.attachedRigidbody.CompareTag("Player"))
        {
            textLabel.text = "Press [F] to Shop";
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.attachedRigidbody.CompareTag("Player"))
        {
            textLabel.text = "Come back anytime!";
        }
    }
}

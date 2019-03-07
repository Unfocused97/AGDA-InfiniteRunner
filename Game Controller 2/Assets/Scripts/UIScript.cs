using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour {

    public Text inventory;
    public GameObject player;
    // Use this for initialization
    void Start () {
        inventory.text = "Collected: \n";
	}
	
	// Update is called once per frame
	void Update () {
        DisplayInventory();
	}

    // Update the inventory being displayed
    void DisplayInventory()
    {
        inventory.text = "Collected \n";
        foreach (string key in player.GetComponent<ItemCollection>().collectedItems.Keys)
        {
            int num = player.GetComponent<ItemCollection>().collectedItems[key];
            inventory.text += key + "\n x" + num + "\n";
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public string ingredient;
    public int weight;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // transform.Rotate(0,0, 90 * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Ball")
        {
            //moved to new item collection script
            //other.GetComponent<ScoreScript>().points++;
            other.GetComponent<PlayerController>().Speed -= 0.3f;
            other.GetComponent<ItemCollection>().collectedItems.Add(ingredient, weight);
            // Coin gets removed
            Destroy(gameObject);
        }
    }
}
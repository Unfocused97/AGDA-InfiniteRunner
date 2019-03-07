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
        //transform.Rotate(0,0, 90 * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Ball")
        {
            other.GetComponent<PlayerController>().Speed -= 0.3f;
            AddToCollected(other);

            // Coin gets removed
            Destroy(gameObject);
        }
    }
    

    private void AddToCollected(Collider other)
    {
        if (other.GetComponent<ItemCollection>().collectedItems.ContainsKey(ingredient))
        {
            int num;
            other.GetComponent<ItemCollection>().collectedItems.TryGetValue(ingredient, out num);
            other.GetComponent<ItemCollection>().collectedItems.Remove(ingredient);
            other.GetComponent<ItemCollection>().collectedItems.Add(ingredient, num + 1);
        }else
        {
            other.GetComponent<ItemCollection>().collectedItems.Add(ingredient, 1);
        }
    }
}
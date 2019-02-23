using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public string ingredient;
    public int weight;
    public GameObject text;
    private Vector3 textPos = new Vector3(1, 1, 0);

    // Use this for initialization
    void Start()
    {
        text.GetComponent<TextMesh>().text = this.ingredient + " picked up!!";
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
            // pop up text
            text.GetComponent<TextMesh>().text = this.ingredient + " picked up!!";
            GameObject yes = Instantiate(text, new Vector3(other.transform.position.x, other.transform.position.y + 1, other.transform.position.z), new Quaternion(0, 0, 0, 0));
            // need to do something about adjusting this speed
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
            other.GetComponent<ItemCollection>().collectedItems.Add(ingredient, num);
        }else
        {
            other.GetComponent<ItemCollection>().collectedItems.Add(ingredient, 1);
        }
    }
}
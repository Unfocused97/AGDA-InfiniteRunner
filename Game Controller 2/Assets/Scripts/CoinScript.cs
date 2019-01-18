using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{

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
            other.GetComponent<ScoreScript>().points++;
            // Coin gets removed
            Destroy(gameObject);
        }
    }
}
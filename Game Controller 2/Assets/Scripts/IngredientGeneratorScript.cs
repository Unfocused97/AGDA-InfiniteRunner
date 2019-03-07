using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientGeneratorScript : MonoBehaviour {
    string[] ingredients = { "tomato", "lettuce", "carrots", "onion", "potato",
        "spinach", "baguette", "ketchup", "olive oil", "mayo", //end of 50 pt ingredients
        "eggplant", "pumpkin", "drumsticks", "wings", "sausage",
        "egg", "noodles", "penne", "rice", "pesto", // end of 100pt ing
        "chicken", "shrimp", "bun", "cheese", // end of 150pt ing
        "steak", "patty", "flour" }; // end of 200pt ing

    int FiftyPointRange = 10;
    int HundredPointRange = 20;
    int HundredFiftyRange = 24;
    int TwoHundredRange = 27;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // Get a randomly chosen ingredient string
    string ingredientGenerate()
    {
        int ing;
        int i;

        // change the range to adjust probability/weight
        i = Random.Range(0, 10);

        // change the i conditions to adust the probability/weight
        if (i > 5) ing = Random.RandomRange(0, FiftyPointRange);
        else if (i > 2) ing = Random.RandomRange(FiftyPointRange, HundredPointRange);
        else if (i > 1) ing = Random.RandomRange(HundredPointRange, HundredFiftyRange);
        else ing = Random.RandomRange(HundredFiftyRange, TwoHundredRange);
        return ingredients[ing];
    }
}

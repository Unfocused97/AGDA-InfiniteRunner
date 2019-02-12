using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollection : MonoBehaviour {
    // list all the recipes???????
    static string bun = "bun";
    static string sausage = "sausage";
    static string ketchup = "ketchup";
    static string noodles = "noodles";
    static string cheese = "cheese";
    private HashSet<string> hotdogRecipe = new HashSet<string> { bun, sausage, ketchup };
    private HashSet<string> spaghettiCarbonaraRecipe = new HashSet<string> { noodles, sausage, cheese };


    // each item is <ingredient Name, weight>
    public IDictionary<string, int> ingredientList = new Dictionary<string, int>();

    //key is ingredient name, int is the number collected
    public IDictionary<string, int> collectedItems = new Dictionary<string, int>();

    // key is recipe Hashset, value is points given by score
    private IDictionary<HashSet<string>, int> scoreSet = new Dictionary<HashSet<string>, int>();

    // Use this for initialization
    void Start () {

        ingredientList.Add(bun, 150);
        ingredientList.Add(sausage, 100);
        ingredientList.Add(ketchup, 50);
        ingredientList.Add(noodles, 100);
        ingredientList.Add(cheese, 150);

        scoreSet.Add(hotdogRecipe, RecipeScore(hotdogRecipe));
        scoreSet.Add(spaghettiCarbonaraRecipe, RecipeScore(spaghettiCarbonaraRecipe));
        
	}
	
	// Update is called once per frame
	void Update () {

        if (spaghettiCarbonaraRecipe.IsSubsetOf(collectedItems.Keys))
        {
            MakeDish(spaghettiCarbonaraRecipe);
        }
        else if (hotdogRecipe.IsSubsetOf(collectedItems.Keys)) {
            MakeDish(hotdogRecipe);
        }
	}

    int RecipeScore (HashSet<string> recipe)
    {
        int score = 0;
        foreach (string str in recipe)
        {
            int ingScore;
            ingredientList.TryGetValue(str, out ingScore);
            score += ingScore;
        }
        return score;
    }

    void UseIngredients (HashSet<string> recipe)
    {
        foreach (string str in recipe)
        {
            collectedItems.Remove(str);
        }
    }

    void MakeDish(HashSet<string> recipe)
    {

        UseIngredients(recipe);
        int earnedPoints;
        scoreSet.TryGetValue(recipe, out earnedPoints);

        GetComponent<ScoreScript>().points += earnedPoints;
    }
}

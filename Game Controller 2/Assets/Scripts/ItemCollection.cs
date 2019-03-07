using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollection : MonoBehaviour {

    public Text scoreDisplay;

    #region ingredient variables
    // list all ingredient variables
    static string bun = "bun";
    static string sausage = "sausage";
    static string ketchup = "ketchup";
    static string noodles = "noodles";
    static string cheese = "cheese";
    static string patty = "patty";
    static string tomato = "tomato";
    static string onion = "onion";
    static string lettuce = "lettuce";
    static string spinach = "spinach";
    static string egg = "egg";
    static string olive_oil = "olive oil";
    static string baguette = "baguette";
    static string rice = "rice";
    static string shrimp = "shrimp";
    static string eggplant = "eggplant";
    static string pumpkin = "pumpkin";
    static string steak = "steak";
    static string potato = "potato";
    static string drumsticks = "drumsticks";
    static string wings = "wings";
    static string mayo = "mayo";
    static string flour = "flour";
    static string carrots = "carrots";
    static string penne = "penne";
    static string pesto = "pesto";
    static string chicken = "chicken";

    #endregion

    #region recipe HashSets
    private HashSet<string> hamburgerRecipe = new HashSet<string> { bun, patty, ketchup, lettuce, tomato, onion, cheese };
    private HashSet<string> hotdogRecipe = new HashSet<string> { bun, sausage, ketchup };
    private HashSet<string> chefSaladRecipe = new HashSet<string> { tomato, lettuce, spinach, onion, egg, olive_oil, baguette };
    private HashSet<string> spaghettiCarbonaraRecipe = new HashSet<string> { noodles, sausage, cheese };
    private HashSet<string> paellaRecipe = new HashSet<string> { rice, shrimp, onion, eggplant };
    private HashSet<string> chickenPenneRecipe = new HashSet<string> { penne, pesto, chicken, olive_oil };
    private HashSet<string> ratatouilleRecipe = new HashSet<string> { tomato, eggplant, pumpkin, olive_oil, onion };
    private HashSet<string> tenderloinSteakRecipe = new HashSet<string> { steak, potato, spinach };
    private HashSet<string> friesRecipe = new HashSet<string> { potato, olive_oil };
    private HashSet<string> friedComboRecipe = new HashSet<string> { olive_oil, drumsticks, wings, onion, potato };
    private HashSet<string> sandwichRecipe = new HashSet<string> { baguette, egg, cheese, tomato, mayo };
    private HashSet<string> tempuraRecipe = new HashSet<string> { shrimp, potato, eggplant, egg, flour };
    private HashSet<string> pumpkinPieRecipe = new HashSet<string> { pumpkin, flour, egg };
    private HashSet<string> friedRiceRecipe = new HashSet<string> { rice, egg, sausage, carrots };
    private HashSet<string> potatoSalad = new HashSet<string> { potato, onion, spinach, mayo };

    #endregion

    // each item is <ingredient Name, weight>
    public IDictionary<string, int> ingredientList = new Dictionary<string, int>();

    //key is ingredient name, int is the number collected
    public IDictionary<string, int> collectedItems = new Dictionary<string, int>();

    // key is recipe Hashset, value is points given by score
    private IDictionary<HashSet<string>, int> scoreSet = new Dictionary<HashSet<string>, int>();

    // Use this for initialization
    void Start () {

        #region add ingredients and scores to ingredientList
        ingredientList.Add(tomato, 50);
        ingredientList.Add(lettuce, 50);
        ingredientList.Add(carrots, 50);
        ingredientList.Add(onion, 50);
        ingredientList.Add(potato, 50);
        ingredientList.Add(spinach, 50);
        ingredientList.Add(baguette, 50);
        ingredientList.Add(ketchup, 50);
        ingredientList.Add(olive_oil, 50);
        ingredientList.Add(mayo, 50);
        ingredientList.Add(eggplant, 100);
        ingredientList.Add(pumpkin, 100);
        ingredientList.Add(drumsticks, 100);
        ingredientList.Add(wings, 100);
        ingredientList.Add(sausage, 100);
        ingredientList.Add(egg, 100);
        ingredientList.Add(noodles, 100);
        ingredientList.Add(penne, 100);
        ingredientList.Add(rice, 100);
        ingredientList.Add(pesto, 100);
        ingredientList.Add(chicken, 150);
        ingredientList.Add(bun, 150);
        ingredientList.Add(cheese, 150);
        ingredientList.Add(steak, 200);
        ingredientList.Add(patty, 200);
        ingredientList.Add(flour, 200);
        #endregion

        #region add recipe scores to scoreSet

        scoreSet.Add(hamburgerRecipe, RecipeScore(hamburgerRecipe)); 
        scoreSet.Add(hotdogRecipe, RecipeScore(hotdogRecipe)); 
        scoreSet.Add(chefSaladRecipe, RecipeScore(chefSaladRecipe));
        scoreSet.Add(spaghettiCarbonaraRecipe, RecipeScore(spaghettiCarbonaraRecipe));
        scoreSet.Add(paellaRecipe, RecipeScore(paellaRecipe));
        scoreSet.Add(chickenPenneRecipe, RecipeScore(chickenPenneRecipe));
        scoreSet.Add(ratatouilleRecipe, RecipeScore(ratatouilleRecipe));
        scoreSet.Add(tenderloinSteakRecipe, RecipeScore(tenderloinSteakRecipe));
        scoreSet.Add(friesRecipe, RecipeScore(friesRecipe));
        scoreSet.Add(friedComboRecipe, RecipeScore(friedComboRecipe));
        scoreSet.Add(sandwichRecipe, RecipeScore(sandwichRecipe));
        scoreSet.Add(tempuraRecipe, RecipeScore(tempuraRecipe));
        scoreSet.Add(pumpkinPieRecipe, RecipeScore(pumpkinPieRecipe));
        scoreSet.Add(friedRiceRecipe, RecipeScore(friedRiceRecipe));
        scoreSet.Add(potatoSalad, RecipeScore(potatoSalad));
        #endregion
        

    }

    // Update is called once per frame
    void Update () {
        // should maybe change the following into a switch case statement
        #region check which dish is met, huge if statement
        if (hamburgerRecipe.IsSubsetOf(collectedItems.Keys))
        {
            MakeDish(hamburgerRecipe);
        }
        else if (tempuraRecipe.IsSubsetOf(collectedItems.Keys))
        {
            MakeDish(tempuraRecipe);
        }
        else if (chefSaladRecipe.IsSubsetOf(collectedItems.Keys))
        {
            MakeDish(chefSaladRecipe);
        }
        else if (sandwichRecipe.IsSubsetOf(collectedItems.Keys))
        {
            MakeDish(sandwichRecipe);
        }
        else if (pumpkinPieRecipe.IsSubsetOf(collectedItems.Keys))
        {
            MakeDish(pumpkinPieRecipe);
        }
        else if (chickenPenneRecipe.IsSubsetOf(collectedItems.Keys))
        {
            MakeDish(chickenPenneRecipe);
        }
        else if (ratatouilleRecipe.IsSubsetOf(collectedItems.Keys))
        {
            MakeDish(ratatouilleRecipe);
        }
        else if (friedComboRecipe.IsSubsetOf(collectedItems.Keys))
        {
            MakeDish(friedComboRecipe);
        }
        else if (friedRiceRecipe.IsSubsetOf(collectedItems.Keys))
        {
            MakeDish(friedRiceRecipe);
        }
        else if (spaghettiCarbonaraRecipe.IsSubsetOf(collectedItems.Keys))
        {
            MakeDish(spaghettiCarbonaraRecipe);
        }
        else if (hotdogRecipe.IsSubsetOf(collectedItems.Keys)) {
            MakeDish(hotdogRecipe);
        }
        else if (tenderloinSteakRecipe.IsSubsetOf(collectedItems.Keys))
        {
            MakeDish(tenderloinSteakRecipe);
        }
        else if (paellaRecipe.IsSubsetOf(collectedItems.Keys))
        {
            MakeDish(paellaRecipe);
        }
        else if (potatoSalad.IsSubsetOf(collectedItems.Keys))
        {
            MakeDish(potatoSalad);
        }
        else if (friesRecipe.IsSubsetOf(collectedItems.Keys))
        {
            MakeDish(friesRecipe);
        }
        #endregion 
    }

    // return the score of the dish provided the recipe
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

    // remove ingredients from collected list after making a dish
    void UseIngredients (HashSet<string> recipe)
    {
        int num;
        foreach (string str in recipe)
        {
            collectedItems.TryGetValue(str, out num);
            if (num > 1)
            {
                // not sure if this works
                collectedItems.Remove(str);
                collectedItems.Add(str, num - 1);
            }
            else
            {
                collectedItems.Remove(str);
            }
        }
    }

    // making a dish and getting the points
    void MakeDish(HashSet<string> recipe)
    {
        UseIngredients(recipe);
        int earnedPoints;
        scoreSet.TryGetValue(recipe, out earnedPoints);

        scoreDisplay.GetComponent<ScoreScript>().points += earnedPoints;
    }
}

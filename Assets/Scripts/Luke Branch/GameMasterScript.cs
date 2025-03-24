using System;
using System.Collections.Generic;
using UnityEngine;

public class GameMasterScript : MonoBehaviour
{

    private Dictionary<FINISHED_RECIPES, Queue<float>> currentOrders = new Dictionary<FINISHED_RECIPES, Queue<float>>();


    private int lives;

    private int score;

    public int currentDayNumber;

    public int maxDayNumber;

    public OrderGenerator orderGenerator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentOrders[FINISHED_RECIPES.BURGER] = new Queue<float>();
        currentOrders[FINISHED_RECIPES.SALAD] = new Queue<float>();
        orderGenerator = FindAnyObjectByType<OrderGenerator>();

    }

    // Update is called once per frame
    void Update()
    {
        foreach (var key in currentOrders.Keys) {
            if(currentOrders[key].Count == 0){
                continue;
            }

            if(currentOrders[key].Peek() < Time.time){
                OrderExpired(key);
            }
            
        }
    }

    public void AddOrder(RecipeObject recipe){
        currentOrders[recipe.recipeType].Enqueue(Time.time + recipe.duration);
    }

    public void OrderTurnedIn(FinishedRecipe recipe){

        if(currentOrders[recipe.recipe].Count == 0){
            return;
        }

        currentOrders[recipe.recipe].Dequeue();

        orderGenerator.RemoveRecipe(recipe.recipe);

    }

    private void OrderExpired(FINISHED_RECIPES recipe){

        lives--;

        if(lives <= 0){
            EndGame();
            return;
        }

        currentOrders[recipe].Dequeue();

                orderGenerator.RemoveRecipe(recipe);
    }

    private void EndGame(){
        //make transition to game over screen
    }

    private void UpdateScore(int value){
        score += value;
        //update ui
    }
}

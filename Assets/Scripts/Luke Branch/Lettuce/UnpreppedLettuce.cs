using UnityEngine;

public class UnpreppedLettuce : UnpreppedIngredient, Choppable
{

    public int health;

    public bool isOnCuttingBoard;



    public void ChopIngredient()
    {
        print("Overlap");

        if (!isOnCuttingBoard)
        {
            return;
        }

        print("Overlap knife");
        health -= 1;

        if (health <= 0)
        {
            base.IngredientPrepped();
        }
    }
}
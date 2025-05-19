using System;

namespace Cookbook
{
    public class Recipe
    {
        private string name;
        private FoodCategory category;
        private string description;
        private string[] ingredients;
        private readonly int maxNumOfIngredients;

        public Recipe(int maxNumOfIngredients)
        {
            this.maxNumOfIngredients = maxNumOfIngredients;
            ingredients = new string[maxNumOfIngredients];
            name = string.Empty;
            description = string.Empty;
        }

        public string Name
        {
            get => name;
            set => name = value ?? string.Empty;
        }

        public FoodCategory Category
        {
            get => category;
            set => category = value;
        }

        public string Description
        {
            get => description;
            set => description = value ?? string.Empty;
        }

        public string[] Ingredients
        {
            get => ingredients;
            set => ingredients = value ?? new string[maxNumOfIngredients];
        }

        public int MaxNumOfIngredients
        {
            get => maxNumOfIngredients;
        }

        public bool AddIngredient(string ingredient)
        {
            if (string.IsNullOrWhiteSpace(ingredient)) return false;

            for (int i = 0; i < ingredients.Length; i++)
            {
                if (string.IsNullOrEmpty(ingredients[i]))
                {
                    ingredients[i] = ingredient;
                    return true;
                }
            }
            return false;
        }

        public void RemoveIngredient(int index)
        {
            if (index >= 0 && index < ingredients.Length)
            {
                for (int i = index; i < ingredients.Length - 1; i++)
                {
                    ingredients[i] = ingredients[i + 1];
                }
                ingredients[ingredients.Length - 1] = string.Empty;
            }
        }
    }
}
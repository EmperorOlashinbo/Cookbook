using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookbook
{
    public class Recipe
    {
        private string name;                    // Stores the name of the recipe
        private FoodCategory category;          // Represents the food category (e.g., dessert, main course)
        private string instructions;            // Holds the cooking instructions for the recipe
        private string description;             // Contains a brief description of the recipe
        private string[] ingredients;           // Array to store the list of ingredients
        private int maxNumOfIngredients;        // Defines the maximum number of ingredients allowed

        // Constructor that initializes a Recipe object with a specified maximum number of ingredients
        public Recipe(int maxNumOfIngredients)
        {
            this.maxNumOfIngredients = maxNumOfIngredients;   // Sets the maximum number of ingredients
            ingredients = new string[maxNumOfIngredients];    // Initializes the ingredients array with the specified size
            name = string.Empty; // Initialize name          // Sets the name to an empty string
            instructions = string.Empty; // Initialize instructions // Sets the instructions to an empty string
            description = string.Empty; // Initialize description   // Sets the description to an empty string
        }

        // Property to get or set the recipe's name
        public string Name
        {
            get { return name; }                // Returns the current name of the recipe
            set { name = value; }               // Assigns a new value to the recipe's name
        }

        // Property to get or set the recipe's category
        public FoodCategory Category
        {
            get { return category; }            // Returns the current category of the recipe
            set { category = value; }           // Assigns a new category to the recipe
        }

        // Property to get or set the recipe's instructions
        public string Instructions
        {
            get { return instructions; }        // Returns the current instructions for the recipe
            set { instructions = value; }       // Assigns new instructions to the recipe
        }

        // Property to get or set the recipe's description
        public string Description
        {
            get { return description; }         // Returns the current description of the recipe
            set { description = value; }        // Assigns a new description to the recipe
        }

        // Property to get or set the array of ingredients
        public string[] Ingredients
        {
            get { return ingredients; }         // Returns the current array of ingredients
            set { ingredients = value; }        // Assigns a new array of ingredients
        }

        // Read-only property to get the maximum number of ingredients allowed
        public int MaxNumOfIngredients
        {
            get { return maxNumOfIngredients; } // Returns the maximum number of ingredients
        }

        // Method to add an ingredient to the ingredients array
        public bool AddIngredient(string ingredient)
        {
            if (string.IsNullOrWhiteSpace(ingredient)) return false; // Returns false if the ingredient is null, empty, or whitespace

            for (int i = 0; i < Ingredients.Length; i++)         // Loops through the ingredients array
            {
                if (string.IsNullOrEmpty(Ingredients[i]))        // Checks for the first empty slot in the array
                {
                    Ingredients[i] = ingredient;                 // Adds the ingredient to the empty slot
                    return true;                                 // Returns true to indicate successful addition
                }
            }
            return false;                                        // Returns false if no empty slot is found
        }

        // Method to remove an ingredient from the ingredients array by index
        public void RemoveIngredient(int index)
        {
            if (index >= 0 && index < Ingredients.Length)        // Verifies that the index is within valid bounds
            {
                Ingredients[index] = string.Empty;               // Sets the ingredient at the specified index to an empty string
            }
            // Does nothing if the index is out of bounds
        }
    }
}
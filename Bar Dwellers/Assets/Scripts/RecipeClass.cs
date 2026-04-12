using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Recipe
{
    public string DrinkName;
    public List<DrinkType> ingredients;
    public Color drinkColor;
}

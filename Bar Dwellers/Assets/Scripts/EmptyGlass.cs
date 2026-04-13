using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Unity.VisualScripting.FullSerializer;
using System.Net.Security;

public class EmptyGlass : MonoBehaviour, IDropHandler
{
    public List<Recipe> recipeBook;
    public Image liquidImage;

    public void OnDrop(PointerEventData eventData)
    {
        Mixer mixer = eventData.pointerDrag.GetComponent<Mixer>();

        if(mixer != null && mixer.isMixed)
        {
            CreateDrink(mixer.contents);

            mixer.contents.Clear();
            mixer.isMixed = false;
        }
    }
    void CreateDrink(List<DrinkType> ingredients)
    {
        foreach (Recipe recipe in recipeBook)
        {
            if (ingredients.Count == recipe.ingredients.Count)
            {
                bool match = true;
                foreach (var item in recipe.ingredients)
                {
                    if (!ingredients.Contains(item)) match = false;
                }
                if (match)
                {
                    transform.GetChild(0).gameObject.SetActive(true);
                }
            }
        }
        Debug.Log("Did not create drink");
    }
    
    void Serve(Recipe recipe)
    {
        Debug.Log("Served: " + recipe.DrinkName);
        liquidImage.color = recipe.drinkColor;
        liquidImage.gameObject.SetActive(true);
    }
    
}

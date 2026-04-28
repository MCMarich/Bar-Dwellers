using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Unity.VisualScripting.FullSerializer;
using System.Net.Security;
using System.Collections;

public class PourGlass : MonoBehaviour, IDropHandler
{
    public AudioSource audioSource;
    public AudioClip pourSound;
    public List<Recipe> recipeBook;
    public Image liquidImage;
    public Sprite newSprite;
    public GameObject button;

    public void OnDrop(PointerEventData eventData)
    {
        MixingGlass mixingGlass = eventData.pointerDrag.GetComponent<MixingGlass>();

        if(mixingGlass != null)
        {
            if (audioSource != null && pourSound != null)
            {
                audioSource.PlayOneShot(pourSound);
            }
            CreateDrink(mixingGlass.contents);

            mixingGlass.contents.Clear();
        }
    }
    void CreateDrink(List<DrinkType> ingredients)
    {
        foreach (Recipe recipe in recipeBook)
        {
            if (ingredients.Count == recipe.ingredients.Count) // Checks if the ingredients match any recipe's ingredients
            {
                bool match = true;
                foreach (var item in recipe.ingredients)
                {
                    if (!ingredients.Contains(item)) match = false;
                }
                if (match)
                {
                    liquidImage.sprite = newSprite;
                    button.SetActive(true); //Sets a button to swtich screens active
                    string DrinkName = recipe.DrinkName;
                    Player.Instance._inventoryString.Add(DrinkName);
                    return;
                }
            }
        }
        Debug.Log("Did not create drink");
    }
}

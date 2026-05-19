using UnityEngine;
using TMPro;

public class StirringTutorial : MonoBehaviour
{
    [Header("References")]
    public SpoonTutorial spoon;
    public StirableGlass drink;
    public TextMeshProUGUI instructionText;
    public GameObject arrow1;
    public GameObject arrow2;

    [Header("Target Positions")]
    public Transform spoonStartPos;
    public Transform drinkPos;

    private int currentStep = 0;
    private bool hasPickedUpSpoon = false;

    void Start()
    {
        UpdateTutorial();
    }

void Update()
{
    if (spoon == null || drink == null) return;

    switch (currentStep)
    {
        case 0:
            if (hasPickedUpSpoon) 
            {
                Debug.Log("Step 0 Complete: Spoon Picked Up");
                AdvanceStep();
            }
            break;

        case 1:
            if (drink.currentStirProgress > 1f) 
            {
                Debug.Log("Step 1 Complete: Stirring Started. Progress: " + drink.currentStirProgress);
                AdvanceStep();
            }
            break;

        case 2:
            if (drink.isStirred)
            {
                Debug.Log("Step 2 Complete: Drink Finished");
                AdvanceStep();
            }
            break;
    }
}

// Add this function so the Spoon can tell the tutorial it's been grabbed
public void NotifySpoonGrabbed()
{
    hasPickedUpSpoon = true;
}
    void AdvanceStep()
    {
        currentStep++;
        UpdateTutorial();
    }

    void UpdateTutorial()
    {
        switch (currentStep)
        {
            case 0:
                instructionText.text = "Pick up the bar spoon.";
                break;

            case 1:
                instructionText.text = "Move the spoon in circles over the glass to stir.";
                arrow1.SetActive(false);
                arrow2.SetActive(true);
                break;
            case 2:
                instructionText.text = "Keep stirring!";
                arrow2.SetActive(false);
                break;

            case 3:
                instructionText.text = "Perfectly stirred! Return to the bar.";
                break;
        }
    }
}
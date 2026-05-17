using UnityEngine;
using TMPro; // If using TextMeshPro
using UnityEngine.UI;

public class MixingTutorial : MonoBehaviour
{
    [Header("References")]
    public Mixer mixer;
    public EmptyGlass glass;
    public TextMeshProUGUI instructionText;
    public GameObject highlightArrow1;
    public GameObject highlightArrow2;
    public GameObject highlightArrow3;

    private int currentStep = 0;

    void Start()
    {
        UpdateTutorial();
    }

    void Update()
    {
        switch (currentStep)
        {
            case 0: // Step 0: Add first ingredient
                if (mixer.contents.Count == 1) AdvanceStep();
                break;

            case 1: // Step 2: Shake the mixer
                if (mixer.isMixed) AdvanceStep();
                break;

            case 2: // Step 3: Pour into glass
                // We check if the glass is no longer empty
                if (mixer.contents.Count == 0) AdvanceStep();
                break;
        }
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
                instructionText.text = "Drag the ingredients into the Shaker.";
                // Point arrow at the bottle
                break;
            case 1:
                instructionText.text = "Now CLICK and SHAKE the mixer until the bar is full!";
                highlightArrow1.SetActive(false);
                break;
            case 2:
                instructionText.text = "It's ready! Drag the Shaker onto the Glass to pour.";
                highlightArrow2.SetActive(false);
                highlightArrow3.SetActive(true);
                break;
            case 3:
                instructionText.text = "Perfect! You've made your first drink.";
                break;
        }
    }
}
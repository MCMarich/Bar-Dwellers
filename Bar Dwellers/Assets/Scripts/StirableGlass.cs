using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class StirableGlass : MonoBehaviour
{
    [Header("Stir Settings")]
    public float StirRequired = 1000f;
    private float currentStirProgress = 0f;
    public bool isStirred = false;
    public GameObject button;

    private RectTransform rectTransform;
    private Vector2 originalPos;
    private Vector3 originalScale;
    private float currentMovement = 0f;

    [Header("UI")]
    public Slider stirBar;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        originalPos = rectTransform.anchoredPosition;
        originalScale = rectTransform.localScale;
    }
    public void Stir(float amount)
    {
        if (isStirred) return;

        currentStirProgress += amount;

        currentMovement = Mathf.Clamp(currentMovement + (amount * 0.1f), 0, 1f);

        if (stirBar != null)
        {
            stirBar.gameObject.SetActive(true);
            stirBar.value = currentStirProgress / StirRequired;
        }

        if (currentStirProgress >= StirRequired)
        {
            FinishDrink();
        }
    }
    void FinishDrink()
    {
        isStirred = true;
        if(stirBar != null) stirBar.gameObject.SetActive(false);

        transform.rotation = quaternion.identity;

        button.SetActive(true);

        Debug.Log("The drink is perfectly stirred!");

    }
}
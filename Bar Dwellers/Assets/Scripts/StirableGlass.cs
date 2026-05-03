using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class StirableGlass : MonoBehaviour
{
    [Header("Images")]
    public Image liquidImage;
    public Sprite Mojito;
    public Sprite Scarlet;

    [Header("Stir Settings")]
    public float StirRequired = 1000f;
    private float currentStirProgress = 0f;
    public bool isStirred = false;
    public GameObject button;

    public AudioSource audioSource;
    public AudioClip stirSound;

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
        if (Player.Instance._inventoryString.Contains("Scarlet_O_Hera"))
        {
            liquidImage.sprite = Scarlet;
        }
        else if (Player.Instance._inventoryString.Contains("Bluberry Mojito"))
        {
            liquidImage.sprite = Mojito;
        }
        else if (Player.Instance._inventoryString.Contains("Moscow Mule"))

        if (audioSource != null && stirSound != null)
        {
            audioSource.clip = stirSound;
            audioSource.loop = true;
            audioSource.playOnAwake = false;
            audioSource.volume = 0;
        }
    }
    public void Stir(float amount)
    {
        if (isStirred) return;

        currentStirProgress += amount;

        currentMovement = Mathf.Clamp(currentMovement + (amount * 0.1f), 0, 1f);

        if (!audioSource.isPlaying && currentMovement > 0.1f)
        {
            audioSource.Play();
            audioSource.volume = 0.5f;
        }


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
        audioSource.Stop();
        if(stirBar != null) stirBar.gameObject.SetActive(false);

        transform.rotation = quaternion.identity;
        button.SetActive(true);

        Debug.Log("The drink is perfectly stirred!");

    }
}
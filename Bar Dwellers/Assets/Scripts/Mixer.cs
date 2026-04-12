using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class Mixer : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IDropHandler
{
    [Header("Ingredients")]
    public List<DrinkType> contents = new List<DrinkType>();
    public int maxCapacity = 2;
    public bool isMixed = false;

    [Header("Shaking Settings")]
    public float shakeRequired = 1000f; 
    private float currentShakeProgress = 0f;
    public Slider shakeProgressBar;
    private Vector2 lastMousePos;

    [Header("Movement")]
    [SerializeField] private Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Vector2 originalPosition;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        originalPosition = rectTransform.anchoredPosition;
    }

    // This happens the moment you click to drag
    public void OnBeginDrag(PointerEventData eventData)
    {
        lastMousePos = Mouse.current.position.ReadValue();
        canvasGroup.alpha = .7f;
        canvasGroup.blocksRaycasts = false;
    }

    // This runs every frame you move the mouse while clicking
    public void OnDrag(PointerEventData eventData)
    {
        // LOGIC 1: If it's full but NOT mixed, we SHAKE
        if (contents.Count >= maxCapacity && !isMixed)
        {
            HandleShakeLogic();
        }
        // LOGIC 2: If it IS mixed, we MOVE it to the glass
        else if (isMixed)
        {
            rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        }
    }

    private void HandleShakeLogic()
    {
        Vector2 currentMousePos = Mouse.current.position.ReadValue();
        float mouseDelta = Vector2.Distance(currentMousePos, lastMousePos);

        if (mouseDelta > 0)
        {
            currentShakeProgress += mouseDelta;
            if (shakeProgressBar != null)
            {
                shakeProgressBar.gameObject.SetActive(true);
                shakeProgressBar.value = currentShakeProgress / shakeRequired;
            }

            // Visual wiggle: move slightly away from original position and back
            rectTransform.anchoredPosition = originalPosition + new Vector2(Random.Range(-5f, 5f), Random.Range(-5f, 5f));
        }

        lastMousePos = currentMousePos;

        if (currentShakeProgress >= shakeRequired)
        {
            FinishMixing();
        }
    }

    private void FinishMixing()
    {
        isMixed = true;
        rectTransform.anchoredPosition = originalPosition; // Snap back to center
        if (shakeProgressBar != null) shakeProgressBar.gameObject.SetActive(false);
        Debug.Log("Mixing Complete! Now drag to the glass.");
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;

        // If it's not dropped on a glass, return to its slot
        if (!isMixed || transform.parent == canvas.transform)
        {
            rectTransform.anchoredPosition = originalPosition;
        }
    }

    // This handles the bottles being dropped INTO the mixer
    public void OnDrop(PointerEventData eventData)
    {
        if (contents.Count < maxCapacity && !isMixed)
        {
            DragNDrop bottle = eventData.pointerDrag.GetComponent<DragNDrop>();
            if (bottle != null)
            {
                contents.Add(bottle.bottleType);
                Destroy(eventData.pointerDrag);
                Debug.Log("Added: " + bottle.bottleType);
            }
        }
    }
}
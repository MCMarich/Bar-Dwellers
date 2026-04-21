using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class MixingGlass : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IDropHandler
{
    [Header("Ingredients")]
    public List<DrinkType> contents = new List<DrinkType>();
    public int maxCapacity = 2;

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
    if (contents.Count >= maxCapacity)
        {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;

        // If it's not dropped on a glass, return to its slot
        if (transform.parent == canvas.transform)
        {
            rectTransform.anchoredPosition = originalPosition;
        }
    }

    // This handles the bottles being dropped INTO the mixer
    public void OnDrop(PointerEventData eventData)
    {
        if (contents.Count < maxCapacity)
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
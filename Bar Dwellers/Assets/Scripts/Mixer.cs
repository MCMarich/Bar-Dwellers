using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using Unity.VisualScripting;

public class Mixer : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public List<DrinkType> contents = new List<DrinkType>();
    public int MaxDrinks = 2;

    [Header("Shaking Settings")]
    public float shakeRequired = 500f;

    private float currentShakeProgress = 0f;
    private bool isMouseOver = false;
    private Vector3 lastMousePos;

    [Header("States")]
    public bool isMixed = false;
    public void OnDrop(PointerEventData eventData)
    {
        if (contents.Count <MaxDrinks && !isMixed)
        {
            DragNDrop bottle = eventData.pointerDrag.GetComponent<DragNDrop>();
            if (bottle != null)
            {
                contents.Add(bottle.bottleType);
                Debug.Log($"Added {bottle.bottleType}. Total: {contents.Count}");
                Destroy(eventData.pointerDrag);
                if (contents.Count == MaxDrinks)
                {
                    Debug.Log("Mixer Full");
                }
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

}
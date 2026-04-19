using NUnit.Framework;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropSlot : MonoBehaviour, IDropHandler
{
    public DrinkType acceptedType;
    public bool isOccupied = false;
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
        if( eventData.pointerDrag != null)
        {
            DragNDrop bottle = eventData.pointerDrag.GetComponent<DragNDrop>();

            bool isCorrectType = (acceptedType == DrinkType.Anything) || (bottle.bottleType == acceptedType); // Checks if correct drink type

            if (bottle != null && isCorrectType && !isOccupied) // Chekcs if bottle is correct object type and the slot is not occupied
            {
                RectTransform bottleRect = eventData.pointerDrag.GetComponent<RectTransform>();

                bottleRect.SetParent(transform); //Sets itself as parent for the bottle
                bottleRect.anchoredPosition = Vector2.zero;

                isOccupied = true;
                Debug.Log($"{bottle.bottleType} is in {acceptedType} slot");
            }
            else
            {
                Debug.Log("Rejected bottle");
                bottle.ReturnToStart();
            }
        }
    }
    public void ResetSlot()
    {
        isOccupied = false;
    }
}

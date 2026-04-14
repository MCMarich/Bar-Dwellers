using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class SimpleSpoon : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] private Canvas canvas;
    public StirableGlass targetDrink;
    public float stirRadius = 150f;

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Vector2 lastMousePos;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false;
        lastMousePos = Mouse.current.position.ReadValue();
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;

        float distance = Vector2.Distance(rectTransform.position, targetDrink.transform.position);

        if (distance < stirRadius)
        {
            Vector2 currentMousePos = Mouse.current.position.ReadValue();
            float moveAmount = Vector2.Distance(currentMousePos, lastMousePos);

            targetDrink.Stir(moveAmount);

            float tilt = -eventData.delta.x * 0.8f;
            rectTransform.rotation = Quaternion.Euler(0, 0, Mathf.Clamp(tilt, -25f, 25f));
        }
        else
        {
            rectTransform.rotation = Quaternion.Lerp(rectTransform.rotation, Quaternion.identity, Time.deltaTime * 5f);
        }

        lastMousePos = Mouse.current.position.ReadValue();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        rectTransform.rotation = Quaternion.identity;
    }
}
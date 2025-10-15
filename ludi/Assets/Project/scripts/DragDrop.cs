using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{
    [SerializeField] private Canvas canvas;
    private RectTransform rectTransform;
    private Button button;
    private Color newColor;

    private void Start()
    {
        newColor = Color.green;
    }

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        button = GetComponent<Button>();
    }

    public void OnPointerDown(PointerEventData eventData) {
        Debug.Log("Pointer Down");
    }

    public void OnBeginDrag(PointerEventData eventData) {
        Debug.Log("Begin Drag");
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData) {
        Debug.Log("End Drag");
    }

    public void OnDrop(PointerEventData eventData) {
        ColorBlock cb = new ColorBlock();
        cb.disabledColor = newColor;
        button.colors = cb;
    }
}

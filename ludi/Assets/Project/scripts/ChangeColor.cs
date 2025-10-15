using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChangeColor : MonoBehaviour, IDropHandler
{
    //[SerializeField] private Button button;
    [SerializeField] private string targetTag;

    private Color newColor;
    private Image buttonImage;

    private void Awake()
    {
        buttonImage = GetComponent<Image>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Dropped");

        GameObject dropped = eventData.pointerDrag;

        if (dropped != null)
        {
            if (dropped.CompareTag(targetTag))
            {
                newColor = Color.green;


                dropped.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            }
            else {
                newColor = Color.red;
            }


            Color c = newColor;
            c.a = 1f; // equivalente a alfa 255
            buttonImage.color = c;
            buttonImage.enabled = true;

            Debug.Log("Color cambiado al arrastrar el objeto: " + dropped.name);
        }
    }
}

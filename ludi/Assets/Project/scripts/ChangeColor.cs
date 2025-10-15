using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChangeColor : MonoBehaviour, IDropHandler
{
    [SerializeField] private Button button;
    private Color newColor;
    private Image buttonImage;

    private void Start()
    {
        newColor = Color.green;
    }
    private void Awake()
    {
        buttonImage = button.GetComponent<Image>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Dropped");

        GameObject dropped = eventData.pointerDrag;

        if (dropped != null)
        {
            if (dropped.tag == "Respawn")
            {
                // Asegurar color visible (alfa completo)
                Color c = newColor;
                c.a = 1f; // equivalente a alfa 255
                buttonImage.color = c;
                buttonImage.enabled = true;
            }
            else {
                newColor = Color.red;
                // Asegurar color visible (alfa completo)
                Color c = newColor;
                c.a = 1f; // equivalente a alfa 255
                buttonImage.color = c;
                buttonImage.enabled = true;
            }




                Debug.Log("Color cambiado al arrastrar el objeto: " + dropped.name);
        }
    }
}

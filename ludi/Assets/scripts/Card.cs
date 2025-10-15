using UnityEngine;
using UnityEngine.UI;
using PrimeTween;

public class Card : MonoBehaviour
{
    [SerializeField] private Image iconImage;

    public Sprite hiddenIconSprite;
    public Sprite IconSprite;

    public bool isSeleceted;

    public CardsController controller;

    public void OnCardClick()
    {
       // controller.SetSelected(this);
    }

    public void SetIconSprite(Sprite sp)
    {
        IconSprite = sp;
    }

    public void Show()
    {
        Tween.Rotation(transform, new Vector3(0f, 180f, 0f), 0.2f);
        Tween.Delay(0.1f, () => iconImage.sprite = IconSprite); // corregido
        isSeleceted = true;
    }

    public void Hide()
    {
        Tween.Rotation(transform, new Vector3(0f, 0f, 0f), 0.2f);
        Tween.Delay(0.1f, () =>
        {
            iconImage.sprite = hiddenIconSprite;
            isSeleceted = false;
        });
    }
}

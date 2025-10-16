using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Card : MonoBehaviour
{
    [SerializeField] private Image iconImage;

    public Sprite hiddenIconSprite;
    public Sprite IconSprite;

    public bool isSeleceted;

    public CardsController controller;

    private void Start()
    {
        if (hiddenIconSprite != null)
        {
            iconImage.sprite = hiddenIconSprite;
        }
    }

    public void OnCardClick()
    {
        controller.SetSelected(this);
    }

    public void SetIconSprite(Sprite sp)
    {
        IconSprite = sp;
    }

    public void Show()
    {
        StartCoroutine(ShowCard());
    }

    public void Hide()
    {
        StartCoroutine(HideCard());
    }

    private IEnumerator ShowCard()
    {
        float duration = 0.2f;
        float elapsed = 0f;
        Quaternion startRot = transform.rotation;
        Quaternion endRot = Quaternion.Euler(0f, 180f, 0f);

        while (elapsed < duration)
        {
            transform.rotation = Quaternion.Lerp(startRot, endRot, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.rotation = endRot;

        iconImage.sprite = IconSprite;
        isSeleceted = true;
    }

    private IEnumerator HideCard()
    {
        float duration = 0.2f;
        float elapsed = 0f;
        Quaternion startRot = transform.rotation;
        Quaternion endRot = Quaternion.Euler(0f, 0f, 0f);

        while (elapsed < duration)
        {
            transform.rotation = Quaternion.Lerp(startRot, endRot, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.rotation = endRot;

        iconImage.sprite = hiddenIconSprite;
        isSeleceted = false;
    }
}
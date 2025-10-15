using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CardsController : MonoBehaviour
{
    [SerializeField] Sprite[] sprites;
    [SerializeField] Card cardsPrefab;
    [SerializeField] Transform gridTransform;

    private List<Sprite> spritePairs;
    Card firstSelected;
    Card secondSelected;
    int matchCounts;

    private void Start()
    {
        PrepareSprites();
        CreateCards();
    }

    private void PrepareSprites()
    {
        spritePairs = new List<Sprite>();
        for (int i = 0; i < sprites.Length; i++)
        {
            spritePairs.Add(sprites[i]);
            spritePairs.Add(sprites[i]);
        }
        ShuffleSprites(spritePairs);
    }

    public void SetSelected(Card card)
    {
        if (card.isSeleceted == false)
        {
            card.Show();
            if (firstSelected == null)
            {
                firstSelected = card;
                return;
            }

            if (secondSelected == null)
            {
                secondSelected = card;
                StartCoroutine(CheckMatching(firstSelected, secondSelected));
            }
        }
    }

    IEnumerator CheckMatching(Card a, Card b)
    {
        yield return new WaitForSeconds(0.8f); // Increased wait time for better UX

        if (a.IconSprite == b.IconSprite)
        {
            matchCounts++;
            if (matchCounts >= spritePairs.Count / 2)
            {
                StartCoroutine(WinAnimation());
            }
        }
        else
        {
            a.Hide();
            b.Hide();
        }

        firstSelected = null;
        secondSelected = null;
    }

    IEnumerator WinAnimation()
    {
        Vector3 originalScale = gridTransform.localScale;
        Vector3 targetScale = originalScale * 1.2f;

        // Scale up
        float duration = 0.2f;
        float elapsed = 0f;
        while (elapsed < duration)
        {
            gridTransform.localScale = Vector3.Lerp(originalScale, targetScale, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        // Scale down
        elapsed = 0f;
        while (elapsed < duration)
        {
            gridTransform.localScale = Vector3.Lerp(targetScale, originalScale, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        gridTransform.localScale = originalScale;
    }

    void CreateCards()
    {
        for (int i = 0; i < spritePairs.Count; i++)
        {
            Card card = Instantiate(cardsPrefab, gridTransform);
            card.SetIconSprite(spritePairs[i]);
            card.controller = this;
        }
    }

    void ShuffleSprites(List<Sprite> spriteList)
    {
        for (int i = spriteList.Count - 1; i > 0; i--)
        {
            int randomIndex = Random.Range(0, i );
            Sprite temp = spriteList[i];
            spriteList[i] = spriteList[randomIndex];
            spriteList[randomIndex] = temp;
        }
    }
}
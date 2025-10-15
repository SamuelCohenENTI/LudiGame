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
            //adding sprites 2 times to make it pair

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
                firstSelected = null;
                secondSelected = null;
            }
        }
    }

    IEnumerator CheckMatching(Card a, Card b)
    {
        yield return new WaitForSeconds(0.3f);

        if (a.IconSprite == b.IconSprite)
        {
            matchCounts++;
            if (matchCounts > spritePairs.Count / 2)
            {
                PrimeTween.Sequence.Create()
                    .Chain(PrimeTween.Tween.Scale(gridTransform, Vector3.one * 1.2f, 0.2f, ease: PrimeTween.Ease.Outback))
                    .Chain(PrimeTween.Tween.Scale(gridTransform, Vector3.one, 0.1f));
            }
        }

        else
        {
            a.Hide();
            b.Hide();
        }
    }

    void CreateCards()
    {
        for (int i = 0; i < spritePairs.Count; i++)
        { 
            Card card=  Instantiate(cardsPrefab, gridTransform);
            card.SetIconSprite(spritePairs[i]);
            card.controller = this;
        }

    }

    //Method to shuffle a list of sprites

    void ShuffleSprites(List<Sprite> spriteList)
    {
        for (int i = spriteList.Count - 1; i > 0; i--) // Changed i++ to i--
        {
            int randomIndex = Random.Range(0, i + 1);

            // Swap the elements at i and randomIndex
            Sprite temp = spriteList[i];
            spriteList[i] = spriteList[randomIndex]; // Use spriteList, not sprites
            spriteList[randomIndex] = temp; // Fixed index - removed +1
        }
    }
}

using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.Events;

[RequireComponent(typeof(GridLayoutGroup))]
public class CardPlacer : MonoBehaviour
{
    [SerializeField] private GameObject _cardPrefab;

    private readonly List<GameObject> _previousLevelCards = new List<GameObject>();

    public void SetGridParameters(int numberOfColumns)
    {
        GetComponent<GridLayoutGroup>().constraintCount = numberOfColumns;
    }

    public void PlaceCards(CardData[] cardsData, UnityAction<Card> clickedCardHandler)
    {
        foreach (var card in _previousLevelCards)
        {
            Destroy(card);
        }

        for (int i = 0; i < cardsData.Length; i++)
        {
            var cardData = cardsData[i];

            var cardInstance = Instantiate(_cardPrefab, transform);

            var cardComponent = cardInstance.GetComponent<Card>();

            cardComponent.Initialize(cardData.Identifier, cardData.Sprite, clickedCardHandler);

            _previousLevelCards.Add(cardInstance);
        }
    }
}
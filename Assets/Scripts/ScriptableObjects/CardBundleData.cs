using UnityEngine;

[CreateAssetMenu(fileName = "CardBundleData_1", menuName = "CardBundleData")]
public class CardBundleData : ScriptableObject
{
    [SerializeField] private CardData[] _cardData;

    public CardData[] CardData => _cardData;
}
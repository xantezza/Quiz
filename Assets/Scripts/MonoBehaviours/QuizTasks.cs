using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using System.Collections;

[RequireComponent(typeof(TextMeshPro))]
public class QuizTasks : MonoBehaviour
{
    private string _currentTaskIdentifier;
    private List<string> _previousTaskIdentifiers = new List<string>();

    private UnityAction _correctResultHandler;

    public void WipePreviousTasks()
    {
        _previousTaskIdentifiers = new List<string>();
    }

    public void CreateRandomTaskFromArray(CardData[] cardsData, UnityAction CorrectResultHandler)
    {
        _correctResultHandler = CorrectResultHandler;
        for (int i = 0; i < cardsData.Length; i++)
        {
            var cardData = cardsData[Random.Range(0, cardsData.Length)];
            if (!_previousTaskIdentifiers.Contains(cardData.Identifier))
            {
                _previousTaskIdentifiers.Add(cardData.Identifier);
                _currentTaskIdentifier = cardData.Identifier;
                GetComponent<TextMeshPro>().text = "Find " + cardData.Identifier;
                return;
            }
        }
    }

    public void CheckResultAndAnimateCard(Card card)
    {
        if (_currentTaskIdentifier.Equals(card.Identifier))
        {
            StartCoroutine(CorrectAnswerAnimations(card));
        }
        else
        {
            card.PlayWrongAnswerAnimation();
        }
    }

    private IEnumerator CorrectAnswerAnimations(Card card)
    {
        card.PlayCorrectAnswerAnimation();
        yield return new WaitForSeconds(1f);
        _correctResultHandler?.Invoke();
    }
}
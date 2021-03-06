using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using DG.Tweening;

public class Card : MonoBehaviour
{
    private readonly UnityEvent<Card> OnCardClicked = new UnityEvent<Card>();

    [SerializeField] private Image _icon;

    private string _identifier;
    public string Identifier => _identifier;

    private float _animationTime = 0.1f;

    public void Initialize(string identifier, Sprite sprite, UnityAction<Card> clickedCardHandler)
    {
        _identifier = identifier;
        _icon.sprite = sprite;
        OnCardClicked.AddListener(clickedCardHandler);
    }

    public void PlayCorrectAnswerAnimation()
    {
        _icon.rectTransform.DOAnchorPosY(25, _animationTime * 4)
            .SetEase(Ease.InBounce);
        _icon.rectTransform.DOAnchorPos(Vector2.zero, _animationTime)
            .SetDelay(_animationTime * 4);
    }

    public void PlayWrongAnswerAnimation()
    {
        _icon.rectTransform.DOAnchorPosX(-10, _animationTime);
        _icon.rectTransform.DOAnchorPosX(10, _animationTime)
            .SetDelay(_animationTime);
        _icon.rectTransform.DOAnchorPos(Vector2.zero, _animationTime)
            .SetDelay(_animationTime);
    }

    public void OnButtonPressed() => OnCardClicked?.Invoke(this);
}
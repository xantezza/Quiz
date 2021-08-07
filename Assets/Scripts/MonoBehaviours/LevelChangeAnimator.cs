using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using DG.Tweening;

public class LevelChangeAnimator : MonoBehaviour
{
    [SerializeField] private GameObject _blackPanel;
    [SerializeField] private GameObject _restartButton;

    [SerializeField] private float _animationTime;
    private Image _image;

    private void Start()
    {
        _image = _blackPanel.GetComponent<Image>();
    }

    public void PlayRestartAnimatonBeforeButtonClick()
    {
        _blackPanel.SetActive(true);
        _image.DOFade(1f, _animationTime).OnComplete(() => _restartButton.SetActive(true));
    }

    public void PlayRestartAnimatonAfterButtonClick()
    {
        _image.DOFade(0f, _animationTime).OnComplete(() =>
        {
            _restartButton.SetActive(false);
            _blackPanel.SetActive(false);
        });
    }

    public void PlayChangeLevelAnimation()
    {
        _blackPanel.SetActive(true);
        _image.DOFade(1f, _animationTime);
        _image.DOFade(0f, _animationTime).SetDelay(_animationTime).OnComplete(() => _blackPanel.SetActive(false));
    }
}
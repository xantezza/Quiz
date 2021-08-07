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

    public IEnumerator PlayRestartAnimatonBeforeButtonClick()
    {
        _blackPanel.SetActive(true);
        _image.DOFade(1f, _animationTime);
        yield return new WaitForSeconds(_animationTime);
        _restartButton.SetActive(true);
    }

    public IEnumerator PlayRestartAnimatonAfterButtonClick()
    {
        _image.DOFade(0f, _animationTime);
        _restartButton.SetActive(false);
        yield return new WaitForSeconds(_animationTime);
        _blackPanel.SetActive(false);
    }

    public IEnumerator PlayChangeLevelAnimation()
    {
        _blackPanel.SetActive(true);
        _image.DOFade(1f, _animationTime);
        _image.DOFade(0f, _animationTime).SetDelay(_animationTime);
        yield return new WaitForSeconds(_animationTime);
        _blackPanel.SetActive(false);
    }
}
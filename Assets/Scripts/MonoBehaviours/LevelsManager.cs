using UnityEngine;
using System.Linq;

public class LevelsManager : MonoBehaviour
{
    [SerializeField] private int _startingLevelIndex;

    [SerializeField] private LevelBundleData _currentLevelBundle;

    [SerializeField] private QuizTasks _quizTasks;

    [SerializeField] private CardPlacer _cardPlacer;

    [SerializeField] private CardBundleData[] _cardBundles;

    [SerializeField] private LevelChangeAnimator _animator;

    private void Start() => StartLevel(_startingLevelIndex);

    private void StartLevel(int level)
    {
        var randomBundleIndex = Random.Range(0, _cardBundles.Length);
        var currentBundle = _cardBundles[randomBundleIndex];

        var shuffledCardsData = currentBundle.CardData.OrderBy(x => Random.value).ToArray();

        var levelData = _currentLevelBundle.LoadLevel(level);

        if (shuffledCardsData.Length < levelData.TotalCardsOnLevel)
        {
            Debug.LogError($"Not enough cards in {currentBundle} to create a level requiring {levelData.TotalCardsOnLevel} cards");
            return;
        }
        System.Array.Resize(ref shuffledCardsData, levelData.TotalCardsOnLevel);

        _quizTasks.CreateRandomTaskFromArray(shuffledCardsData, NextLevel);

        _cardPlacer.SetGridParameters(levelData.Columns);
        _cardPlacer.PlaceCards(shuffledCardsData, _quizTasks.CheckResultAndAnimateCard);
    }

    public void NextLevel()
    {
        _startingLevelIndex++;
        if (_startingLevelIndex == _currentLevelBundle.GetTotalLevels())
        {
            _animator.PlayRestartAnimatonBeforeButtonClick();
        }
        else
        {
            _animator.PlayChangeLevelAnimation();
            StartLevel(_startingLevelIndex);
        }
    }

    public void OnRestartButton()
    {
        _startingLevelIndex = 0;
        _quizTasks.WipePreviousTasks();

        _animator.PlayRestartAnimatonAfterButtonClick();

        StartLevel(_startingLevelIndex);
    }
}
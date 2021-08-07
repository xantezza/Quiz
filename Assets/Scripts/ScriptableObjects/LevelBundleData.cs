using UnityEngine;

[CreateAssetMenu(fileName = "LevelBundle_1", menuName = "LevelBundle")]
public class LevelBundleData : ScriptableObject
{
    [SerializeField] private LevelData[] _levelsData;

    public LevelData LoadLevel(int indexOfLevel)
    {
        return _levelsData[indexOfLevel];
    }

    public int GetTotalLevels()
    {
        return _levelsData.Length;
    }
}
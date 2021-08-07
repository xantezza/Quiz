using UnityEngine;
using System;

[Serializable]
public class LevelData
{
    [SerializeField] private int _columns;
    [SerializeField] private int _totalCardsOnLevel;

    public int Columns => _columns;
    public int TotalCardsOnLevel => _totalCardsOnLevel;
}
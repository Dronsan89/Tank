using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] private Text _healthPlayerText;
    [SerializeField] private Text _levelText;
    [SerializeField] private Text _scoreText;

    public void UpdateScoreAndLevel()
    {
        _levelText.text = $"Level {DataLevel.Level}";
        _scoreText.text = "Score" + DataLevel.Score.ToString("D5");
    }

    public void UpdateHealth(int health)
    {
        _healthPlayerText.text = $"Health: {health}";
    }
}

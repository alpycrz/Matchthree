using TMPro;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _highScoreText;
    private int _highScore;

    private void Start()
    {
        _highScore = PlayerPrefs.GetInt("HighScore", 0);
        _highScoreText.text = $" {_highScore}"; 
    }
}

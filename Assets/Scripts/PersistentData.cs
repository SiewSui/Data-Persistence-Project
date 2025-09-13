using UnityEngine;

public class PersistentData : MonoBehaviour
{
    public static PersistentData Instance { get; private set; }

    public string PlayerName { get; set; } = "Player";
    public int HighScore { get; private set; } = 0;
    public string HighScorePlayer { get; private set; } = "None";

    private const string Key_HighScore = "HighScore";
    private const string Key_HighScorePlayer = "HighScorePlayer";

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadHighScore();
    }

    public void TrySetHighScore(int score, string playerName)
    {
        if (score > HighScore)
        {
            HighScore = score;
            HighScorePlayer = playerName;
            SaveHighScore();
        }
    }

    private void SaveHighScore()
    {
        PlayerPrefs.SetInt(Key_HighScore, HighScore);
        PlayerPrefs.SetString(Key_HighScorePlayer, HighScorePlayer);
        PlayerPrefs.Save();
    }

    private void LoadHighScore()
    {
        HighScore = PlayerPrefs.GetInt(Key_HighScore, 0);
        HighScorePlayer = PlayerPrefs.GetString(Key_HighScorePlayer, "None");
    }
}

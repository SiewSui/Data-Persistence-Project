using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class StartMenu : MonoBehaviour
{
    public TMP_InputField nameInput;
    public TextMeshProUGUI bestScoreText;

    private void Start()
    {
        if (PersistentData.Instance != null)
        {
            bestScoreText.text = $"Best Score: {PersistentData.Instance.HighScore} : {PersistentData.Instance.HighScorePlayer}";
        }
    }

    public void StartGame()
    {
        string playerName = "Player";
        if (nameInput != null && !string.IsNullOrEmpty(nameInput.text))
            playerName = nameInput.text;

        PersistentData.Instance.PlayerName = playerName;
        SceneManager.LoadScene("Main");  // Use your main scene name
    }

    public void QuitGame()
    {
        Application.Quit();
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}

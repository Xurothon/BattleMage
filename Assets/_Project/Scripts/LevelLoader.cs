using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _menuButton;
    [SerializeField] private Button[] _nextLevelButtons;
    [SerializeField] private AdHelper _adHelper;

    public void RestartLevel()
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(index);
    }

    public void OpenStaffShop()
    {
        SceneManager.LoadScene(SceneManager.sceneCountInBuildSettings - 1);
    }

    public void LoadNextLevel()
    {
        DataWorker.Instance.IncrementCurrentLevel();
        int index = SceneManager.GetActiveScene().buildIndex + 1;
        if (index == SceneManager.sceneCountInBuildSettings)
        {
            index = 0;
        }
        SceneManager.LoadScene(index);
        if (index % 2 == 0)
        {
            _adHelper.ShowLevelCompleteAd();
        }
    }

    private void Awake()
    {
        _restartButton.onClick.AddListener(RestartLevel);
        _menuButton.onClick.AddListener(RestartLevel);
        for (int i = 0; i < _nextLevelButtons.Length; i++)
        {
            _nextLevelButtons[i].onClick.AddListener(LoadNextLevel);
        }
    }
}

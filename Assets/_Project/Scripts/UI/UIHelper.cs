using UnityEngine;
using UnityEngine.UI;

public class UIHelper : MonoBehaviour
{
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _shopButton;
    [SerializeField] private Button _homeFromShopButton;
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private GameObject _levelCompletePanel;
    [SerializeField] private GameObject _mainPanel;
    [SerializeField] private GameObject _shopPanel;
    [SerializeField] private TimeScaler _timeScaler;
    [SerializeField] private Text _levelNumberText;


    public void ActiveGameOverPanel()
    {
        this.Wait(0.5f, () => _gameOverPanel.SetActive(true));
    }

    public void ActiveLevelCompletPanel()
    {
        _levelCompletePanel.SetActive(true);
    }

    public void DisableShopPanel()
    {
        _shopPanel.SetActive(false);
        _mainPanel.SetActive(true);
    }

    public void DisableGameOverPanel()
    {
        _gameOverPanel.SetActive(false);
    }

    private void AddButtonListener()
    {
        _playButton.onClick.AddListener(ActiveGame);
        _shopButton.onClick.AddListener(ActiveShopPanel);
        _homeFromShopButton.onClick.AddListener(DisableShopPanel);
    }

    private void ActiveShopPanel()
    {
        _shopPanel.SetActive(true);
        _mainPanel.SetActive(false);
    }

    private void ActiveButton(Button button)
    {
        Image buttonImage = button.GetComponent<Image>();
        Color newColor = buttonImage.color;
        newColor.a = 0.8f;
        buttonImage.color = newColor;
    }

    private void ActiveGame()
    {
        _mainPanel.SetActive(false);
        Helpers.Instance.PositionChanger.ActiveEnemyMove();
    }

    private void RestartInPausePanel()
    {
        _timeScaler.TimeScalerUp();
        Helpers.Instance.LevelLoader.RestartLevel();
    }

    private void Start()
    {
        _shopPanel.SetActive(false);
        _levelNumberText.text = "Level " + (DataWorker.Instance.CurrentLevel + 1);
    }

    private void Awake()
    {
        AddButtonListener();
    }
}

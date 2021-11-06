using UnityEngine;
using UnityEngine.UI;

public class CoinsCounter : MonoBehaviour
{
    public int StepCoinsCount { get; private set; }
    [SerializeField] private Text _coinsText;
    private int _currentCoinsCount;

    public void AddCoin()
    {
        _currentCoinsCount++;
        StepCoinsCount++;
        UpdtateCoinsText();
    }

    public void SaveCoinsCount()
    {
        DataWorker.Instance.UpdateCountCoins(_currentCoinsCount);
    }

    public void UpdateCoinsCount(int count)
    {
        _currentCoinsCount = count;
        UpdtateCoinsText();
    }

    public void SetX2Coins()
    {

    }
    private void UpdtateCoinsText()
    {
        _coinsText.text = _currentCoinsCount.ToString();
    }

    private void Start()
    {
        _currentCoinsCount = DataWorker.Instance.Coins;
        UpdtateCoinsText();
    }
}

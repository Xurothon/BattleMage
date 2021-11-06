using UnityEngine;

public class DataWorker : MonoBehaviour
{
    public static DataWorker Instance { get; private set; }
    public int Coins { get; private set; }
    public int ChooseBat { get; private set; }
    public int ChoosePower { get; private set; }
    public int CurrentLevel { get; private set; }
    public float PowerPercent => _powerPercent / (float)MAX_PERSENT;
    public int[] Powers { get; private set; }
    [SerializeField] private int _addPercentAfterLevelComplete;
    [SerializeField] private int _addPercentAfterVideoFinised;
    [SerializeField] private OpenPowerTracker _openPowerTracker;
    private int _tutorials;
    private const int _tutorialComplete = 1;
    private const int MAX_PERSENT = 100;
    private int _powerPercent;

    public void UpdateCountCoins(int value)
    {
        Coins = value;
    }

    public void ChangeChoosePower(int id)
    {
        ChoosePower = id;
    }

    public void DeductCoins(int value)
    {
        Coins -= value;
        Helpers.Instance.CoinsCounter.UpdateCoinsCount(Coins);
    }

    public void AddCoins(int value)
    {
        Coins += value;
        Helpers.Instance.CoinsCounter.UpdateCoinsCount(Coins);
    }

    public void SavePowerAfterBuy(int powerId)
    {
        Powers[powerId] = 1;
        SaveValue(PlayerPrefsKeys.POWER.ToString() + powerId, 1);
    }

    public void SaveChooseStaff(int id)
    {
        ChooseBat = id;
        SaveValue(PlayerPrefsKeys.CHOOSE_STAFF, ChooseBat);
    }

    public void IncrementCurrentLevel()
    {
        CurrentLevel++;
    }

    public void UpdatePowerPercentAfterLevelComplete()
    {
        UpdatePowerPercent(_addPercentAfterLevelComplete);
    }

    public void UpdatePowerPercentAfterVideoFinised()
    {
        UpdatePowerPercent(_addPercentAfterVideoFinised);
    }

    public void SaveTutorialComplete()
    {
        SaveValue(PlayerPrefsKeys.TUTORIALS, _tutorialComplete);
    }

    private void UpdatePowerPercent(int addValue)
    {
        _powerPercent += addValue;
        if (_powerPercent == MAX_PERSENT)
        {
            SavePowerAfterBuy(_openPowerTracker.ClosePowerId);
            _openPowerTracker.UpdateOpenClosePowers();
            _powerPercent = 0;
        }
    }

    private void ReadAllPlayerPrefs()
    {
        ReadPowerInfo();
        Coins = GetValue(PlayerPrefsKeys.COINS);
        ChoosePower = 1;//GetValue(PlayerPrefsKeys.CHOOSE_POWER);
        CurrentLevel = GetValue(PlayerPrefsKeys.CURRENT_LEVEL);
        _powerPercent = GetValue(PlayerPrefsKeys.POWER_PERCENT);
        _tutorials = GetValue(PlayerPrefsKeys.TUTORIALS);
    }

    private void ReadPowerInfo()
    {
        int count = Helpers.Instance.PowerShop.GetPowerCount();
        Powers = new int[count];
        if (PlayerPrefs.HasKey(PlayerPrefsKeys.POWER.ToString() + "0"))
        {
            for (int i = 0; i < count; i++)
            {
                Powers[i] = GetValue(PlayerPrefsKeys.POWER.ToString() + i);
            }
        }
        else
        {
            SavePowerAfterBuy(0);
            SavePowerAfterBuy(1);
            for (int i = 2; i < count; i++)
            {
                SaveValue(PlayerPrefsKeys.POWER.ToString() + i, 0);
            }
        }
    }

    private int GetValue(PlayerPrefsKeys playerPrefsKey)
    {
        if (PlayerPrefs.HasKey(playerPrefsKey.ToString()))
        {
            return PlayerPrefs.GetInt(playerPrefsKey.ToString());
        }
        return 0;
    }

    private int GetValue(string playerPrefsKeyString)
    {
        if (PlayerPrefs.HasKey(playerPrefsKeyString))
        {
            return PlayerPrefs.GetInt(playerPrefsKeyString);
        }
        return 0;
    }

    private void SaveValue(PlayerPrefsKeys playerPrefsKey, int value)
    {
        PlayerPrefs.SetInt(playerPrefsKey.ToString(), value);
    }

    private void SaveValue(string playerPrefsKeyString, int value)
    {
        PlayerPrefs.SetInt(playerPrefsKeyString, value);
    }

    private void Awake()
    {
        Instance = this;
        ReadAllPlayerPrefs();
    }

    private void OnDisable()
    {
        SaveValue(PlayerPrefsKeys.COINS, Coins);
        SaveValue(PlayerPrefsKeys.CHOOSE_POWER, ChoosePower);
        SaveValue(PlayerPrefsKeys.CURRENT_LEVEL, CurrentLevel);
        SaveValue(PlayerPrefsKeys.POWER_PERCENT, _powerPercent);
    }
}

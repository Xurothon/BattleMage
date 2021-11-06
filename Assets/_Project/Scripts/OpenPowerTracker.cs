using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class OpenPowerTracker : MonoBehaviour
{
    public PowerBall[] PowerBalls => _powerBalls;
    public Sprite[] PowerBallSprites => _powerBallSprites;
    public int ClosePowerId { get; private set; }
    [SerializeField] private NewPowerView _newPowerView;
    [SerializeField] private Button[] _powerButtons;
    [SerializeField] private PowerBall[] _powerBalls;
    [SerializeField] private Sprite[] _powerBallSprites;
    private List<int> _openPowers = new List<int>();

    public int GetPowerId()
    {
        return _openPowers[Random.Range(0, _openPowers.Count)];
    }

    public void UpdateOpenClosePowers()
    {
        SelectOpenPowers();
        SelectClosePower();
        ActiveAllButtons();
        DisabelCloseButton();
        _newPowerView.UpdateSprite();
    }

    private void SelectOpenPowers()
    {
        if (_openPowers.Count > 1)
        {
            _openPowers.Clear();
        }
        int[] power = DataWorker.Instance.Powers;
        for (int i = 0; i < power.Length; i++)
        {
            if (power[i] == 1)
            {
                _openPowers.Add(i);
            }
        }
    }

    private void SelectClosePower()
    {
        ClosePowerId = -1;
        int[] power = DataWorker.Instance.Powers;
        for (int i = 0; i < power.Length; i++)
        {
            if (power[i] == 0)
            {
                ClosePowerId = i;
                break;
            }
        }
        if (ClosePowerId == -1)
        {
            _newPowerView.gameObject.SetActive(false);
        }
    }

    private void ActiveAllButtons()
    {
        for (int i = 0; i < _powerButtons.Length; i++)
        {
            _powerButtons[i].gameObject.SetActive(true);
        }
    }

    private void DisabelCloseButton()
    {
        int[] power = DataWorker.Instance.Powers;
        for (int i = 0; i < power.Length; i++)
        {
            if (power[i] == 0)
            {
                _powerButtons[i].gameObject.SetActive(false);
            }
        }
    }

    private void Start()
    {
        UpdateOpenClosePowers();
    }
}
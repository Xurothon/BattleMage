using UnityEngine;
using UnityEngine.UI;

public class PowerShop : MonoBehaviour
{
    [SerializeField] private PowerButton[] _powerButtons;
    [SerializeField] private PowerButton[] _mainPowerButtons;
    [SerializeField] private Button _buyPower;
    [SerializeField] private int _newPowerCost;
    [SerializeField] private Text _powerCost;

    public void ChooseStartButton()
    {
        _powerButtons[DataWorker.Instance.ChoosePower].ChooseButton();
        _mainPowerButtons[DataWorker.Instance.ChoosePower].ChooseButton();
    }

    public int GetPowerCount()
    {
        return _powerButtons.Length;
    }

    public void Active(PowerButton button, int idPower)
    {
        ChooseButton(button, idPower);
    }

    public void ActiveMain(PowerButton button, int idPower)
    {
        ChooseMainButton(button, idPower);
    }

    private void ChooseButton(PowerButton button, int idPower)
    {
        Helpers.Instance.SphereCreater.ChangeIdPower(idPower);
        Helpers.Instance.UIHelper.DisableShopPanel();
        SmearButtons();
        button.ChooseButton();
    }

    private void ChooseMainButton(PowerButton button, int idPower)
    {
        Helpers.Instance.SphereCreater.ChangeIdPower(idPower);
        SmearButtons();
        button.ChooseButton();
    }

    private void SmearButtons()
    {
        for (int i = 0; i < _powerButtons.Length; i++)
        {
            _powerButtons[i].SmearButton();
            _mainPowerButtons[i].SmearButton();
        }
    }

    private void BuyPower()
    {
        if (DataWorker.Instance.Coins >= _newPowerCost)
        {
            DataWorker.Instance.DeductCoins(_newPowerCost);
        }
    }

    private void ActiveButtons()
    {
        for (int i = 0; i < _powerButtons.Length; i++)
        {
            _powerButtons[i].Init(this, i);
            _mainPowerButtons[i].Init(this, i);
        }
    }

    private void Start()
    {
        ChooseStartButton();
        _powerCost.text = _newPowerCost.ToString();
        _buyPower.onClick.AddListener(BuyPower);
        ActiveButtons();
    }
}

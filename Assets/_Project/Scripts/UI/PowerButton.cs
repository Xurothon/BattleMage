using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image), typeof(Button))]
public class PowerButton : MonoBehaviour
{
    [SerializeField] private bool _isMain;
    private Button _button;
    private int _id;
    private PowerShop _powerShop;
    private RectTransform _rectTransform;

    public void Init(PowerShop powerShop, int id)
    {
        _powerShop = powerShop;
        _id = id;
    }

    public void SmearButton()
    {
        _rectTransform.localScale = Vector3.one;
    }

    public void ChooseButton()
    {
        _rectTransform.localScale = new Vector3(1.3f, 1.3f, 1.3f);
    }

    private void AddListener()
    {
        if (_isMain)
        {
            _button.onClick.AddListener(() => _powerShop.ActiveMain(this, _id));
        }
        else
        {
            _button.onClick.AddListener(() => _powerShop.Active(this, _id));
        }
    }

    private void Awake()
    {
        _button = GetComponent<Button>();
        _rectTransform = GetComponent<RectTransform>();
        AddListener();
    }
}

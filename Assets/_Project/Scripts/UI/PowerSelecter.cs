using UnityEngine;
using UnityEngine.UI;

public class PowerSelecter : MonoBehaviour
{
    [SerializeField] private PowerButtonSelecter[] _powerButtonSelecters;
    [SerializeField] private Sprite _selected;
    [SerializeField] private Sprite _unselected;
    private Image _currentButton;

    private void SetFirstPower()
    {
        ActiveNewPower(0);
    }

    private void OnButtonPressed(Image image)
    {
        UnselectOldPower();
        ActiveNewPower(GetPowerId(image));
    }

    private void ActiveNewPower(int index)
    {
        _currentButton = _powerButtonSelecters[index].Image;
        SelectNewPower();
        Helpers.Instance.SphereCreater.ChangeIdPower(index);
    }

    private void SelectNewPower()
    {
        _currentButton.sprite = _selected;
    }

    private void UnselectOldPower()
    {
        _currentButton.sprite = _unselected;
    }

    private int GetPowerId(Image image)
    {
        for (int i = 0; i < _powerButtonSelecters.Length; i++)
        {
            if (_powerButtonSelecters[i].Image == image)
            {
                return i;
            }
        }
        return 0;
    }

    private void Start()
    {
        SetFirstPower();
    }

    private void OnEnable()
    {
        for (int i = 0; i < _powerButtonSelecters.Length; i++)
        {
            _powerButtonSelecters[i].ButtonPress += OnButtonPressed;
        }
    }

    private void OnDisable()
    {
        for (int i = 0; i < _powerButtonSelecters.Length; i++)
        {
            _powerButtonSelecters[i].ButtonPress -= OnButtonPressed;
        }
    }
}

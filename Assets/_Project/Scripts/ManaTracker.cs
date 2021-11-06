using UnityEngine;

public class ManaTracker : MonoBehaviour
{
    public bool IsHasMana { get { return _currentManaValue > 0; } }
    [SerializeField] private UnityEngine.UI.Slider _manaSlider;
    [SerializeField] private int _startManaValue;
    private int _currentManaValue;

    public void DeductMana()
    {
        _currentManaValue--;
        UpdateManaSlider();
        if (_currentManaValue == -1)
        {
            Helpers.Instance.UIHelper.ActiveGameOverPanel();
        }
    }

    public void AddMana(int count)
    {
        _currentManaValue += count;
        UpdateManaSlider();
    }

    public void ResetMana()
    {
        _currentManaValue = _startManaValue;
        UpdateManaSlider();
    }

    private void UpdateManaSlider()
    {
        _manaSlider.value = _currentManaValue;
    }

    private void Awake()
    {
        _manaSlider.maxValue = _startManaValue;
        ResetMana();
    }
}

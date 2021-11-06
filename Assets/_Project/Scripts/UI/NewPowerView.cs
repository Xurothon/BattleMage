using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class NewPowerView : MonoBehaviour
{
    [SerializeField] private Text _percentText;
    [SerializeField] private Image _power;
    [SerializeField] private float _updateImageDuration;
    [SerializeField] private AdHelper _adHelper;
    [SerializeField] private OpenPowerTracker _openPowerTracker;

    public void UpdateSprite()
    {
        _power.sprite = _openPowerTracker.PowerBallSprites[_openPowerTracker.ClosePowerId];
    }

    private void UpdateView()
    {
        DataWorker.Instance.UpdatePowerPercentAfterLevelComplete();
        float percent = DataWorker.Instance.PowerPercent;
        _power.DOFillAmount(percent, _updateImageDuration);
        _percentText.text = (percent * 100).ToString() + " %";
    }

    private void OnEnable()
    {
        UpdateSprite();
        _adHelper.AddPowerPercentFinised += UpdateView;
        UpdateView();
    }

    private void OnDisable()
    {
        _adHelper.AddPowerPercentFinised -= UpdateView;
    }
}
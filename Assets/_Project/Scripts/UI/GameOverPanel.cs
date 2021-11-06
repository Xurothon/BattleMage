using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameOverPanel : MonoBehaviour
{
    [SerializeField] private GameObject _restartButton;
    [SerializeField] private Image _image;
    [SerializeField] private float _tryAgainTime;

    private void OnEnable()
    {
        _image.fillAmount = 1f;
        _image.gameObject.SetActive(true);
        _restartButton.SetActive(false);
        this.Wait(_tryAgainTime, () => _restartButton.SetActive(true));
        _image.DOFillAmount(0, _tryAgainTime);
        this.Wait(_tryAgainTime, () => _image.gameObject.SetActive(false));
    }
}

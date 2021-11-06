using UnityEngine.UI;
using DG.Tweening;
using UnityEngine;

public class LevelCompletePanel : MonoBehaviour
{
    [SerializeField] private GameObject _noThankButton;
    [SerializeField] private float _noThanksTime;

    private void OnEnable()
    {
        _noThankButton.SetActive(false);
        this.Wait(_noThanksTime, () => _noThankButton.SetActive(true));
    }
}

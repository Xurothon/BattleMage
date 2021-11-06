using UnityEngine;
using UnityEngine.UI;

public class DestructivePower : MonoBehaviour
{
    [SerializeField] private Image _powerBallImage;
    private PowerBall _power;

    public bool IsCanDie(PowerBall power)
    {
        return _power.PowerType == power.PowerType;
    }

    public void DisablePowerBallImage()
    {
        _powerBallImage.enabled = false;
    }

    public void Initialize(PowerBall powerType, Sprite powerImage)
    {
        _power = powerType;
        _powerBallImage.sprite = powerImage;
    }
}
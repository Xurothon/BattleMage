using UnityEngine;

public class TimeScaler : MonoBehaviour
{
    private float _minTimeScaler = 0;
    private float _maxTimeScaler = 1;

    public void TimeScalerUp()
    {
        Time.timeScale = _maxTimeScaler;
    }

    public void TimeScalerDown()
    {
        Time.timeScale = _minTimeScaler;
    }
}

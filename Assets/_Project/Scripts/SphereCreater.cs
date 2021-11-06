using UnityEngine;

public class SphereCreater : MonoBehaviour
{
    [SerializeField] private Transform _startPoint;
    [SerializeField] private PowerBall[] _templates;
    [SerializeField] private ParticleSystem[] _powerParticles;
    [SerializeField] private float _speed;
    [SerializeField] private float _timeToDestroy;
    private int _currentIdPower;

    public void ChangeIdPower(int id)
    {
        DataWorker.Instance.ChangeChoosePower(id);
        ChangePower();
    }

    public void CreatePowerSphere(Ray ray)
    {
        PowerBall temp = Instantiate(_templates[_currentIdPower]);
        temp.transform.position = _startPoint.position;
        Vector3 direction = ray.direction * _speed + ray.origin - _startPoint.position;
        temp.AddForce(direction);
        Destroy(temp.gameObject, _timeToDestroy);
    }

    private void ChangePower()
    {
        _currentIdPower = DataWorker.Instance.ChoosePower;
        DisableAllPowerParticles();
        _powerParticles[_currentIdPower].gameObject.SetActive(true);
    }

    private void DisableAllPowerParticles()
    {
        for (int i = 0; i < _powerParticles.Length; i++)
        {
            _powerParticles[i].gameObject.SetActive(false);
        }
    }

    private void Start()
    {
        ChangePower();
    }
}

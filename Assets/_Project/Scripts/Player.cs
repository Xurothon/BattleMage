using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    [SerializeField] private float _durationRotate;
    private Transform _nearestEnemy;

    public void ChangeNearestEnemy()
    {
        _nearestEnemy = Helpers.Instance.PositionChanger.GetCurrentStep().GetEnemyTransform();
    }

    private void Update()
    {
        if (Helpers.Instance.PositionChanger.GetCurrentStep().IsHasEnemy)
        {
            if (_nearestEnemy == null)
            {
                _nearestEnemy = Helpers.Instance.PositionChanger.GetCurrentStep().GetEnemyTransform();
            }
            else
            {
                transform.DOLookAt(_nearestEnemy.position, _durationRotate);
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<Enemy>())
        {
            if (!other.gameObject.GetComponent<Enemy>().IsDie)
            {
                Helpers.Instance.UIHelper.ActiveGameOverPanel();
            }
        }
    }

    private void Awake()
    {
        GetComponent<Rigidbody>().sleepThreshold = 0f;
    }
}

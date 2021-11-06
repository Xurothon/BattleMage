using UnityEngine;
using System.Collections.Generic;

public class Step : MonoBehaviour
{
    public Transform StartTransform { get { return _startTransform; } }
    public Transform EndTransform { get { return _endTransform; } }
    public Transform NextTransform { get { return _nextTransform; } }
    public bool IsHasEnemy { get { return _currentEnemies.Count > 0; } }
    [SerializeField] private Transform _startTransform;
    [SerializeField] private Transform _endTransform;
    [SerializeField] private Transform _nextTransform;
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Enemy _enemyWithShield;
    [SerializeField] private Transform[] _enemyPosition;
    [SerializeField] private Transform[] _enemyWithShieldPosition;
    [SerializeField] private OpenPowerTracker _openPowerTracker;
    private List<Enemy> _currentEnemies;
    private int _powerCount;

    public void RemoveEnemies(Enemy enemy)
    {
        Helpers.Instance.CoinsCounter.AddCoin();
        _currentEnemies.Remove(enemy);
        if (_currentEnemies.Count == 0)
        {
            Helpers.Instance.PositionChanger.SetNextPosition();
        }
    }

    public void ActiveEnemyMoving()
    {
        for (int i = 0; i < _enemyPosition.Length + _enemyWithShieldPosition.Length; i++)
        {
            _currentEnemies[i].StartMove();
        }
    }

    public void ResetStep()
    {
        RemoveAllEnemies();
        CreateEnemies();
        ActiveEnemyMoving();
    }

    public Transform GetEnemyTransform()
    {
        if (_currentEnemies.Count > 0)
        {
            if (_currentEnemies[0] == null)
            {
                _currentEnemies.RemoveAt(0);
                return GetEnemyTransform();
            }
            else
            {
                return _currentEnemies[0].transform;
            }
        }
        return null;
    }

    private void CreateEnemies()
    {
        Create(_enemy, _enemyPosition);
        Create(_enemyWithShield, _enemyWithShieldPosition);
    }

    private void Create(Enemy enemyTemplate, Transform[] positions)
    {
        for (int i = 0; i < positions.Length; i++)
        {
            Enemy enemy = Instantiate(enemyTemplate);
            enemy.transform.parent = transform;
            enemy.transform.position = positions[i].position;
            enemy.SetCurrentStep(this);
            int powerId = _openPowerTracker.GetPowerId();
            enemy.DestructivePower.Initialize(_openPowerTracker.PowerBalls[powerId], _openPowerTracker.PowerBallSprites[powerId]);
            _currentEnemies.Add(enemy);
        }
    }

    private void RemoveAllEnemies()
    {
        while (_currentEnemies.Count > 0)
        {
            Enemy tempEnemy = _currentEnemies[0];
            _currentEnemies.Remove(tempEnemy);
            Destroy(tempEnemy.gameObject);
        }
    }

    private void Start()
    {
        CreateEnemies();
    }

    private void Awake()
    {
        _currentEnemies = new List<Enemy>();
    }
}

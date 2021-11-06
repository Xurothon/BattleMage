using UnityEngine;
using DG.Tweening;

public class PositionChanger : MonoBehaviour
{
    [SerializeField] private Step[] _steps;
    [SerializeField] private Transform _player;
    [SerializeField] private float _durationRun;
    [SerializeField] private float _durationMove;
    private int _currentStepId;
    private Sequence _mySequence;

    public void SetNextPosition()
    {
        if (_currentStepId == _steps.Length - 1)
        {
            MovePlayerToEndPoint();
        }
        else
        {
            MovePlayerToEndTransform();
        }
    }

    public void ActiveEnemyMove()
    {
        _steps[_currentStepId].ActiveEnemyMoving();
    }

    public Vector3 GetStartPosition()
    {
        return _steps[_currentStepId].StartTransform.position;
    }

    public void ResetCurrentStep()
    {
        _steps[_currentStepId].ResetStep();
    }

    public Step GetCurrentStep()
    {
        return _steps[_currentStepId];
    }

    private void MovePlayerToEndTransform()
    {
        _player.DOMove(_steps[_currentStepId].EndTransform.position, _durationRun, false).OnComplete(() => MovePlayerToNextTransform());
    }

    private void MovePlayerToNextTransform()
    {
        _player.DOMove(_steps[_currentStepId].NextTransform.position, _durationMove, false).OnComplete(() => MovePlayerToStartTransform());
    }

    private void MovePlayerToStartTransform()
    {

        _currentStepId++;
        _player.DOMove(_steps[_currentStepId].StartTransform.position, _durationMove, false).OnComplete(() => ActiveEnemyMove());
    }

    private void MovePlayerToEndPoint()
    {
        _player.DOMove(_steps[_currentStepId].EndTransform.position, _durationMove, false);
    }

    private void Awake()
    {
        _player.position = _steps[_currentStepId].StartTransform.position;
        _mySequence = DOTween.Sequence();
    }
}

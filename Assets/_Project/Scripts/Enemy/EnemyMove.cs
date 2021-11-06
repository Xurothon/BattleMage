using UnityEngine;
using DG.Tweening;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private float _speed;

    public void Move(Vector3 endPosition)
    {
        float duration = Vector3.Distance(endPosition, transform.position) / _speed;
        transform.DOMove(endPosition, duration);
    }

    public void StopMove()
    {
        transform.DOKill();
    }
}

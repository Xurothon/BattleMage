using UnityEngine;
using DG.Tweening;

public class BubblePower : PowerBall
{
    [SerializeField] private Transform _model;
    [SerializeField] private float _maxScale;
    [SerializeField] private float _duration;
    [SerializeField] private ParticleSystem _bubbleHit;

    private new void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent(out EnemyWithShield enemyWithShield))
        {
            Destroy(gameObject, _timeToDestroy);
            if (enemyWithShield.DestructivePower.IsCanDie(this))
            {
                if (enemyWithShield.HasShield)
                {
                    enemyWithShield.ThrowShield();
                    ParticleSystem particleSystem = Instantiate(_bubbleHit);
                    particleSystem.transform.position = other.contacts[0].point;
                    Destroy(gameObject);
                }
                else
                {
                    enemyWithShield.transform.parent = transform;
                    _model.DOScale(new Vector3(_maxScale, _maxScale, _maxScale), _duration);
                    _rigidbody.AddForce(Vector3.up * 5, ForceMode.Impulse);
                    enemyWithShield.TakeDamage(enemyWithShield.transform.position, _addVelocity, _buffDirection);
                    enemyWithShield.MakeKinematic();
                }
            }
        }
        else if (other.gameObject.TryGetComponent(out Enemy enemy))
        {
            Destroy(gameObject, _timeToDestroy);
            if (enemy.DestructivePower.IsCanDie(this))
            {
                transform.DOMoveZ(transform.position.z + 3, 0.1f);
                enemy.transform.parent = transform;
                _model.DOScale(new Vector3(_maxScale, _maxScale, _maxScale), _duration);
                _rigidbody.AddForce(Vector3.up * 5, ForceMode.Impulse);
                enemy.TakeDamage(enemy.transform.position, _addVelocity, _buffDirection);
                enemy.MakeKinematic();
            }
        }
        else
        {
            Destroy(gameObject, _timeToDestroy);
        }
    }
}

using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PowerBall : MonoBehaviour
{
    public PowerType PowerType => _powerType;
    [SerializeField] protected float _addVelocity;
    [SerializeField] protected float _timeToDestroy;
    [SerializeField] protected Vector3 _buffDirection;
    [SerializeField] protected PowerType _powerType;
    protected Rigidbody _rigidbody;

    public void AddForce(Vector3 direction)
    {
        _rigidbody.AddForce(direction, ForceMode.Impulse);
    }

    private void StopBall()
    {
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.isKinematic = true;
        _rigidbody.useGravity = false;
    }

    protected void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent(out EnemyWithShield enemyWithShield))
        {
            Destroy(gameObject, _timeToDestroy);
            if (enemyWithShield.DestructivePower.IsCanDie(this))
            {
                if (enemyWithShield.HasShield)
                {
                    StopBall();
                    enemyWithShield.ThrowShield();
                }
                else
                {
                    enemyWithShield.TakeDamage(transform.position, _addVelocity, _buffDirection);
                }
            }
        }
        else if (other.gameObject.TryGetComponent(out Enemy enemy))
        {
            Destroy(gameObject, _timeToDestroy);
            if (enemy.DestructivePower.IsCanDie(this))
            {
                StopBall();
                enemy.TakeDamage(transform.position, _addVelocity, _buffDirection);
            }
        }
    }

    protected void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
}

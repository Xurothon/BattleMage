using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class StonePower : PowerBall
{
    [SerializeField] private ParticleSystem _stoneHit;
    private new void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent(out EnemyWithShield enemyWithShield))
        {
            Destroy(gameObject);
            if (enemyWithShield.DestructivePower.IsCanDie(this))
            {
                if (enemyWithShield.HasShield)
                {
                    enemyWithShield.ThrowShield();
                }
                else
                {
                    enemyWithShield.TakeDamage(transform.position, _addVelocity, _buffDirection);
                }
                ParticleSystem particleSystem = Instantiate(_stoneHit);
                particleSystem.transform.position = other.contacts[0].point;
            }
        }
        else if (other.gameObject.TryGetComponent(out Enemy enemy))
        {
            Destroy(gameObject);
            if (enemy.DestructivePower.IsCanDie(this))
            {
                enemy.TakeDamage(transform.position, _addVelocity, _buffDirection);
                ParticleSystem particleSystem = Instantiate(_stoneHit);
                particleSystem.transform.position = other.contacts[0].point;
            }
        }
    }
}

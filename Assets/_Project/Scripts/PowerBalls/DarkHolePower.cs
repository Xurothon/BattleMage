using UnityEngine;

public class DarkHolePower : PowerBall
{
    [SerializeField] private ParticleSystem _darkHole;
    private new void OnCollisionEnter(Collision other)
    {
        Destroy(gameObject, _timeToDestroy);
        if (other.gameObject.TryGetComponent(out EnemyWithShield enemyWithShield))
        {
            if (enemyWithShield.DestructivePower.IsCanDie(this))
            {
                if (enemyWithShield.HasShield)
                {
                    enemyWithShield.ThrowShield();
                }
                else
                {
                    enemyWithShield.DragInDarkMole();
                    ParticleSystem particleSystem = Instantiate(_darkHole);
                    particleSystem.transform.position = enemyWithShield.transform.position
                        - new Vector3(0, enemyWithShield.transform.localScale.y / 2, 0) + _buffDirection;
                    Destroy(particleSystem.gameObject, _timeToDestroy);
                }
            }
            Destroy(gameObject);
        }
        else if (other.gameObject.TryGetComponent(out Enemy enemy))
        {
            if (enemy.DestructivePower.IsCanDie(this))
            {
                enemy.DragInDarkMole();
                ParticleSystem particleSystem = Instantiate(_darkHole);
                particleSystem.transform.position = enemy.transform.position
                    - new Vector3(0, enemy.transform.localScale.y / 2, 0) + _buffDirection;
                Destroy(particleSystem.gameObject, _timeToDestroy);
            }
            Destroy(gameObject);
        }
    }
}

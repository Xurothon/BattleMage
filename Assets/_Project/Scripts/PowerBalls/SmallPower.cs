using UnityEngine;

public class SmallPower : PowerBall
{
    private new void OnCollisionEnter(Collision other)
    {
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
                    enemyWithShield.MakeSmaller();
                }
            }
            Destroy(gameObject);
        }
        else if (other.gameObject.TryGetComponent(out Enemy enemy))
        {
            if (enemy.DestructivePower.IsCanDie(this))
            {
                enemy.MakeSmaller();
            }
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

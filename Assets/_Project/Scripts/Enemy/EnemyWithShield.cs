using UnityEngine;

public class EnemyWithShield : Enemy
{
    public bool HasShield { get; private set; }
    [SerializeField] private Shield _shield;

    public new void MakePhysical()
    {
        base.MakePhysical();
    }

    public void ThrowShield()
    {
        _shield.Throw();
        _animator.SetTrigger("SimpleWalk");
        HasShield = false;
    }

    private new void Awake()
    {
        HasShield = true;
        base.Awake();
    }
}

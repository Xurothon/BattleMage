using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(Animator), typeof(BoxCollider))]
[RequireComponent(typeof(EnemyMove), typeof(RagdollControl))]
public class Enemy : MonoBehaviour
{
    public bool IsDie { get; private set; }
    public bool IsActive { get; private set; }
    public DestructivePower DestructivePower { get; private set; }
    [SerializeField] private Rigidbody _forceRigidbody;
    [SerializeField] private float _smallScaleDuration;
    private Step _currentStep;
    private EnemyMove _enemyMove;
    private RagdollControl _ragdollControl;
    protected Animator _animator;
    private BoxCollider _boxCollider;

    public void TakeDamage(Vector3 sphereСenter, float addVelocity, Vector3 buffDirection)
    {
        if (!IsDie)
        {
            MakePhysical();
        }
        DestructivePower.DisablePowerBallImage();
        Vector3 direction = transform.position - sphereСenter + buffDirection;
        _forceRigidbody.AddForce(direction.normalized * addVelocity, ForceMode.Impulse);
        this.Wait(0.8f, RemoveEnemy);
        this.Wait(2f, () => Destroy(gameObject));
    }

    public void MakeSmaller()
    {
        if (!IsDie)
        {
            MakePhysical();
            _ragdollControl.MakePhysical();
        }
        DestructivePower.DisablePowerBallImage();
        transform.DOScale(Vector3.zero, _smallScaleDuration);
        this.Wait(0.8f, RemoveEnemy);
        this.Wait(2f, () => Destroy(gameObject));
    }

    public void DragInDarkMole()
    {
        if (!IsDie)
        {
            MakePhysical();
            _ragdollControl.MakePhysical();
            _ragdollControl.DisableColliders();
        }

        DestructivePower.DisablePowerBallImage();
        this.Wait(0.8f, RemoveEnemy);
        this.Wait(2f, () => Destroy(gameObject));
    }

    public void StartMove()
    {
        Active();
        _enemyMove.Move(_currentStep.StartTransform.position);
        _animator.enabled = true;
        _animator.SetTrigger("Walk");
    }

    public void Active()
    {
        IsActive = true;
    }

    public void MakePhysical()
    {
        IsDie = true;
        _animator.enabled = false;
        _boxCollider.enabled = false;
        _enemyMove.StopMove();
        _ragdollControl.MakePhysical();
    }

    public void MakeKinematic()
    {
        this.Wait(0.1f, _ragdollControl.MakeLightweight);
    }

    public void SetCurrentStep(Step step)
    {
        _currentStep = step;
    }

    protected void RemoveEnemy()
    {
        _currentStep.RemoveEnemies(this);
        Helpers.Instance.Player.ChangeNearestEnemy();
    }

    protected void Awake()
    {
        _enemyMove = GetComponent<EnemyMove>();
        _ragdollControl = GetComponent<RagdollControl>();
        _animator = GetComponent<Animator>();
        _boxCollider = GetComponent<BoxCollider>();
        DestructivePower = GetComponent<DestructivePower>();
        _forceRigidbody.sleepThreshold = 0.0f;
    }
}

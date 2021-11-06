using UnityEngine;

[RequireComponent(typeof(Animator), typeof(CoinSpawner))]
public class Chest : MonoBehaviour
{
    [SerializeField] private AnimationClip _open;
    private Animator _animator;
    private CoinSpawner _coinSpawner;
    private bool _isOpen;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PowerBall powerBall))
        {
            if (!_isOpen)
            {
                _animator.SetTrigger("Open");
                this.Wait(_open.length, _coinSpawner.Create);
                _isOpen = true;
            }
        }
    }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _coinSpawner = GetComponent<CoinSpawner>();
    }
}

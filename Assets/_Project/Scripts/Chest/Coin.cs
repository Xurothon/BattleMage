using UnityEngine;
using DG.Tweening;

public class Coin : MonoBehaviour
{
    [SerializeField] private float _duration;
    private void Start()
    {
        transform.DOLocalMove(Helpers.Instance.Player.transform.position, _duration);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            Helpers.Instance.CoinsCounter.AddCoin();
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        DOTween.Kill(transform);
    }
}

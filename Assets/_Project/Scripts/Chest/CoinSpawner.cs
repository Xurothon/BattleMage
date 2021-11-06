using UnityEngine;
using System.Collections;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private int _count;
    [SerializeField] private Coin _template;
    [SerializeField] private Transform _startPoint;
    [SerializeField] private float _timeBetweenSpawn;

    public void Create()
    {
        StartCoroutine(CreateCoins());
    }

    private IEnumerator CreateCoins()
    {
        for (int i = 0; i < _count; i++)
        {
            Coin temp = Instantiate(_template);
            temp.transform.position = _startPoint.position;
            yield return new WaitForSeconds(_timeBetweenSpawn);
        }
    }
}

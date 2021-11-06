using UnityEngine;

public class EnemySoundPlayer : MonoBehaviour
{
    [SerializeField] private GameObject _stars;
    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.GetComponent<Ground>())
        {
            _stars.SetActive(true);
        }
    }
}

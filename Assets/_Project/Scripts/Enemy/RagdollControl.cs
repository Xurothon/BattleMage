using UnityEngine;

public class RagdollControl : MonoBehaviour
{
    [SerializeField] private Rigidbody[] _allRigidbodies;
    [SerializeField] private int _extraColliders;

    public void MakePhysical()
    {
        for (int i = 0; i < _allRigidbodies.Length; i++)
        {
            _allRigidbodies[i].isKinematic = false;
        }
    }

    public void DisableColliders()
    {
        for (int i = 0; i < _allRigidbodies.Length - _extraColliders; i++)
        {
            _allRigidbodies[i].GetComponent<Collider>().enabled = false;
        }
    }

    public void MakeKinematic()
    {
        for (int i = 0; i < _allRigidbodies.Length; i++)
        {
            _allRigidbodies[i].isKinematic = true;
        }
    }

    public void MakeLightweight()
    {
        for (int i = 0; i < _allRigidbodies.Length; i++)
        {
            _allRigidbodies[i].useGravity = false;
            _allRigidbodies[i].isKinematic = true;
        }
    }

    private void Awake()
    {
        MakeKinematic();
    }
}

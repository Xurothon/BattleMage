using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class Shield : MonoBehaviour
{
    private BoxCollider _boxCollider;
    private Rigidbody _rigidbody;

    public void Throw()
    {
        transform.parent = null;
        _boxCollider.isTrigger = false;
        _rigidbody.isKinematic = false;
        _rigidbody.AddForce(Vector3.up * 20, ForceMode.Impulse);
    }

    private void Awake()
    {
        _boxCollider = GetComponent<BoxCollider>();
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.isKinematic = true;
    }
}

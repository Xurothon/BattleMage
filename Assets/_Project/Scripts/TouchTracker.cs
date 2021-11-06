using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class TouchTracker : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    [SerializeField] private Transform _startObjectPosition;
    [SerializeField] private Transform _staffTransform;
    [SerializeField] private ParticleSystem _staffParticle;
    [SerializeField] private float _addPositionX;
    [SerializeField] private float _addPositionZ;
    private Transform _powerPosition;
    private SphereCollider _sphereCollider;
    private Camera _mainCamera;
    private Vector2 _startTouchPosition;
    private Vector2 _endTouchPosition;
    private bool _isBall;
    private float _yStartValueRotation;
    private float _xStartValueRotation;

    public void OnDrag(PointerEventData eventData)
    {
        if (Helpers.Instance.ManaTracker.IsHasMana)
        {
            _endTouchPosition = _mainCamera.ScreenToViewportPoint(Input.mousePosition);
            float diffecenceX = -1 * (_startTouchPosition.x - _endTouchPosition.x);
            float diffecenceY = -1 * (_startTouchPosition.y - _endTouchPosition.y);
            _powerPosition.position = new Vector3(_addPositionX * diffecenceX, 0, _addPositionZ * diffecenceY) + _startObjectPosition.position;
            _staffTransform.rotation = Quaternion.Euler(_xStartValueRotation + 10, _yStartValueRotation + diffecenceX * 60, 0);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _startTouchPosition = _mainCamera.ScreenToViewportPoint(Input.mousePosition);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _staffParticle.Play();
        _staffTransform.rotation = Quaternion.Euler(_xStartValueRotation, _yStartValueRotation, 0);
        _sphereCollider.enabled = true;
        if (_isBall)
        {
            Vector3 endPosition = _powerPosition.position;
            _powerPosition.transform.position = Helpers.Instance.PositionChanger.GetStartPosition();
            _powerPosition.transform.transform.DOMove(endPosition, 0.5f);
        }
        this.Wait(0.5f, () => _sphereCollider.enabled = false);
    }

    private void Start()
    {
        _yStartValueRotation = _staffTransform.rotation.eulerAngles.y;
        _xStartValueRotation = _staffTransform.rotation.eulerAngles.x;
        _mainCamera = Camera.main;
    }
}

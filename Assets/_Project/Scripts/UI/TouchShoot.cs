using UnityEngine;
using UnityEngine.EventSystems;

public class TouchShoot : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Animator _staff;
    [SerializeField] private AnimationClip _activeStaff;
    [SerializeField] private ParticleSystem _staffTornado;

    public void OnPointerClick(PointerEventData eventData)
    {
        _staffTornado.Stop();
        _staff.SetTrigger("Active");
        this.Wait(_activeStaff.length, _staffTornado.Play);
        Helpers.Instance.ManaTracker.DeductMana();
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Helpers.Instance.SphereCreater.CreatePowerSphere(ray);
    }
}

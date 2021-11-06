using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Button), typeof(Image))]
public class PowerButtonSelecter : MonoBehaviour
{
    public event UnityAction<Image> ButtonPress;
    public Image Image { get; private set; }

    private void Awake()
    {
        Image = GetComponent<Image>();
        GetComponent<Button>().onClick.AddListener(() => ButtonPress?.Invoke(Image));
    }
}

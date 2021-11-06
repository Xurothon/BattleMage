using UnityEngine;

public class EnemyMaterialChanger : MonoBehaviour
{
    [SerializeField] private SkinnedMeshRenderer _bodyMeshRenderer;
    [SerializeField] private Material _materialAfterDie;

    public void ChangeMaterials()
    {
        _bodyMeshRenderer.material = _materialAfterDie;
    }
}

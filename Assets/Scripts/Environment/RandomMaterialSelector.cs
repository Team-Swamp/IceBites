using UnityEngine;

namespace Environment
{
    public sealed class RandomMaterialSelector : MonoBehaviour
    {
        [SerializeField] public Material[] materials;

        private MeshRenderer _meshRenderer;

        private void Awake()
        {
            _meshRenderer = GetComponent<MeshRenderer>();
        
            if (materials.Length > 0)
                SetRandomMaterial();
            else
                Debug.LogError("No materials found in the materials array. Please assign some materials.");
        }

        private void SetRandomMaterial()
        {
            int randomNumber = Random.Range(0, materials.Length);
            _meshRenderer.material = materials[randomNumber];
        }
    }
}

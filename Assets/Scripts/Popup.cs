using UnityEngine;

public class Popup : MonoBehaviour
{
    private void Start()
    {
        var meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.sortingOrder = 100;
        meshRenderer.sortingLayerName = "Background"; // to make visible because of lights
    }
}

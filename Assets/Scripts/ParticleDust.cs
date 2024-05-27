using UnityEngine;

public class ParticleDust : MonoBehaviour
{
    private void Start()
    {
        Invoke("DestroyGameObject", .5f);
    }
    private void DestroyGameObject()
    {
        Destroy(transform.gameObject);
    }
}

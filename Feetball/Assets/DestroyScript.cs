using UnityEngine;

public class DestroyScript : MonoBehaviour
{
    public float destroyTime;

    private void Start()
    {
        Invoke("DestroyItself", destroyTime);
    }

    private void DestroyItself()
    {
        Destroy(gameObject);
    }
}

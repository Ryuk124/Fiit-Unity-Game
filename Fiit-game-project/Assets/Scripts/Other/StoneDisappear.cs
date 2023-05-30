using UnityEngine;

public class StoneDisappear : MonoBehaviour
{
    public GameObject slug;
    private void OnColliderect(Collision collision)
    {
        if (collision.gameObject == slug)
            Destroy(gameObject);
    }
}

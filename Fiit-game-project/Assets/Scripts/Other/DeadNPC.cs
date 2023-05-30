using UnityEngine;

public class DeadNPC : MonoBehaviour
{
    public GameObject Slug;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == Slug)
            Destroy(gameObject);
    }
}

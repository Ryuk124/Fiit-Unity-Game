using UnityEngine;

public class StoneDisappear : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "slug")
            Destroy(gameObject);
    }
}

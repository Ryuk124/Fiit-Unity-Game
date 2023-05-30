using UnityEngine;

public class SlugAppearance : MonoBehaviour
{
    public GameObject Slug;
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "OtherGround")
        {
            Slug.SetActive(true);
        }
    }
}

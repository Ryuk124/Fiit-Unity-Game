using TMPro;
using UnityEngine;

public class DeathCount : MonoBehaviour
{
    TextMeshProUGUI text;
    public static int Enemies;
    public GameObject Portal;
    public static int deathEnemiesForPortal = 5;

    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        Enemies = 0;
    }

    void Update()
    {
        text.text = $"{Enemies}/{deathEnemiesForPortal}";
        if (Enemies >= deathEnemiesForPortal)
            Portal.SetActive(true);
        else Portal.SetActive(false);
    }
}

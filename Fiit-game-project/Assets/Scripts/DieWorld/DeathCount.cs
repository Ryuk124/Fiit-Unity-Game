using TMPro;
using UnityEngine;

public class DeathCount : MonoBehaviour
{
    TextMeshProUGUI text;
    public static int Enemies;
    public GameObject Portal;
    private int deathEnemiesForPortal = 5;

    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        text.text = $"Убито: {Enemies}";
        if (Enemies >= deathEnemiesForPortal)
            Portal.SetActive(true);
        else Portal.SetActive(false);
    }
}

using TMPro;
using UnityEngine;

public class DeathCount : MonoBehaviour
{
    TextMeshProUGUI text;
    public static int enemies;

    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        text.text = $"Убито: {enemies}";
    }
}

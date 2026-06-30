using UnityEngine;
using TMPro;

/// <summary>
/// Listens to UIUpdateSoulsEvent and updates the text display on the HUD.
/// </summary>
public class UISoulCounter : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private TextMeshProUGUI soulText;

    private void OnEnable()
    {
        EventBus.Subscribe<UIUpdateSoulsEvent>(OnUpdateSoulsUI);
    }

    private void OnDisable()
    {
        EventBus.Unsubscribe<UIUpdateSoulsEvent>(OnUpdateSoulsUI);
    }

    private void Start()
    {
        if (soulText != null)
        {
            soulText.text = "X";
        }
    }

    /// <summary>
    /// Callback triggered by the GameManager whenever the total soul count changes.
    /// </summary>
    private void OnUpdateSoulsUI(UIUpdateSoulsEvent eventData)
    {
        if (soulText != null)
        {
            soulText.text = eventData.TotalSouls.ToString();
        }
    }
}
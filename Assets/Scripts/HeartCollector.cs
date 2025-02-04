using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HeartCollector : MonoBehaviour
{
    [Header("UI References")]
    public TextMeshProUGUI heartCountText;    
    public UIManager uiManager;               

    private int heartsCollected = 0;
    private const int HEARTS_TO_WIN = 10;

    void Start()
    {
        // Check if our UI references are set
        if (heartCountText == null)
        {
            Debug.LogError("Heart Count Text is not assigned to HeartCollector!");
        }
        if (uiManager == null)
        {
            Debug.LogError("UI Manager is not assigned to HeartCollector!");
        }

        UpdateHeartUI();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Heart"))
        {
            heartsCollected++;
            UpdateHeartUI();
            Destroy(other.gameObject);

            // Only show proposal if we have both the UI Manager and enough hearts
            if (uiManager != null && heartsCollected >= HEARTS_TO_WIN)
            {
                uiManager.ShowProposal();
            }
        }
    }

    void UpdateHeartUI()
    {
        if (heartCountText != null)
        {
            heartCountText.text = $"Hearts: {heartsCollected}/{HEARTS_TO_WIN}";
        }
    }
}

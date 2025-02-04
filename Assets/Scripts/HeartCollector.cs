using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HeartCollector : MonoBehaviour
{
    [Header("UI References")]
    public TextMeshProUGUI heartCountText;    // Reference to the UI text
    public UIManager uiManager;               // Reference to UI Manager

    private int heartsCollected = 0;
    private const int HEARTS_TO_WIN = 10;

    void Start()
    {
        // Verify our text component is connected
        if (heartCountText == null)
        {
            Debug.LogError("HeartCountText is not assigned in HeartCollector!");
            return;
        }

        // Set initial text
        UpdateHeartUI();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Heart"))
        {
            heartsCollected++;
            UpdateHeartUI();
            AudioManager.Instance.PlayHeartCollect();
            Destroy(other.gameObject);

            if (heartsCollected >= HEARTS_TO_WIN)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("EndScene");
            }
        }
    }

    void UpdateHeartUI()
    {
        if (heartCountText != null)
        {
            heartCountText.text = $"Hearts: {heartsCollected}/{HEARTS_TO_WIN}";
            Debug.Log($"Updated heart count to: {heartsCollected}"); // Debug log
        }
        else
        {
            Debug.LogError("HeartCountText is null in HeartCollector!");
        }
    }
}
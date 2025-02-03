using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HeartCollector : MonoBehaviour
{
    public TextMeshProUGUI heartCountText;
    public UIManager uiManager;
    private int heartsCollected = 0;
    private const int HEARTS_TO_WIN = 10;

    void Start()
    {
        UpdateHeartUI();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Heart"))
        {
            heartsCollected++;
            UpdateHeartUI();
            Destroy(other.gameObject);  // Remove the collected heart

            if (heartsCollected >= HEARTS_TO_WIN)
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
    


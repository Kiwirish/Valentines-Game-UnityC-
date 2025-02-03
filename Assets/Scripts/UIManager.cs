using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject proposalPanel;
    public GameObject successPanel;
    public Button yesButton;
    public Button noButton;
    public Vector3 originalNoButtonScale;

    void Start()
    {
        // Hide panels at start
        if (proposalPanel) proposalPanel.SetActive(false);
        if (successPanel) successPanel.SetActive(false);

        // Store original scale of No button
        if (noButton) originalNoButtonScale = noButton.transform.localScale;

        // Setup button listeners
        if (yesButton) yesButton.onClick.AddListener(OnYesClicked);
        if (noButton) noButton.onClick.AddListener(OnNoClicked);
    }

    public void ShowProposal()
    {
        if (proposalPanel)
        {
            proposalPanel.SetActive(true);
            // Reset no button scale
            if (noButton) noButton.transform.localScale = originalNoButtonScale;
        }
    }

    public void OnNoClicked()
    {
        if (noButton && yesButton)
        {
            // Shrink No button
            noButton.transform.localScale *= 0.9f;
            // Grow Yes button
            yesButton.transform.localScale *= 1.1f;
        }
    }

    public void OnYesClicked()
    {
        if (proposalPanel && successPanel)
        {
            proposalPanel.SetActive(false);
            successPanel.SetActive(true);
        }
    }
}
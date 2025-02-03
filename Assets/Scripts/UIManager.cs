using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("UI Panels")]
    public GameObject proposalPanel;    // Drag ProposalPanel here
    public GameObject successPanel;     // Drag SuccessPanel here

    [Header("Buttons")]
    public Button yesButton;           // Drag Yes button here
    public Button noButton;            // Drag No button here

    private Vector3 originalNoButtonScale;
    private Vector3 originalYesButtonScale;

    void Start()
    {
        // Store original button scales
        originalNoButtonScale = noButton.transform.localScale;
        originalYesButtonScale = yesButton.transform.localScale;

        // Hide panels at start
        proposalPanel.SetActive(false);
        successPanel.SetActive(false);

        // Add button listeners
        yesButton.onClick.AddListener(OnYesClicked);
        noButton.onClick.AddListener(OnNoClicked);
    }

    public void ShowProposal()
    {
        // Reset button scales
        noButton.transform.localScale = originalNoButtonScale;
        yesButton.transform.localScale = originalYesButtonScale;

        // Show proposal panel
        proposalPanel.SetActive(true);
    }

    public void OnNoClicked()
    {
        // Shrink No button and grow Yes button
        noButton.transform.localScale *= 0.9f;
        yesButton.transform.localScale *= 1.1f;
    }

    public void OnYesClicked()
    {
        // Hide proposal and show success
        proposalPanel.SetActive(false);
        successPanel.SetActive(true);
    }
}
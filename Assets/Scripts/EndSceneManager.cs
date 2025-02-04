using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndSceneManager : MonoBehaviour
{
    [Header("Main UI Elements")]
    public TextMeshProUGUI valentineText;     // "Will you be my Valentine?"
    public Button yesButton;
    public Button noButton;

    [Header("Success Modal")]
    public GameObject successModal;            // Panel containing the success message
    public TextMeshProUGUI successText;       // "Yay! "

    private Vector3 originalNoButtonScale;
    private Vector3 originalYesButtonScale;

    void Start()
    {
        // Store original button scales
        originalNoButtonScale = noButton.transform.localScale;
        originalYesButtonScale = yesButton.transform.localScale;

        // Hide success modal at start
        successModal.SetActive(false);

        // Set up button listeners
        yesButton.onClick.AddListener(OnYesClicked);
        noButton.onClick.AddListener(OnNoClicked);
    }

    public void OnNoClicked()
    {
        // Shrink No button and grow Yes button
        noButton.transform.localScale *= 0.9f;
        yesButton.transform.localScale *= 1.1f;
    }

    public void OnYesClicked()
    {
        // Show success modal
        successModal.SetActive(true);
    }
}
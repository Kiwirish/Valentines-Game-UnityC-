using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class EndSceneManager : MonoBehaviour
{
    [Header("Main UI Elements")]
    public TextMeshProUGUI valentineText;
    public Button yesButton;
    public Button noButton;

    [Header("Success Modal")]
    public GameObject successModal;
    public TextMeshProUGUI successText;

    private Vector3 originalNoButtonScale;
    private Vector3 originalYesButtonScale;
    private float returnToTitleDelay = 10f;
    private bool isReturningToTitle = false;

    void Start()
    {
        originalNoButtonScale = noButton.transform.localScale;
        originalYesButtonScale = yesButton.transform.localScale;

        successModal.SetActive(false);

        yesButton.onClick.AddListener(OnYesClicked);
        noButton.onClick.AddListener(OnNoClicked);
    }

    void Update()
    {
        if (isReturningToTitle)
        {
            returnToTitleDelay -= Time.deltaTime;
            if (returnToTitleDelay <= 0)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("TitleScene");
            }
        }
    }

    public void OnNoClicked()
    {
        noButton.transform.localScale *= 0.9f;
        yesButton.transform.localScale *= 1.1f;
    }

    public void OnYesClicked()
    {
        successModal.SetActive(true);
        // Play celebration sound
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlayCelebration();
        }
        isReturningToTitle = true;
    }
}
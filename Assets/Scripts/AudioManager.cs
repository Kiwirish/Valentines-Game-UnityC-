using System.Collections;
using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.SceneManagement;

//public class AudioManager : MonoBehaviour
//{
//    [Header("Audio Sources")]
//    public AudioSource musicSource;
//    public AudioSource sfxSource;

//    [Header("Audio Clips")]
//    public AudioClip backgroundMusic;
//    public AudioClip heartCollectSound;
//    public AudioClip jumpSound;

//    private static AudioManager instance;
//    public static AudioManager Instance
//    {
//        get { return instance; }
//    }

//    void Awake()
//    {
//        // Keep this object across all scenes
//        if (instance == null)
//        {
//            instance = this;
//            DontDestroyOnLoad(gameObject);
//            // Start playing music immediately
//            if (backgroundMusic != null && musicSource != null)
//            {
//                musicSource.clip = backgroundMusic;
//                musicSource.loop = true;
//                musicSource.Play();
//            }
//        }
//        else
//        {
//            // If an AudioManager already exists, destroy this one
//            Destroy(gameObject);
//        }
//    }

//    public void PlayHeartCollect()
//    {
//        // Only play SFX in game scene
//        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "GameScene" && heartCollectSound != null)
//        {
//            sfxSource.PlayOneShot(heartCollectSound);
//        }
//    }

//    public void PlayJump()
//    {
//        // Only play SFX in game scene
//        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "GameScene" && jumpSound != null)
//        {
//            sfxSource.PlayOneShot(jumpSound);
//        }
//    }
//}
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Sources")]
    public AudioSource musicSource;
    public AudioSource sfxSource;

    [Header("Audio Clips")]
    public AudioClip backgroundMusic;
    public AudioClip heartCollectSound;
    public AudioClip jumpSound;
    public AudioClip celebrationSound;    // New celebration sound

    private static AudioManager instance;
    public static AudioManager Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            if (backgroundMusic != null && musicSource != null)
            {
                musicSource.clip = backgroundMusic;
                musicSource.loop = true;
                musicSource.Play();
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayHeartCollect()
    {
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "GameScene" && heartCollectSound != null)
        {
            sfxSource.PlayOneShot(heartCollectSound);
        }
    }

    public void PlayJump()
    {
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "GameScene" && jumpSound != null)
        {
            sfxSource.PlayOneShot(jumpSound);
        }
    }

    public void PlayCelebration()
    {
        if (celebrationSound != null)
        {
            sfxSource.PlayOneShot(celebrationSound);
        }
    }
}
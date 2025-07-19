using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{

    [SerializeField]
    float reloadDelay = 2f;

    [SerializeField]
    ParticleSystem finishEffect;

    SurfaceEffector2D terrainEffector;

    AudioSource winSound;
    PlayerController playerController;

    void Start()
    {
        terrainEffector = FindObjectOfType<SurfaceEffector2D>();
        winSound = FindObjectOfType<AudioSource>();
        playerController = FindObjectOfType<PlayerController>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            finishEffect.Play();
            terrainEffector.enabled = false;
            if (!winSound.isPlaying)
            {
                winSound.Play();
            }
            playerController.DisableControls();
            Invoke("ReloadScene", reloadDelay);
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField]
    float crashReloadDelay = 1f;

    [SerializeField]
    ParticleSystem crashEffect;

    SurfaceEffector2D terrainEffector;

    [SerializeField]
    AudioClip crashSoundEffect;

    bool hasCrashed = false;

    void Start()
    {
        terrainEffector = FindObjectOfType<SurfaceEffector2D>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Terrain" && !hasCrashed)
        {
            hasCrashed = true;
            crashEffect.Play();
            terrainEffector.enabled = false;
            GetComponent<PlayerController>().DisableControls();
            GetComponent<AudioSource>().PlayOneShot(crashSoundEffect);
            Invoke("ReloadScene", crashReloadDelay);
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

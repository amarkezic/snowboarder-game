using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    float torqueAmount = 1f;

    [SerializeField]
    float boostAmount = 20f;

    [SerializeField]
    float baseSpeed = 15f;

    Rigidbody2D rb2d;

    SurfaceEffector2D terrainEffector;

    bool controlsEnabled = true;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        terrainEffector = FindObjectOfType<SurfaceEffector2D>();
    }

    void UpdateRotation()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb2d.AddTorque(torqueAmount * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb2d.AddTorque(-torqueAmount * Time.deltaTime);
        }
    }

    void UpdateSpeed()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            terrainEffector.speed = boostAmount;
        }
        else
        {
            terrainEffector.speed = baseSpeed;
        }
    }

    public void DisableControls()
    {
        controlsEnabled = false;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (controlsEnabled)
        {
            UpdateRotation();
            UpdateSpeed();
        }
    }
}

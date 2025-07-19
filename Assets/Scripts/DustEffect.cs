using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustEffect : MonoBehaviour
{

    [SerializeField]
    ParticleSystem snowEffect;

    void Update()
    {
        var main = snowEffect.main;
        if (Input.GetKey(KeyCode.UpArrow))
        {
            main.startSpeed = 10f;
        }
        else
        {
            main.startSpeed = 5f;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.otherCollider is CapsuleCollider2D)
        {
            snowEffect.Play();
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        snowEffect.Stop();
    }
}

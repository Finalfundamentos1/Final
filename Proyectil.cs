using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{
  [SerializeField] float duracion = 20;

  int bounces = 0;
  float tiempo = 0;
  AudioSource explosion;
  ParticleSystem ps;

  void Start()
  {
    explosion = GetComponent<AudioSource>();
  }

  void Update()
  {
    if (tiempo > duracion)
    {
        DestroySelf();
    }
    tiempo += Time.deltaTime;
  }

  void DestroySelf()
  {
      //ps.Play();
      Destroy(gameObject, 1f);
  }

  void OnCollisionEnter(Collision collision)
  {
    if (collision.gameObject.CompareTag("Jugador"))
    {
        DestroySelf();
    }
    bounces++;
    if (bounces >= 1)
    {
        DestroySelf();
    }
  }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Avion : MonoBehaviour
{
  [SerializeField] Slider barradeVida;
  [SerializeField] Text Ganador;
  [SerializeField]AudioSource explosionAudio, impactoBalaAudio;
  float vida;
  
  void Start()
  {
    explosionAudio = GetComponent<AudioSource>();
    impactoBalaAudio = GetComponent<AudioSource>();
    vida = 100;
  }

  void Update()
  {
    barradeVida.value = vida;
  }
  
  void OnCollisionEnter(Collision informacion)
  {
    if (informacion.gameObject.CompareTag("Bala"))
    {
      vida -= 1;
      barradeVida.value = vida;
      impactoBalaAudio.Play();
      if (!impactoBalaAudio.isPlaying) impactoBalaAudio.Play();
      if (vida <= 0)
      {
        explosionAudio.Play();
        Destroy(gameObject);
        Ganador.text = "Eres el perdedor".ToString();

      }
    }
        if (informacion.gameObject.CompareTag("RecuperarVida"))
        {
            vida += 10;
            barradeVida.value = vida;
        }
  }
}

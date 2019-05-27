using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecuperarVidaOBalas : MonoBehaviour
{
    [SerializeField] int cantVidaRecuperar, cantBalasRecargar, cantMisilesRecargar;

    ControlAudio controlAudio;

  void Start ()
  {
    controlAudio = GameObject.Find("ControlAudio").GetComponent<ControlAudio>();
  }

  bool VidaOBalas ()
  {
    return (Random.value > 0.5f);
  }

  void DarVida (GameObject player)
  {
    player.GetComponent<Avion>().vidaSlider.value += cantVidaRecuperar;
    player.GetComponent<Avion>().contador += 1;
  }

  void DarMunicion (GameObject player)
  {
    player.GetComponent<Disparar>().currentBalas += cantBalasRecargar;
    player.GetComponent<Disparar>().currentMisiles += cantMisilesRecargar;
    }

  private void OnCollisionEnter(Collision collision)
  {
    if (collision.gameObject.CompareTag("Player"))
    {
      if (VidaOBalas()) DarVida(collision.gameObject);
      else DarMunicion(collision.gameObject);

      DarVida(collision.gameObject);
      DestroySelf();
    }
  }

  void DestroySelf()
  {
    controlAudio.SonidoRecoger();
    Destroy(gameObject);
  }

}

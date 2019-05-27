using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Avion : MonoBehaviour
{
  [SerializeField] int vidaInicial;
  [SerializeField] AudioClip avionExplosion;
    public int contador;
  public Slider vidaSlider;

  ControlAudio controlAudio;
  ControlTexto controlTexto;
    Motor motor;
  Disparar disparar;
  Misil misil;


  void Start()
  {
    motor = GetComponent<Motor>();
    disparar = GetComponent<Disparar>();
    controlTexto = GameObject.Find("ControlTexto").GetComponent<ControlTexto>();
    controlAudio = GameObject.Find("ControlAudio").GetComponent<ControlAudio>();
    vidaSlider.value = vidaInicial;
        contador = 0;
  }

  void Update()
  {
    motor.Girar();
    motor.Acelerar();
    motor.Sonido();
    disparar.Disparo();

    controlTexto.CambiarTextoMunicion(gameObject, disparar.currentBalas);
    controlTexto.CambiarTextoMisiles(gameObject, disparar.currentMisiles);
        Ganador();
        Debug.Log(contador);
  }

  public void Dañar (int daño)
  {
  	vidaSlider.value -= daño;
    if (vidaSlider.value <= 0) 
    {
      controlAudio.SonidoAvionExplosion(avionExplosion);
      controlTexto.JugadorGanador(gameObject);  
      Destruir();
    }
  }
  
  void Destruir ()
  {
  	Destroy(gameObject);
  }
   void Ganador()
    {
        if (contador >= 4)
        {
            controlTexto.JugadorGanadorAros(gameObject);
        }
    }
}

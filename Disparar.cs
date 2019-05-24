using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Disparar : MonoBehaviour
{

  [SerializeField] GameObject bala, misil;
  [SerializeField] GameObject referente;
    [SerializeField] int ammo = 1000, magFuerza, currentAmmoBalas, misiles = 20, contador=0;
  [SerializeField] string fuego;
  AudioSource disparoAudio;
   [SerializeField] Text textobalas,textomisiles;

  void Start()
  {
    disparoAudio = GetComponent<AudioSource>();
    currentAmmoBalas = ammo;
  }

  void Update()
  {
    Fire();
    Debug.Log(currentAmmoBalas);
        textobalas.text = "Municion: " +currentAmmoBalas.ToString();
        textomisiles.text = "Misiles: " + misiles.ToString();
    }

  void Fire()
  {
    if (Input.GetAxis(fuego) != 0 && currentAmmoBalas > 0)
    {
      contador++;      
      Vector3 posicion = referente.transform.position;
      Quaternion rotacion = referente.transform.rotation;
      GameObject clon = Instantiate(bala, posicion, rotacion);
      Rigidbody lanzamiento = clon.GetComponent<Rigidbody>();

      Vector3 fuerza = magFuerza * 1 * -transform.forward;
      lanzamiento.AddForce(fuerza);

      currentAmmoBalas--;
      disparoAudio.volume = 100f;
      
      if (!disparoAudio.isPlaying) disparoAudio.Play();
            if (contador >= 50)
            {
                GameObject clonMisil = Instantiate(misil, posicion, rotacion);
                contador = 0;
                misiles--;
            }
    }
  }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("RecargaMisil"))
        {
            misiles += 5;
        }
    }
}

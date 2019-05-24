using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motor : MonoBehaviour
{
	[SerializeField] float magSpeed, magForce, magRotX, magRotZ;
  [SerializeField] string Vertical, Horizontal, Aceleracion;

	Rigidbody rb;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

  void Update()
  {
  	//rotX rotar adelante y para atrás
  	//rotZ rotar cara iz cara der
  	Vector3 rotX = Vector3.right;
  	Vector3 rotZ = Vector3.forward;

  	float senRotX = -Input.GetAxis(Vertical);
  	float senRotZ = Input.GetAxis(Horizontal);

  	Vector3 velRotX = senRotX * rotX * magRotX;
  	Vector3 velRotZ = senRotZ * rotZ * magRotZ;

  	Vector3 disRotX = velRotX * Time.deltaTime;
  	Vector3 disRotZ = velRotZ * Time.deltaTime;

  	Vector3 disRot = disRotX + disRotZ;

  	transform.eulerAngles += disRot;

  	//Añadir fuerza para el movimiento

  	//Debug.Log(transform.position.y);
  }
  public void OnCollisionEnter(Collision collision)
  {
    if (Input.GetAxis(Aceleracion) != 0)
    {
      float magnitudmov = 5;
      Vector3 dirz = transform.forward;
      float senz = Input.GetAxis(Aceleracion);
      Vector3 velz = magnitudmov * dirz * senz;

      Vector3 distancia = (velz) * Time.deltaTime;
      transform.position += distancia;

    }
  }
  void OnCollisionExit(Collision suelo)
  {
  	if (suelo.gameObject.tag == "Suelo")
  	{
	    if (Input.GetAxis(Aceleracion) != 0)
	    {
	      float sentMov = Input.GetAxis(Aceleracion);

	      Vector3 magMov = sentMov * (-transform.forward) * magSpeed;

	      Vector3 velMov = magMov * Time.deltaTime;

	      rb.AddForce(velMov * magForce);
	      
	      if (sentMov < 0)
	      {
          magSpeed = 0;
	      }
	      else
	      {
          magSpeed = 20;
	      }
	    }
 	  }
  }
}

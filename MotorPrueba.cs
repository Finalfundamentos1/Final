using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class MotorPrueba : MonoBehaviour {
  
  [SerializeField] float AmbientSpeed = 100f, RotationSpeed = 100f;
  [SerializeField] string vertical, horizontal, ladear;

  private Rigidbody rb;

  void Start () 
  {
    rb = GetComponent<Rigidbody>();

  }
  void FixedUpdate()
  {
    Quaternion AddRot = Quaternion.identity;

    // rotX
    float vtRot = Input.GetAxis(vertical) * (Time.deltaTime * RotationSpeed);
    // rotY
    float hzRot = Input.GetAxis(horizontal) * (Time.deltaTime * RotationSpeed);
    // rotZ
    float ldRot = Input.GetAxis(ladear) * (Time.deltaTime * RotationSpeed);

    AddRot.eulerAngles = new Vector3(vtRot, ldRot, hzRot);

    rb.rotation *= AddRot;
    Vector3 AddPos = Vector3.forward;
    AddPos = rb.rotation * AddPos;
    rb.velocity = AddPos * (Time.fixedDeltaTime * AmbientSpeed);
  }
}
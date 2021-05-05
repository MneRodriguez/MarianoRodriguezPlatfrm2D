using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ControlJgdr : MonoBehaviour
{
    public float VelMax = 1.4f;
    public float gravedad = 15f;
    public float AlturaSalto = 9f;
    public float direccionMovto = 0;
        
    public Rigidbody rb;
    public CapsuleCollider mainCollider;

    public bool TocandoPiso = false;

    

    public Light Luz1, Luz1b, Luz2;
    void Start()
    {
        
        
        rb = GetComponent<Rigidbody>();
        mainCollider = GetComponent<CapsuleCollider>();

        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;        
        rb.constraints = RigidbodyConstraints.FreezePositionZ;
        
        rb.constraints = RigidbodyConstraints.FreezeRotationX;  // CON ESTOS 3 QUISE PREVENIR QUE LA CAPSULA NO SE INCLINE (LO QUE ATRAE A LA CAM)
        rb.constraints = RigidbodyConstraints.FreezeRotationY;
        rb.constraints = RigidbodyConstraints.FreezeRotationZ;

        GameObject LuzPrender1 = GameObject.FindWithTag("LuzAencender1");
        GameObject LuzPrender1b = GameObject.FindWithTag("LuzAencender1b");
        GameObject LuzPrender2= GameObject.FindWithTag("LuzAencender2");

        Luz1 = LuzPrender1.GetComponent<Light>();
        Luz1b = LuzPrender1b.GetComponent<Light>();
        Luz2 = LuzPrender2.GetComponent<Light>();

        Luz1.enabled = false;
        Luz1b.enabled = false;
        Luz2.enabled = false;

    }
    void Update()
    {
        MoverJgdr();
        SaltarJgdr();              
                
    }

    public void MoverJgdr()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float movto = x * VelMax;
        rb.velocity = new Vector2(movto, rb.velocity.y);  // VER SI DEBO CAMBIARLO A Vector3
    }

    public void SaltarJgdr()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            rb.velocity = new Vector2(rb.velocity.x, AlturaSalto);
        }
    }
    void FixedUpdate()
    {
        rb.AddForce(new Vector3(0, -gravedad * rb.mass, 0));

        TocandoPiso = false;
    }

    void OnCollisionStay()
    {
        TocandoPiso = true;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("SwitchLuz1"))
        {
            Luz1.enabled = true;
            Luz1b.enabled = true;
        }
        else if (other.gameObject.CompareTag("SwitchLuz2"))
        {
            Luz2.enabled = true;
        }

        if (other.gameObject.CompareTag("Obstaculo"))
        {
            Time.timeScale = 0.0f;
        }

        if (other.gameObject.CompareTag("ZonaGanar"))
        {
            Time.timeScale = 0.0f;
        }


    }

}

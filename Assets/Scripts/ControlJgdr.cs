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
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mainCollider = GetComponent<CapsuleCollider>();

        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;        
        rb.constraints = RigidbodyConstraints.FreezePositionZ;
        
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

        }

        if (other.gameObject.CompareTag("Obstaculo"))
        {
            Time.timeScale = 0.0f;
        }
    }

}

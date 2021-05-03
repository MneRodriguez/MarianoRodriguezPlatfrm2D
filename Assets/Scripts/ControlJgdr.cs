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
        //rb.useGravity = gravedad;
        rb.constraints = RigidbodyConstraints.FreezePositionZ;
        
    }
    void Update()
    {
        MoverJgdr();
        SaltarJgdr();
        
        /*if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) && (TocandoPiso || Mathf.Abs(rb.velocity.x) > 0.01f))
        {
            direccionMovto = Input.GetKey(KeyCode.A) ? -1 : 1;
        }

        else
        {
            if (TocandoPiso || rb.velocity.magnitude < 0.01f)
            {
                direccionMovto = 0;
            }
        }
        
        if (Input.GetKeyDown(KeyCode.W) && TocandoPiso)
        {
            rb.velocity = new Vector3(rb.velocity.x, CalcularVelSaltoVert());
        }*/
                
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
    float CalcularVelSaltoVert()
    {
        return Mathf.Sqrt(2 * AlturaSalto * gravedad);
    }

}

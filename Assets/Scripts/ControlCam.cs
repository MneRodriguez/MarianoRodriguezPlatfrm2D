using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCam : MonoBehaviour
{
    public GameObject Jugador;
    public Vector3 offset;
    public float MoverSuave = 0.3f;

    void Start()
    {
        offset = transform.position + Jugador.transform.position;
    }

    void Update()
    {
        Vector3 PosDeCam = Jugador.transform.TransformPoint(new Vector3(-0.82f, -0.35f, -5.3f));
        transform.position = Vector3.SmoothDamp(transform.position, PosDeCam, ref offset, MoverSuave);
        //transform.position.z = fre
    }
        
}

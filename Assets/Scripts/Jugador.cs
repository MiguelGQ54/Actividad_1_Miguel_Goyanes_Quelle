using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    [SerializeField] float velocidadGiro;
    [SerializeField] float velocidadMovimiento;
    private new Rigidbody rigidbody;
    public new Transform camara;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        Camara();
        Movimiento();
    }

    void Movimiento()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 velocidad = Vector3.zero;

        if (horizontal !=0 || vertical !=0)
        {
            Vector3 direccion = (transform.forward * vertical + transform.right * horizontal).normalized;
            velocidad = direccion * velocidadMovimiento;

            velocidad.y = rigidbody.velocity.y;
            rigidbody.velocity = velocidad;
        }
    }

    void Camara()
    {
        float horizontal = Input.GetAxis("Mouse X");
        float vertical = Input.GetAxis("Mouse Y");

        if (horizontal !=0){
            transform.Rotate(0, horizontal * velocidadGiro, 0);
        }
        if (vertical != 0)
        {
            camara.Rotate(-vertical * velocidadGiro, 0, 0);
        }
    }
}

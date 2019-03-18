using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// este componente se encarga de asignarle camara,rigidbody (Se desactiva la gravedad y se activan todos los constrains), velocidad al azar e inicia una corrutina para los controladores del heroe al objeto que lo tenga
/// </summary>
public class Heroe : MonoBehaviour
{
    private IEnumerator movCo;

    public void Start()
    {
        AsignarVelocidad AsignarVelocidad = new AsignarVelocidad();
        gameObject.AddComponent<Camera>();
        gameObject.AddComponent<AldeanoCollision>();
        Rigidbody playerRigid = gameObject.AddComponent<Rigidbody>();
        playerRigid.useGravity = false;
        playerRigid.constraints = RigidbodyConstraints.FreezeAll;
        movCo = Acciones(AsignarVelocidad.vel);
        tag = "Player";
        StartCoroutine(movCo);
    }

    /// <summary>
    /// Esta corrutina se encarga de asignar las clases movimiento y rotacion, aparte de ejecutarlas cada frame
    /// </summary>
    /// <returns></returns>
    public IEnumerator Acciones(float vel)
    {

        Movimiento movimiento = new Movimiento();
        Rotacion rotacion = new Rotacion();

        while (true)
        {
            movimiento.Mover(this.gameObject, vel);
            rotacion.Girar(this.gameObject, vel);

            yield return new WaitForEndOfFrame();
        }
    }
}
/// <summary>
/// Aigna una velocidad random al Heroe
/// </summary>
class AsignarVelocidad
{
    public readonly float vel = Random.Range(0.2f,0.5f);
}

/// <summary>
/// Permite que el objeto que lo tenga se mueva adelante y atras con W y S
/// </summary>
public class Movimiento
{
    public void Mover(GameObject x, float vel)
    {
        if (Input.GetKey(KeyCode.W))
        {
            x.transform.Translate(0, 0, vel / 4);
        }
        if (Input.GetKey(KeyCode.S))
        {
            x.transform.Translate(0, 0, -vel / 4);
        }
    }
}

/// <summary>
/// Permite que el objeto que lo tenga que gire a su mirada a los lados con A y D
/// </summary>
public class Rotacion
{
    public void Girar(GameObject z, float vel)
    {
        if (Input.GetKey(KeyCode.A))
        {
            z.transform.Rotate(0, -vel * 4, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            z.transform.Rotate(0, vel * 4, 0);
        }
    }
}


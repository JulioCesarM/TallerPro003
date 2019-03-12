using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Esta clase maneja el estado del objeto entre Idle y Mov recalculando estado cada 5 Segundos
/// </summary>
public class ZombieStatus : MonoBehaviour
{
    float timer;

    enum Estado
    {
        Idle, Movi
    }

    private void Start()
    {
        IEnumerator mov = CambiarEstado();
        StartCoroutine(mov);
    }

    IEnumerator CambiarEstado()
    {
        while (true)
        {
            Estado estado;
            estado = (Estado)Random.Range(0, 2);

            switch (estado)
            {
                case Estado.Idle:
                    yield return new WaitForSeconds(5);
                    break;
                case Estado.Movi:
                    int girar = Random.Range(0, 360);
                    transform.Rotate(0, girar, 0);
                    while (timer < 5)
                    {
                        transform.Translate(0, 0, 0.025f);
                        timer += Time.deltaTime;
                        yield return new WaitForEndOfFrame();
                    }
                    break;
            }
            if (timer > 5)
            {
                timer = 0;
            }
        }
    }
}
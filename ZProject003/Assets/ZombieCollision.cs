using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Esta clase se encarga de detectar la collision con el jugador y mandar el mensaje que se requiere
/// </summary>
public class ZombieCollision : MonoBehaviour
{
    ZombieData zombieDat = new ZombieData();

    public void TakeData(ZombieData zombieData)
    {
        zombieDat = zombieData;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
            print("Waaaarrrr quier comer " + zombieDat.Gusto);
    }
}

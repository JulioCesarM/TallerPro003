using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Esta clase se encarga de guardar los datos del objeto y de enviarlos en un mensaje cuando detecta al heroe
/// </summary>
public class AldeanoCollision : MonoBehaviour
{
    VillagerData villagerDat = new VillagerData();

    /// <summary>
    /// Almacena un struct recivido para enviarlo luego en collision
    /// </summary>
    /// <param name="villagerData">
    /// Informacion del objeto en un struct
    /// </param>
    public void TakeData(VillagerData villagerData)
    {
        villagerDat = villagerData;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
            print("Hola soy " + villagerDat.name + " y téngo " + villagerDat.Age + " años");
    }
}
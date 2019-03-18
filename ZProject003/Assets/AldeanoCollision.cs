using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ally = NPC.Ally;
using Enemy = NPC.Enemy;

/// <summary>
/// Esta clase se encarga de guardar los datos del objeto y de enviarlos en un mensaje cuando detecta al heroe
/// </summary>
public class AldeanoCollision : MonoBehaviour
{ 
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Zombie")
        {
        ZombieData zombieData = collision.gameObject.GetComponent<Enemy.GenerarZombie>().zombieData;
            Debug.Log("Waaaaaarrr quiero comer" + zombieData.Gusto);
        }
        if (collision.gameObject.tag == "Aldeano")
        {
            VillagerData villagerData = collision.gameObject.GetComponent<Ally.GenerarAldeano>().villagerData;
            Debug.Log("Hola mi nombre es " + villagerData.name + " y tengo " + villagerData.Age + " años");
        }
    }
}
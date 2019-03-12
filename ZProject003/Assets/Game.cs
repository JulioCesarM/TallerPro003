using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {

    void Start ()
    {
        GameObject heroe = GameObject.CreatePrimitive(PrimitiveType.Cube);
        heroe.AddComponent<Heroe>();

        for (int i = 0; i < Random.Range(10,21); i++)
        {
            int valorGeneracion = Random.Range(0, 2);
            if (valorGeneracion == 0)
            {
                GameObject aldeano = GameObject.CreatePrimitive(PrimitiveType.Cube);
                aldeano.name = "Aldeano";
                aldeano.AddComponent<GenerarAldeano>();
            }
            else
            {
                GameObject zombie = GameObject.CreatePrimitive(PrimitiveType.Cube);
                zombie.name = "Zombie";
                zombie.AddComponent<GenerarZombie>();
            }
        }
	}
}
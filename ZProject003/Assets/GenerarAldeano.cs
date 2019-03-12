using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Esta clase se encarga de darle un nombre y edad al objeto almacenando esta informacion en un struct, luego le agrega un componente AldeanoCollision y le envia el struct creado
/// </summary>
public class GenerarAldeano : MonoBehaviour
{

    VillagerData villagerData = new VillagerData();

    int edad;
    string nombre;

    enum Nombres
    {
        Alejandro, Daniel, Julio, Danilo, Kevin, Brayan, Juan, Sebastian, Luis, Alex, Jorge, Anderson, Cristian, Camilo, Carlos, Felipe, Andres, Gustavo, Cesar, andres, lenght
    }

    public void Start()
    {
        GameObject aldeano = this.gameObject;
        Nombres nombres;

        aldeano.transform.position = new Vector3(Random.Range(-20, 21), 0, Random.Range(-20, 21));

        edad = Random.Range(15, 101);
        int numeroNombre = Random.Range(0, 20);
        nombres = (Nombres)numeroNombre;
        nombre = nombres.ToString();

        villagerData.Age = edad;
        villagerData.name = nombre;

        aldeano.AddComponent<AldeanoCollision>().TakeData(villagerData);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ally = NPC.Ally;
using Enemy = NPC.Enemy;
using UnityEngine.UI;

public class Game : MonoBehaviour {

    public Text NumAld;
    public Text NumZomb;

    void Start()
    {
        new Asignar();
        StartCoroutine(Textos());
    }


    /// <summary>
    /// Contar los aldeanos y zombies 1 segundo despues de iniciar el programa
    /// </summary>
    /// <returns></returns>
    
    IEnumerator Textos()
    {
        yield return new WaitForSeconds(1);
        GameObject[] Zombies = GameObject.FindGameObjectsWithTag("Zombie");
        GameObject[] Aldeano = GameObject.FindGameObjectsWithTag("Aldeano");
        int NumZombies = 0;
        int NumAldeanos = 0;

        foreach (GameObject x in Zombies)
        {
            NumZombies++;
            yield return new WaitForSeconds(0.1f);
            NumZomb.text = NumZombies.ToString();

        }

        foreach (GameObject x in Aldeano)
        {
            NumAldeanos++;
            yield return new WaitForSeconds(0.1f);
            NumAld.text = NumAldeanos.ToString();

        }

        yield return null;      
    }

}


/// <summary>
/// Se encarga de Asignar el componente Aldeano, Zombie y Heroe
/// </summary>
class Asignar
{
    public readonly int Valor = Random.Range(5, 16);
    const int GENERACIONMAXIMA = 26;

        public Asignar()
        {
            GameObject heroe = GameObject.CreatePrimitive(PrimitiveType.Cube);
            heroe.AddComponent<Heroe>();

            for (int i = 0; i < Random.Range(Valor,GENERACIONMAXIMA); i++)
            {
                int valorGeneracion = Random.Range(0, 2);
                if (valorGeneracion == 0)
                {
                    GameObject aldeano = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    aldeano.name = "Aldeano";
                    aldeano.AddComponent<Ally.GenerarAldeano>();
                }
                else
                {
                    GameObject zombie = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    zombie.name = "Zombie";
                    zombie.AddComponent<Enemy.GenerarZombie>();
                }
            }
        }
    }
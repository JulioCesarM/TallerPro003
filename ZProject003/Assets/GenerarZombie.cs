using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Esta clase al iniciar agrega un gusto y color al objeto, aparte de guarlar la informacion en un struct para cada objeto y asignar los componentes zombieStatus y ZombieCollision
/// </summary>
public class GenerarZombie : MonoBehaviour
{
    string gusto;

    enum Gusto
    {
        Piernas, Dedos, Cerebro, Ojos, Lengua, lenght
    }

    public void Start()
    {
        GameObject zombie = this.gameObject;
        ZombieData zombieData = new ZombieData();
        zombie.transform.position = new Vector3(Random.Range(-20, 21), 0, Random.Range(-20, 21));

        Renderer zRender = zombie.GetComponent<Renderer>();
        int numeroColor = Random.Range(0, 3);
        if (numeroColor == 0)
            zRender.material.color = Color.cyan;
        else if (numeroColor == 1)
            zRender.material.color = Color.green;
        else
            zRender.material.color = Color.magenta;

        Gusto enumGusto;
        enumGusto = (Gusto)Random.Range(0, (int)Gusto.lenght);
        gusto = enumGusto.ToString();
        zombieData.Gusto = gusto;

        zombie.AddComponent<ZombieCollision>().TakeData(zombieData);
        zombie.AddComponent<ZombieStatus>();
    }
}
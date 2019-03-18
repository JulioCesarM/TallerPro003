using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NPC
{
    namespace Enemy
    {

        /// <summary>
        /// Esta clase maneja el estado del objeto entre Idle y Mov recalculando estado cada 5 Segundos
        /// </summary>
        public class ZombieStatus : MonoBehaviour
        {
            float timer;

            enum Estado
            {
                Idle, Moving, Rotating
            }

            private void Start()
            {
                IEnumerator mov = CambiarEstado();
                StartCoroutine(mov);
            }


            /// <summary>
            /// Se encarga de cambiar el estado del zombie cada 3 se4gundos
            /// </summary>
            /// <returns></returns>
            IEnumerator CambiarEstado()
            {
                while (true)
                {
                    Estado estado;
                    estado = (Estado)Random.Range(0, 3);

                    switch (estado)
                    {
                        case Estado.Idle:
                            yield return new WaitForSeconds(3);
                            break;
                        case Estado.Moving:
                            while (timer < 3)
                            {
                                transform.Translate(0, 0, 0.025f);
                                timer += Time.deltaTime;
                                yield return new WaitForEndOfFrame();
                            }
                            break;
                        case Estado.Rotating:
                            int girar = Random.Range(1, 20);
                            while (timer < 3)
                            {
                                transform.Rotate(0, girar, 0);
                                timer += Time.deltaTime;
                                yield return new WaitForEndOfFrame();
                            }
                            break;
                    }
                    if (timer > 3)
                    {
                        timer = 0;
                    }
                }
            }
        }

        /// <summary>
        /// Esta clase al iniciar agrega un gusto y color al objeto, aparte de guarlar la informacion en un struct para cada objeto y asignar los componentes zombieStatus y ZombieCollision
        /// </summary>
        public class GenerarZombie : MonoBehaviour
        {
            string gusto;
            public ZombieData zombieData = new ZombieData();
            enum Gusto
            {
                Piernas, Dedos, Cerebro, Ojos, Lengua, lenght
            }

            public void Start()
            {
                GameObject zombie = this.gameObject;
                zombie.tag = "Zombie";
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
                zombie.AddComponent<ZombieStatus>();
            }
        }

    }

    namespace Ally
    {

        /// <summary>
        /// Esta clase se encarga de darle un nombre y edad al objeto almacenando esta informacion en un struct, luego le agrega un componente AldeanoCollision y le envia el struct creado
        /// </summary>
        public class GenerarAldeano : MonoBehaviour
        {

            public VillagerData villagerData = new VillagerData();

            int edad;
            string nombre;

            enum Nombres
            {
                Alejandro, Daniel, Julio, Danilo, Kevin, Brayan, Juan, Sebastian, Luis, Alex, Jorge, Anderson, Cristian, Camilo, Carlos, Felipe, Andres, Gustavo, Cesar, andres, lenght
            }

            public void Start()
            {
                GameObject aldeano = this.gameObject;
                aldeano.tag = "Aldeano";
                Nombres nombres;

                aldeano.transform.position = new Vector3(Random.Range(-20, 21), 0, Random.Range(-20, 21));

                edad = Random.Range(15, 101);
                int numeroNombre = Random.Range(0, 20);
                nombres = (Nombres)numeroNombre;
                nombre = nombres.ToString();

                villagerData.Age = edad;
                villagerData.name = nombre;
            }
        }

    }
}
using UnityEngine;

public class DestroyBomb : MonoBehaviour
{
    private int contador = 0; // La variable que almacenará el conteo
    public int limiteContador = 6; // El valor máximo al que queremos que llegue el contador
    public float tiempoEntreIncrementos = 1.0f; // Tiempo en segundos entre cada incremento (opcional, si quieres un contador lento)

    private float tiempoAcumulado = 0f; // Variable para acumular el tiempo si usamos tiempoEntreIncrementos

    void Update()
    {
        // Opción 1: Contador que incrementa cada fotograma (muy rápido)
        // contador++;
        // Debug.Log("Contador (cada fotograma): " + contador);

        // Opción 2: Contador que incrementa después de un cierto tiempo (más controlable)
        tiempoAcumulado += Time.deltaTime; // Suma el tiempo transcurrido desde el último fotograma

        if (tiempoAcumulado >= tiempoEntreIncrementos)
        {
            contador++; // Incrementa el contador
            Debug.Log("Contador (cada " + tiempoEntreIncrementos + "s): " + contador);

            tiempoAcumulado = 0f; // Reinicia el tiempo acumulado para el próximo incremento

            // Opcional: Reiniciar el contador cuando alcanza un límite
            if (contador >= limiteContador)
            {
                Debug.Log("Contador ha llegado al límite: " + limiteContador + ". Reiniciando...");
                contador = 0; // Reinicia el contador a 0
                Destroy(gameObject);
            }
        }
    }

    // Método para resetear el contador si lo necesitas desde otro script o evento
    public void ResetearContador()
    {
        contador = 0;
        tiempoAcumulado = 0f;
        Debug.Log("Contador reseteado.");
    }
}

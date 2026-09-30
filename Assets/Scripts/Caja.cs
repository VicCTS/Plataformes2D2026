using System.Collections.Generic;
using UnityEngine;

public class Caja : MonoBehaviour
{
    [SerializeField] private float ancho = 5;
    public float alto = 5;
    public float profundidad = 5;

    public static int asda = 10;

    public int[] arrayNumeros;
    public int[] arrayNumeros2 = {2, 3};

    public List<int> listaNumeros;

    void AbrirCaja()
    {
        profundidad = 12;

        arrayNumeros[0] = 12;
    }

    void CerrarCaja()
    {
        
    }
}

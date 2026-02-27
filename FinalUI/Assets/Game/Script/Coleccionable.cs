using UnityEngine;

[System.Serializable]
public class Coleccionable
{
    public string nombre;
    public Rareza rareza;
    public int valor;
    public string descripcion;
    public string tipo;
    public string iconoId;
}

public enum Rareza
{
    Comun=1,
    PocoComun=2,
    Raro = 3,
    Epico= 4,
    Legendario=5

}

   
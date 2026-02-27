using UnityEngine;
using System.Collections.Generic;


public class MainController : MonoBehaviour
{
    public InventarioUI inventarioUI;

    private List<Coleccionable> coleccionablesList = new List<Coleccionable>();


    void Start()
    {
        GameData data = GameDataLoader.CargarDatos();

        if (data == null || data.coleccionables == null)
            return;
        coleccionablesList.AddRange(data.coleccionables);
        OrdenarPorNombre();
    }

    // PARA BUSQUEDA POR NOMBRE 

    public Coleccionable BuscarColeccionablePorNombre(string nombreBusqueda)
    {
        return coleccionablesList.Find(x =>
           x.nombre.ToLower().Contains(nombreBusqueda.Trim().ToLower()));
    }

    //PARA ORDENAR POR VALOR Y RAREZA

    public void OrdenarPorNombre()
    {
        coleccionablesList.Sort((a, b) => a.nombre.CompareTo(b.nombre));
        ActualizarUI();

    }

    public void OrdenarPorValor()
    {
        coleccionablesList.Sort((a, b) => a.valor.CompareTo(b.valor));
        ActualizarUI();

    }

    public void OrdenarPorRareza()
    {
        coleccionablesList.Sort((a, b) => a.rareza.CompareTo(b.rareza));
        ActualizarUI();

    }

    void ActualizarUI()
    {
        inventarioUI.CargarInventario(coleccionablesList);

    }

    public void BuscarDesdeUI()
    {
        inventarioUI.BuscarPorNombre(this);
    }

}


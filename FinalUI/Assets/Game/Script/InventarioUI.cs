using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;
using Unity.VisualScripting;

public class InventarioUI : MonoBehaviour
{
    public Transform content;
    public GameObject itemPrefab;
    public GameObject panelDetalle;

    public TMP_InputField inputBuscar;
    public TextMeshProUGUI mensajeBusquedaText;

    public Image detalleIcono;
    public TextMeshProUGUI detalleNombre;
    public TextMeshProUGUI detalleRareza;
    public TextMeshProUGUI detalleValor;
    public TextMeshProUGUI detalleTipo;
    public TextMeshProUGUI detalleDescripcion;

    private List<Coleccionable> listaActual = new List<Coleccionable>();

    public void CargarInventario(List <Coleccionable>lista)
    {
        listaActual = lista;
        LimpiarScroll();
        
      
        foreach (var col in lista)
        {
            GameObject item = Instantiate(itemPrefab, content);
            item.GetComponent<ItemColeccionableUI>().Inicializar(col, this); 

        }
        
    }

    public void BuscarPorNombre(MainController controller)
    {
        string texto= inputBuscar.text;

        if (string.IsNullOrWhiteSpace(texto))
        {
            CargarInventario(listaActual);
            mensajeBusquedaText.text = "";
            return;

        }
        Coleccionable resultado =controller.BuscarColeccionablePorNombre(texto);

        if (resultado != null)
        {
            CargarInventario(new List<Coleccionable> { resultado });
            mensajeBusquedaText.text= "";

        }
        else
        {
            LimpiarScroll();
            mensajeBusquedaText.text = "No se encontró ese coleccionable";

        }

    }

    
    void LimpiarScroll()
    {
        foreach (Transform child in content)
        {
            Destroy(child.gameObject);

        }
    }

   
    public void MostrarDetalle(Coleccionable col)
    {
        panelDetalle.SetActive(true);
        
        detalleNombre.text = col.nombre;
        detalleRareza.text = "Rareza:" + col.rareza;
        detalleValor.text ="Valor:" + col.valor;
        detalleTipo.text = "Tipo:" + col.tipo;
        detalleDescripcion.text = col.descripcion;

        Sprite icono = Resources.Load<Sprite>("Icons/" + col.iconoId);

        if (icono != null )
            detalleIcono.sprite = icono;

    }

    public void CerrarDetalle()
    {
        panelDetalle.SetActive(false);

    }

}

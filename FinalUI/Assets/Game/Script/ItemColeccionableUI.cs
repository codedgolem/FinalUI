using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;


public class ItemColeccionableUI : MonoBehaviour
{
    public TextMeshProUGUI nombreText;
    public Image iconImage;

    private Coleccionable data;
    private InventarioUI inventarioUI;

    IEnumerator AnimacionEntrada() //Para la animacion de los elementos instanciados 
    {
        transform.localScale = Vector3.zero;

        float tiempo = 0f;
        float duracion = 0.2f;

        while (tiempo < duracion)
        {
            tiempo += Time.deltaTime;
            float escala = Mathf.Lerp(0f, 1f, tiempo / duracion);
            transform.localScale = new Vector3(escala, escala, 1f);
            yield return null;
        }

        transform.localScale = Vector3.one;
    }


    public void Inicializar(Coleccionable coleccionable, InventarioUI invUI)
    {
        data = coleccionable;
        inventarioUI = invUI;

        nombreText.text = coleccionable.nombre;

        Sprite icono = Resources.Load<Sprite>("Icons/" + coleccionable.iconoId);

        if (icono != null)
            iconImage.sprite = icono;

        Button btn = GetComponent<Button>();
        btn.onClick.RemoveAllListeners();
        btn.onClick.AddListener(OnClick);

        StartCoroutine(AnimacionEntrada());
    }

    void OnClick()
    {
        inventarioUI.MostrarDetalle(data);

    }


}

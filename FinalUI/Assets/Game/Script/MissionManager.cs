using UnityEngine;
using System.Collections.Generic;  
using TMPro;
using UnityEngine.UI;

public class MissionManager : MonoBehaviour
{

    [Header("UI")]
    public TextMeshProUGUI missionTitleText;
    public Button completeButton;
    public Button undoButton;

    private Stack<Mision> missionStack = new Stack<Mision>();
    private Stack<Mision> historyStack = new Stack<Mision>();
    private List<Mision> missionsList = new List<Mision>();

    void Start()
    {
        GameData data = GameDataLoader.CargarDatos();

        if (data == null || data.misiones == null)
        {
            missionTitleText.text = "No se pudieron cargar misiones";
            return;

        }

        missionsList.AddRange(data.misiones);
        IniciarPila();
        ActualizarUI();

    }


    void IniciarPila()
    {
        missionStack.Clear();
        historyStack.Clear();

        for (int i = missionsList.Count - 1; i >= 0; i--)
        {
            missionStack.Push(missionsList[i]);

        }

    }

    void ActualizarUI()
    {
        if (missionStack.Count > 0)
        {
            Mision currentMission = missionStack.Peek();
            missionTitleText.text = currentMission.titulo + "\n\n" + currentMission.descripcion;
            completeButton.interactable = true;

        }

        else
        {
            missionTitleText.text = "No hay misiones disponibles";
            completeButton.interactable = false;

        }
        undoButton.interactable = historyStack.Count > 0;

    }
    public void CompleteMission()
    {
        if (missionStack.Count > 0)
        {
            Mision completed = missionStack.Pop();
            historyStack.Push(completed);
            ActualizarUI();
        }

    }

    public void UndoMission()
    {
        if (historyStack.Count > 0)
        {
            Mision last = historyStack.Pop();
            missionStack.Push(last);
            ActualizarUI();

        }


    }


}


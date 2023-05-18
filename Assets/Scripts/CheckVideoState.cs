using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class CheckVideoState : MonoBehaviour
{
    public GameObject listPanel;


    public void CheckAllVideoStates()
    {
        // �j�M List Panel �U���Ҧ����s
        Button[] buttons = listPanel.GetComponentsInChildren<Button>();

        // �ˬd���s�O�_�w�s�b��C��
        foreach (Button button in buttons)
        {
            ChangeState(button);
        }
    }


    public void ChangeState(Button videoButton)
    {
        string buttonName = videoButton.gameObject.name; // ���o���s���W�r
        if (buttonName != "AddVideo")
        {
            if (!JsonExists(buttonName))
            { 
                videoButton.interactable = false;
            }
            else
            {
                videoButton.interactable = true;
            }
        }
    }

    private bool JsonExists(string buttonName)
    {
        string jsonFileName = buttonName + ".json";
        string jsonPath = Path.Combine(Application.dataPath, "JsonData", jsonFileName);
        return File.Exists(jsonPath);
    }

}

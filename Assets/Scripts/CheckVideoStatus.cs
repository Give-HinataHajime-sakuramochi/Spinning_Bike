using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class CheckVideoStatus : MonoBehaviour
{
    public GameObject listPanel;

    public void CheckAllVideoStatus()
    {
        // �j�M List Panel �U���Ҧ����s
        Button[] buttons = listPanel.GetComponentsInChildren<Button>();

        // �ˬd���s�O�_�w�s�b��C��
        foreach (Button button in buttons)
        {
            ChangeStatus(button);
        }
    }


    public void ChangeStatus(Button videoButton)
    {
        string buttonName = videoButton.gameObject.name; // ���o���s���W�r
        if (buttonName != "AddVideo")
        {
            if (!JsonExists(buttonName))
            { 
                videoButton.interactable = false;
                //��@�U TCP_Client �U���� processPath
                string videoFileName = buttonName + ".mp4";
                string videoPath = Path.Combine(Application.dataPath, "Video", videoFileName);
                tcpClient = GameObject.Find("Server").GetComponent<TCP_Client>();
                tcpClient.processPath = videoPath;
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

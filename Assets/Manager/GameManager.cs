using UnityEditor.U2D.Path;
using UnityEngine;

public class GameManager
{
    static GameManager s_instance;
    public static GameManager Instance { get { Initialize(); return s_instance; } }

    static private GameObject StartUI = null;

    static void Initialize()
    {
        if (s_instance == null)
        {
            s_instance = new GameManager();
            SetStartUI();
        }
    }

    public bool getStartFlag()
    {
        if (StartUI)
            return (false);
        return (true);
    }
    public void flipStartFlag()
    {
        if (StartUI)
        {
            Object.Destroy(GameObject.Find("StartMSG"));
            StartUI = null;
        }
        else
            SetStartUI();
    }

    static void SetStartUI()
    {
        StartUI = Object.Instantiate(Resources.Load<GameObject>("UI/StartMsg"), GameObject.Find("Canvas").transform);
        StartUI.name = "StartMSG";
    }
}

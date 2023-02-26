using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI Player_Score1, Player_Score2;

    static int Score1 = 0, Score2 = 0;

    void Update()
    {
        Player_Score1.SetText(Score1.ToString());
        Player_Score2.SetText(Score2.ToString());
        if (!GameManager.Instance.getStartFlag() && Input.GetKeyDown(KeyCode.R))
            GameManager.Instance.flipStartFlag();
    }

    static public void GetScore1P()
    {
        ++Score1;
    }

    static public void GetScore2P()
    {
        ++Score2;
    }
}

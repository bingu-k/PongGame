using TMPro;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField]
    float velocity = 0.0f;

    private float DirX = 0.0f, DirY = 0.0f;

    void Start()
    {
        velocity = 10.0f;
        initDir();
    }

    private void Update()
    {
        if (GameManager.Instance.getStartFlag())
            transform.Translate(DirX * velocity * Time.deltaTime, DirY * velocity * Time.deltaTime, 0.0f);
    }

    public void initDir()
    {
        DirX = Random.Range(-1.0f, 1.0f);
        while (DirY == 0.0f)
            DirY = Random.Range(-1.0f, 1.0f);

        float del = Mathf.Sqrt(DirX * DirX + DirY * DirY);
        DirX /= del;
        DirY /= del;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Wall")
            DirY *= -1;
        else if (collision.tag == "Player")
        {
            float diff = Mathf.Abs(collision.transform.position.y) - Mathf.Abs(transform.position.y);
            float currentRad = 45 * Mathf.Deg2Rad * Mathf.Abs(diff) + Mathf.Acos(DirX);
            DirX = DirX > 0.0f ? Mathf.Abs(Mathf.Cos(Mathf.Rad2Deg * currentRad)) : -Mathf.Abs(Mathf.Cos(Mathf.Rad2Deg * currentRad));
            DirY = DirY > 0.0f ? Mathf.Abs(Mathf.Sin(Mathf.Rad2Deg * currentRad)) : -Mathf.Abs(Mathf.Sin(Mathf.Rad2Deg * currentRad));
            DirX *= -1;
        }
        else if (collision.tag == "Score")
        {
            if (collision.name == "Wall_left")
                GameController.GetScore2P();
            else
                GameController.GetScore1P();
            transform.position = new Vector3(0.0f, 0.0f, 0.0f);
            GameManager.Instance.flipStartFlag();
            initDir();
        }
    }
}

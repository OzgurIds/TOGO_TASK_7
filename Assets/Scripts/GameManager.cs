using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public bool isStarted;
    int score;
    public PlayerCont playersc;
    public Transform Right, Left, Big;
    public GameObject InputController, Win, Lose, button;
    public TextMeshProUGUI scoreboard;
    void Start()
    {
        score = 0;
        scoreboard.text = "Score: " + score;
        isStarted = false;
    }
    void MergeandDivide()
    {
        if (Vector3.Distance(Left.localPosition, Right.localPosition) <= 0.9f)
        {
            Left.gameObject.SetActive(false);
            Right.gameObject.SetActive(false);
            Big.gameObject.SetActive(true);
        }

        if (Vector3.Distance(Left.localPosition, Right.localPosition) > 0.9f)
        {
            Left.gameObject.SetActive(true);
            Right.gameObject.SetActive(true);
            Big.gameObject.SetActive(false);
        }
    }

    public void StopGame(string endstate)
    {
        isStarted = false;
        InputController.SetActive(false);
        playersc.StopAll();
        playersc.speed = 0;
        button.SetActive(true);
        if (endstate == "Win")
        {
            Win.SetActive(true);
        }
        else
        {
            Lose.SetActive(true);
        }

    }

    void Update()
    {
        MergeandDivide();
    }

    public void Collect()
    {
        score++;
        scoreboard.text = "Score: " + score;
        Big.localScale += new Vector3(0.1f, 0.1f, 0.1f);
    }

    public void Restart()
    {
        SceneManager.LoadScene("Task7");
    }

}
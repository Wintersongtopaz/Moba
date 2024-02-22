using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
//Game manager:Responsible for ending the game when either the red team of blue team base's health is reduced to 0.
public class GameManager : MonoBehaviour, IIntListener
{
    public Unit blueBase;
    public Unit redBase;
    bool gameOver = false;
    public TextMeshProUGUI gameOverText;

    // Start is called before the first frame update
    void Start()
    {
        blueBase.health.listeners.Add(gameObject);
        redBase.health.listeners.Add(gameObject);
    }

    public void IntUpdate(IntWrapper i)
    {
        if (i == blueBase.health) BlueBaseUpdate();
        else if (i == redBase.health) RedBaseUpdate();
    }

    void BlueBaseUpdate()
    {
        if (blueBase.health.Value > 0 || gameOver) return;
        gameOverText.text = "Red Team Wins";
        StartCoroutine(GameOver());
    }

    void RedBaseUpdate()
    {
        if (redBase.health.Value > 0 || gameOver) return;
        gameOverText.text = "Blue Team Wins";
        StartCoroutine(GameOver());
    }

    IEnumerator GameOver()
    {
        gameOver = true;
        while(Time.timeScale > 0)
        {
            float alpha = gameOverText.color.a;
            alpha += Time.deltaTime;
            Color newColor = gameOverText.color;
            newColor.a = alpha;
            gameOverText.color = newColor;

            Time.timeScale -= Time.deltaTime;
            if (Time.timeScale < 0) Time.timeScale = 0f;
            yield return null;
        }
    }
}

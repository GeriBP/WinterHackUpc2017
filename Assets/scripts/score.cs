using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class score : MonoBehaviour {

    public TextMesh scoreText;
    public Text textS;
    private int s = 0;

    public void Start()
    {
        scoreText.text = "0000";
    }
    public void modifyScore(int score)
    {
        s += score;
        int t = s;
        if (t < 10)
        {
            scoreText.text = "000" + t.ToString();
        } else if (t < 100)
        {
            scoreText.text = "00" + t.ToString();
        }
        else if (t < 1000)
        {
            scoreText.text = "0" + t.ToString();
        } else
        {
            scoreText.text = t.ToString();
        }
    }
    public void tooMany()
    {
        StartCoroutine(loadMenu());
    }

    IEnumerator loadMenu()
    {
        textS.text = "Score: " + s.ToString();
        yield return new WaitForSeconds(8.0f);
        SceneManager.LoadScene("menu");
        yield return null;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class score : MonoBehaviour {

    public TextMesh scoreText;
    private int s = 0;

    public void Start()
    {
        scoreText.text = "0000";
    }
    public void modifyScore(int score)
    {
        int t = s + score;
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
}

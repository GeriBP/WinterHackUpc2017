using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class tutorialManager : MonoBehaviour {
    public Sprite[] s;
    public Image image;
    public float t;
    // Use this for initialization
    void Start () {
        StartCoroutine(slides());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator slides()
    {
        for (int i = 0; i < s.Length; i++)
        {
            image.sprite = s[i];
            yield return new WaitForSeconds(t);
        }
        SceneManager.LoadScene("main");
        yield return null;
    }
}

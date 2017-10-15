using UnityEngine.Audio;
using UnityEngine;


[System.Serializable]
public class Sound {

	public string name;

	public AudioClip clip;
	[Range(0f, 1f)]
	public float volume = 0.5f;
	[Range(-3f, 3f)]
	public float pitch;

	public bool loop;

	[HideInInspector]
	public AudioSource src;

	// Use this for initialization
	void Start () {
		pitch = Random.Range (-3.0f, 3.0f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

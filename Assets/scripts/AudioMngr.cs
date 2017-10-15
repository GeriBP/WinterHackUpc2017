using UnityEngine.Audio;
using UnityEngine;

public class AudioMngr : MonoBehaviour {

	public Sound[] sounds;

	public static AudioMngr instance;

	// Use this for initialization
	void Awake () {
		if (instance == null){
			instance = this;
		} else {
			Destroy (gameObject);
		}
		DontDestroyOnLoad (gameObject);

		foreach (Sound s in sounds) {
			s.src = gameObject.AddComponent<AudioSource>();
			s.src.clip = s.clip;

			s.src.volume = s.volume;
			s.src.pitch = s.pitch;
			s.src.loop = s.loop;
		}
	}

	void Start() {
		Play("Gamemusic");
	}

	public void PlaySound(int i) {
		//if (0 <= i && i < sounds.GetLength) {
			sounds [i].src.Play ();
		//}
	}

	// Update is called once per frame
	public void Play(string name) {
		for (int i = 0; i <= sounds.Length; ++i) {
			if (sounds [i].name.Equals(name)) {
				sounds[i].src.Play();
				break;
			}
		}
	}
}

/* USAGE
	FindObjectOfType<AudioMngr>().Play(sound.name);
*/
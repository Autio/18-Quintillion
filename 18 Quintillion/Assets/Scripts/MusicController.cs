using UnityEngine;
using System.Collections;

public class MusicController : MonoBehaviour {

    public AudioSource[] musicBlocks;
    public AudioSource musicPlayer;
    public AudioClip[] musicBlockClips;
    private bool playingMusic = true;
    // Use this for initialization
	void Start () {
        StartCoroutine(playNextSound());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator playNextSound()
    {
        while (playingMusic)
        {
            musicPlayer.GetComponent<AudioSource>().clip = musicBlockClips[Random.Range(0, musicBlockClips.Length)];
            musicPlayer.GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(musicPlayer.GetComponent<AudioSource>().clip.length);
        }
    }
}

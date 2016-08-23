using UnityEngine;
using System.Collections;

public class MusicController : MonoBehaviour {

    public AudioSource[] musicBlocks;
    public AudioSource musicPlayer;
    public AudioClip[] musicBlockClips;
    private bool playingMusic = true;
    private int musicLevel = 1;

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
            int maxClips = this.gameObject.GetComponent<GameController>().costLevel * 2;
            if (maxClips > musicBlockClips.Length)
            {
                maxClips = musicBlockClips.Length;
            }
            musicPlayer.GetComponent<AudioSource>().clip = musicBlockClips[Random.Range(0, maxClips)];
            musicPlayer.GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(musicPlayer.GetComponent<AudioSource>().clip.length);
        }
    }
}

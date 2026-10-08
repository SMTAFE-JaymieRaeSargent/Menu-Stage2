using UnityEngine;

public class AudioAsset : MonoBehaviour
{
    public static AudioAsset instance;

    //Singleton

    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioClip music;
    [SerializeField] AudioSource sfxSource;

    private void Start()
    {
        PlayMusic(music);
    }
    public void PlayMusic(AudioClip clip)
    {
        if (musicSource != null && clip != null)
        {
            musicSource.clip = clip;
            musicSource.loop = true;
            musicSource.Play();
        }
    }
    public void PlaySFX(AudioClip clip)
    {
        if (sfxSource != null && clip != null)
        {
            sfxSource.PlayOneShot(clip);
        }
    }
}

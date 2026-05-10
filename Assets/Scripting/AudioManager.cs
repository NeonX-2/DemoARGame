using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("--------- Audio Source ---------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("--------- Audio Clip ---------")]
    public AudioClip background;
    public AudioClip playerSlash;
    public AudioClip redGrowl;
    
    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }

    public void PlayPlayerSlash()
    {
        if (playerSlash != null && SFXSource != null)
        {
            SFXSource.PlayOneShot(playerSlash);
        }
    }

    public void PlayRedGrowl()
    {
        if (redGrowl != null && SFXSource != null)
        {
            SFXSource.PlayOneShot(redGrowl);
        }
    }
}

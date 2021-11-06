using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundPlayer : MonoBehaviour
{
    [SerializeField] private AudioClip _portal;
    [SerializeField] private AudioClip _spell;
    private AudioSource _audioSource;

    public void PlayPortalClip()
    {
        PlayClip(_portal);
    }

    public void PlaySpellClip()
    {
        PlayClip(_spell);
    }

    private void PlayClip(AudioClip audio)
    {
        _audioSource.clip = audio;
        _audioSource.Play();
    }

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }
}

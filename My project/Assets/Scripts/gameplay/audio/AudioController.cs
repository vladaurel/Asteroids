
using System.Collections.Generic;
using UnityEngine;

namespace Audio
{
    // Normally I'm against nesting - however here it makes sense
    [System.Serializable]
    public class AudioClipMapping
    {
        public string name;
        public AudioClip clip;
    }

    public class AudioController : MonoBehaviour
    {
        [SerializeField] private List<AudioClipMapping> _audioClips;
        [SerializeField] private float _volume = 0.2f;


        private AudioSource _audioSource;

        private void Start()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        public void PlayAudio(string clipName)
        {
            AudioClip clip = null;
            foreach (var audioClipMapping in _audioClips)
            {
                if (audioClipMapping.name == clipName)
                {
                    clip = audioClipMapping.clip;
                    break; 
                }
            }

            if (clip != null)
            {
                _audioSource.PlayOneShot(clip,_volume);
            }
            else
            {
                Debug.LogWarning("Audio clip not found: " + clipName);
            }
        }

        public void SetVolume(float newVolume) { _volume = newVolume; }
    }
}

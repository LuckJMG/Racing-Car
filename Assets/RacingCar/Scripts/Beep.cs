using UnityEngine;

namespace RacingCar
{
    public class Beep : MonoBehaviour
    {
        [SerializeField] private AudioClip beepAudioClip;
        private InputHandler _inputHandler;
        private AudioSource _audioSource;

        private void Start()
        {
            _inputHandler = GetComponent<InputHandler>();
            _audioSource = GetComponent<AudioSource>();
        }

        private void Update()
        {
            if (_inputHandler == null || _audioSource == null) return;
            if (_inputHandler.Beep) _audioSource.PlayOneShot(beepAudioClip);
        }
    }
}

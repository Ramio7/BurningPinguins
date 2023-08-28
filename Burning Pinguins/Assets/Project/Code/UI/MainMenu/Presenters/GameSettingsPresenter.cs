using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class GameSettingsPresenter : MonoBehaviour, IUiWindow
{
    [SerializeField] private Button _backToMainMenuButton;
    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private Slider _audioSlider;

    [SerializeField] private List<AudioClip> _audioClipList;

    public static Canvas Canvas;

    public void OnEnable()
    {
        Canvas = GetComponent<Canvas>();
        _audioSlider.onValueChanged.AddListener(SetAudioVolume);
        _backToMainMenuButton.onClick.AddListener(SwitchToMainMenu);
    }

    public void OnDisable()
    {
        Canvas = null;
        _audioSlider.onValueChanged.RemoveListener(SetAudioVolume);
        _backToMainMenuButton.onClick.RemoveListener(SwitchToMainMenu);
    }

    private void SetAudioVolume(float volume)
    {
        _audioMixer.SetFloat("Master", volume);
    }

    private void SwitchToMainMenu()
    {
        Canvas.enabled = false;
        MainMenuPresenter.Canvas.enabled = true;
    }
}

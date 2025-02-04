using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class SettingManager : MonoBehaviour
{
    public static SettingManager Instance { get; private set; }
    [SerializeField] private AudioSource bgmAudioSource;
    [SerializeField] private AudioSource soundEffectAudioSource;
    [SerializeField] private Slider bgmVolumeSlider;
    [SerializeField] private Slider soundEffectVolumeSlider;

    // Awake is called when the script instance is being loaded
    private void Awake()
    {
        // If there is already an instance and it's not this one, destroy this game object
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        // Assign the static instance and make it persist across scenes
        Instance = this;
        DontDestroyOnLoad(gameObject);

        bgmVolumeSlider.value = bgmAudioSource.volume * 10;
        soundEffectVolumeSlider.value = soundEffectAudioSource.volume;
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)){
            gameObject.transform.GetChild(0).gameObject.SetActive(!gameObject.transform.GetChild(0).gameObject.activeSelf);
        }
    }

    //* bgmAudioSource.volume is 10 times smaller than bgamVolumeSlider.value because the bgm is so loud : for now
    public void SetBgmVolume(){
        bgmAudioSource.volume = bgmVolumeSlider.value * 0.1f;
    }

    public void SetSoundEffectVolume(){
        soundEffectAudioSource.volume = soundEffectVolumeSlider.value;
    }

    public void QuitGame(){
        Application.Quit();
    }
}

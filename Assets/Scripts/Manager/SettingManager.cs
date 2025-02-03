using UnityEngine;
using UnityEngine.InputSystem;

public class SettingManager : MonoBehaviour
{
    public static SettingManager Instance { get; private set; }
    [SerializeField] private GameObject BgmManager;
    [SerializeField] private GameObject SoundEffectManager;
    [SerializeField] private GameObject SettingManagerGUI;
    
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
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)){
            SettingManagerGUI.SetActive(!SettingManagerGUI.activeSelf);
        }
    }
}

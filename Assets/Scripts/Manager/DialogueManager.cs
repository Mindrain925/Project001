using UnityEngine;
using UnityEngine.AI;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance { get; private set; }
    public DialogueData dialogueData;
    public bool isEventExecuting;
    public int eventCount;
    public int eventIterator;

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

        // * This code is only for Testing
        eventCount = dialogueData.Events.Count;
        eventIterator = 0;
    }   

    public void ExecuteCutScene(CutSceneData cutSceneData){
        Debug.Log("Cut Scene was executed");
    }

    public void ExecuteLine(LineData lineData){
        Debug.Log("'" + lineData.DialogueCharacterData.FirstName + "' : " + lineData.Content);
    }

    private void Update() {
        if (dialogueData == null)
            return;

        if (Input.GetKeyDown(KeyCode.Space) && !isEventExecuting && eventIterator < eventCount){
            isEventExecuting = true;

            if (dialogueData.Events[eventIterator] is LineData lineData){
                ExecuteLine(lineData);
            }
            else if (dialogueData.Events[eventIterator] is CutSceneData cutSceneData){
                ExecuteCutScene(cutSceneData);
            }
            else{
                Debug.LogError("dialogueData.Events[" + eventIterator + "] is neither LineData nor CutSceneData");
            }

            isEventExecuting = false;
            eventIterator++;
        }
    }
}

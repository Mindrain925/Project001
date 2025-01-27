using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance { get; private set; }
    [SerializeField] private Image dialogueBackground;
    [SerializeField] private GameObject dialogueBoxesContainer;
    public DialogueData dialogueData;
    public List<GameObject> dialogueBoxes;
    public bool isEventExecuting;
    public int eventCount;
    public int eventIterator;
    public GameObject cutSceneShowerGUI;
    public GameObject DialogueBoxLeftGUIPrefab;
    public GameObject DialogueBoxRightGUIPrefab;
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
        // eventCount = dialogueData.Events.Count;
        // eventIterator = 0;
        // dialogueBackground.sprite = dialogueData.DialougeBackgroundSprite;
    }   

    public void StartDialouge(DialogueData _dialogueData){
        dialogueBackground.sprite = _dialogueData.DialougeBackgroundSprite;

        for (int i = 0; i < _dialogueData.ParticipatorsNames.Count; i++){
            GameObject dialogueBox =  (i % 2 == 0) ? Instantiate(DialogueBoxLeftGUIPrefab) : Instantiate(DialogueBoxRightGUIPrefab);

            DialogueBox dialogueBoxScript = dialogueBox.GetComponent<DialogueBox>();
            dialogueBoxScript.ownerCharacterName = _dialogueData.ParticipatorsNames[i];
            dialogueBoxScript.line.text = "";

            // TODO : Get The Charcater Idle Sprite
            // dialogueBoxScript.portrait.sprite = _dialogueData.;

            dialogueBoxes.Add(dialogueBox);
            dialogueBox.transform.SetParent(dialogueBoxesContainer.transform);
        }

        dialogueData = _dialogueData;

        eventCount = dialogueData.Events.Count;
        eventIterator = 0;
    }

    public IEnumerator ExecuteLine(LineData lineData){
        isEventExecuting = true;
        GameObject dialogueBox = null;

        for (int i = 0; i < dialogueBoxes.Count; i++){
            if (dialogueBoxes[i].GetComponent<DialogueBox>().ownerCharacterName == lineData.DialogueCharacterData.FirstName){
                dialogueBox = dialogueBoxes[i];
                yield return StartCoroutine(TypeLine(dialogueBoxes[i].GetComponent<DialogueBox>(), lineData));
                break;
            }
        }
        
        //* This Code must be refactored
        // The third child must be DialogueArrow
        dialogueBox.transform.GetChild(2).gameObject.SetActive(true);
        yield return new WaitUntil(() => Input.anyKeyDown);
        dialogueBox.transform.GetChild(2).gameObject.SetActive(false);

        isEventExecuting = false;
        eventIterator++;
    }

    public IEnumerator TypeLine(DialogueBox dialogueBoxes, LineData lineData){
        string line = "";
        string content = lineData.Content;

        for (int i = 0; i < content.Length; i++){
            line += content[i];
            dialogueBoxes.line.text = line;
            SoundEffectManager.Instance.Play(lineData.DialogueCharacterData.ChatEffectSound);
            dialogueBoxes.portrait.sprite = lineData.DialogueCharacterData.GetSprite(lineData.PortraitType);
            

            yield return new WaitForSeconds(0.05f);
        }
    }

    public IEnumerator ExecuteCutScene(CutSceneData cutSceneData){
        isEventExecuting = true;

        //* This Code must be refactored
        // The second child must be "CutScene"
        cutSceneShowerGUI.transform.GetChild(1).GetChild(0).gameObject.GetComponent<Image>().sprite = cutSceneData.CutSceneSprite;
        cutSceneShowerGUI.transform.GetChild(1).gameObject.SetActive(false);

        cutSceneShowerGUI.SetActive(true);
        for (int i = 0; i < 101; i++){
            cutSceneShowerGUI.GetComponent<CanvasGroup>().alpha = i * 0.01f;
            yield return new WaitForSeconds(0.001f);
        }  

        // yield return new WaitForSeconds(0.2f);
        cutSceneShowerGUI.transform.GetChild(1).gameObject.SetActive(true);

        for (int i = 0; i < 101; i++){
            cutSceneShowerGUI.transform.GetChild(1).gameObject.GetComponent<CanvasGroup>().alpha = i * 0.01f;
            yield return new WaitForSeconds(0.001f);
        }

        yield return new WaitUntil(() => Input.anyKeyDown);

        cutSceneShowerGUI.SetActive(false);

        isEventExecuting = false;
        eventIterator++;
    }

    private void Update() {
        if (dialogueData == null || eventIterator == eventCount){
            Debug.Log("Dialouge End!");
            return;
        }

        if (!isEventExecuting && eventIterator < eventCount){
            if (dialogueData.Events[eventIterator] is LineData lineData){
                StartCoroutine(ExecuteLine(lineData));
            }
            else if (dialogueData.Events[eventIterator] is CutSceneData cutSceneData){
                StartCoroutine(ExecuteCutScene(cutSceneData));
            }
            else{
                Debug.LogError("dialogueData.Events[" + eventIterator + "] is neither LineData nor CutSceneData");
            }
        }
    }
}

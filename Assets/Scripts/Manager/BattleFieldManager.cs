using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleFieldManager : MonoBehaviour
{
    public static BattleFieldManager Instance { get; private set; }
    [SerializeField] private List<GameObject> battleProtagonistsData;
    [SerializeField] private List<GameObject> battleEnemiesData;
    [SerializeField] private List<GameObject> battleProtagonists;
    [SerializeField] private List<GameObject> battleEnemies;
    private List<GameObject> allBattleCharacters;

    [SerializeField] private GameObject battleSkillGUIPrefab;
    [SerializeField] private GameObject battleSlotGUIPrefab;

    // GameObject used to initialze a GUI gameObject.
    [SerializeField] private GameObject battleFieldCanvas;
    [SerializeField] private GameObject unusedSkillContainerleft;
    [SerializeField] private GameObject unusedSkillContainerRight;
    [SerializeField] private GameObject protagonistSkillsContainer;
    [SerializeField] private GameObject protagonistBattleSlotsGUIContainer;

    [SerializeField] private int wave;
    
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        
        allBattleCharacters = new List<GameObject>();
    }

    private void Start() {
        wave = 0;

        StartBattle(battleProtagonistsData, battleEnemiesData); //* This code is only for testing
    }

    //This function causes loading time.
    public void StartBattle(List<GameObject> _battleProtagonists, List<GameObject> _battleEnemies){
        battleFieldCanvas = GameObject.Find("BattleFieldCanvas");
        unusedSkillContainerleft = GameObject.Find("UnusedSkillContainerleft");
        unusedSkillContainerRight = GameObject.Find("UnusedSkillContaineright");

        //This is shallow copy. Maybe someday this should be refactored to be deep copy.
        battleProtagonistsData.AddRange(_battleProtagonists);
        battleEnemiesData.AddRange(_battleEnemies);

        battleProtagonistsData.RemoveAt(0); //* This code is only for testing

        foreach (var character in battleProtagonistsData) {
            battleProtagonists.Add(Instantiate(character));
        }

        foreach (var character in battleEnemiesData) {
            battleEnemies.Add(Instantiate(character));
        }

        allBattleCharacters.AddRange(battleProtagonists);
        allBattleCharacters.AddRange(battleEnemies);

        foreach (var character in battleProtagonists){
            //reference to battleFieldCharacter
            var battleFieldCharacter = character.GetComponent<BattleFieldCharacter>();

            battleFieldCharacter.Initialize();

            //innitiate the protagonists slots
            foreach (var battleSlotDatum in battleFieldCharacter.battleSlotsData){
                var battleSlotGUI = Instantiate(battleSlotGUIPrefab);
                battleSlotGUI.transform.SetParent(protagonistBattleSlotsGUIContainer.transform);

                battleSlotGUI.GetComponent<BattleSlotGUI>().slot = battleSlotDatum;
                
                battleFieldCharacter.battleSlotGUI.Add(battleSlotGUI);
            }

            //initiate the protagonists skills
            foreach (var battleSkillDatum in battleFieldCharacter.battleSkillData){
                //reference of a gameObject possessing one of the Battle Skill that the battleFieldCharacter has.
                var battleSkill = Instantiate(battleSkillDatum.battleSkill);
                battleSkill.transform.SetParent(protagonistSkillsContainer.transform);
                battleSkill.name = battleSkill.name.Replace("(Clone)", "").Trim();

                //reference of a gameObject(prefab) : The prefab is GUI attached with battleSkill
                var battleSkillGUI = Instantiate(battleSkillGUIPrefab);
                battleSkillGUI.transform.SetParent(unusedSkillContainerleft.transform);
                battleSkillGUI.name = battleSkill.name + " GUI";

                battleSkillGUI.GetComponent<BattleSkillGUI>().defaultUnusedSkillContainer = unusedSkillContainerleft;
                battleSkillGUI.GetComponent<BattleSkillGUI>().canvas = battleFieldCanvas;
                battleSkillGUI.GetComponent<BattleSkillGUI>().skill = battleSkill;
                battleSkillGUI.GetComponent<Image>().sprite = battleSkillDatum.battleSkill.GetComponent<Skill>().SkilData.Icon;
                battleSkillGUI.GetComponent<BattleSkillGUI>().Initialize();

                battleFieldCharacter.battleSkillGUI.Add(battleSkillGUI);
                battleFieldCharacter.battleSkill.Add(battleSkill);
            }
        }

        //initiate the enenmies slots
        foreach (var character in battleEnemiesData){
            // Debug.Log("Slot initiate");
        }

        //initiate the enenmies skills
        foreach (var character in battleEnemiesData){
            // Debug.Log("Slot initiate");
        }

        wave = 0;

        StartWave();
    }

    public void EndBattle(){

        //TODO : Check if some   data were changed and reflect them

        Debug.Log("The Battle was ended");
    }

    public void StartWave(){
        wave++;
        
        ChangePriority();
        SetEnemiesActions();

        Debug.Log("The wave was started");

        //TODO : Implement user action that deciding what skills to used ?
    }

    public void StartFight(){

        //TODO : Execute all Battle Slots' skills;

        Debug.Log("All actions are executed!");

    }

    public void SetEnemiesActions(){

        //TODO : Implement enemies random action

        Debug.Log("Enemies' Actions are set!");
    }    

    public void ChangePriority(){

        //TODO : Implement the function that decides all Battle Slots prioiry

        Debug.Log("All Battle Characters' priority were changed");
    }
}

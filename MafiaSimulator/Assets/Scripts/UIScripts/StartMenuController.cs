using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StartMenuController : MonoBehaviour
{
    public Text ClassBackground, ClassBackground2;
    public Button TheFarmer, TheBouncer, TheAccountant, GameStart;
    public PlayerClass Farmer, Accountant, Bouncer;
    public GameObject Currency;
    public GameObject StartingJob;
    public GameObject MobilCard, AthCard, PersCard;
    public Vector3 JobSpawn, CurrencySpawn, MobilitySpawn, AthleticsSpawn, PersuasionSpawn;
    public int NumCurrency;
    public AudioSource aSource;
    public AudioClip bGround1;
    private NarrativeController N_Control;
    private ListOfCards cardList;
    private PlayerActions pActions;
    private void Awake()
    {
        N_Control = GameObject.Find("NarrativeController").GetComponent<NarrativeController>();
        cardList = GameObject.Find("NarrativeController").GetComponent<ListOfCards>();
        pActions = GetComponent<PlayerActions>();
        GameStart.interactable = false;
    }
    private void Update()
    {
        if(TheAccountant.interactable == false || TheBouncer.interactable == false || TheFarmer.interactable == false)
        {
            GameStart.interactable = true;
        }
        if(TheFarmer.interactable == false)
        {
            ClassBackground.text = "You are a farmer who has hit hard times. So you have turned to something more lucrative: running moonshine.";
            ClassBackground2.text = "Starting currency is 2. Your starting Athletics, Mobility, and Persuasion are 1.";
        }
        if(TheAccountant.interactable == false)
        {
            ClassBackground.text = "You are an Accountant who has broken into the money laundering buisness. I wonder how long you will survive.";
            ClassBackground2.text = "Starting currency is 4. Your starting Athletics, Mobility, and Persuasion are 1.";
        }
        if(TheBouncer.interactable == false)
        {
            ClassBackground.text = "You are a bouncer at a popular club. Someone has taken notice of your efforts. I wonder what they have planned for you.";
            ClassBackground2.text = "Starting currency is 3. Your starting Athletics, Mobility, and Persuasion are 1.";
        }
    }
    public void ButtonPressSpawn()
    {
        aSource.Play();
        pActions.currentState = PlayerActions.GameState.Active;
        SpawningStartingJob(1, StartingJob);
        SpawnStartingCurrency(NumCurrency, Currency);
        SpawnStartingSkills(1, MobilCard, AthCard, PersCard);
    }
    void SpawningStartingJob(int times, GameObject card)
    {
        for(int i = 0; i < times; i++)
        {
            Instantiate(card, JobSpawn, Quaternion.identity);
        }
    }
    void SpawnStartingCurrency(int times, GameObject card)
    {
        for (int i = 0; i < times; i++)
        {
            Instantiate(card, CurrencySpawn, Quaternion.identity);
        }
    }
    void SpawnStartingSkills(int times, GameObject Mobility, GameObject Athletics, GameObject Persuasion)
    {
        for (int i = 0; i < times; i++)
        {
            Instantiate(Mobility, MobilitySpawn, Quaternion.identity);
        }
        for (int i = 0; i < times; i++)
        {
            Instantiate(Athletics, AthleticsSpawn, Quaternion.identity);
        }
        for (int i = 0; i < times; i++)
        {
            Instantiate(Persuasion,PersuasionSpawn, Quaternion.identity);
        }
    }
    public void setPClassFarmer()
    {
        N_Control.StartingJob = Farmer;
        StartingJob = cardList.cards[2].gameObject;
        NumCurrency = Farmer.starting_Currency;
        TheFarmer.interactable = false;
        TheAccountant.interactable = true;
        TheBouncer.interactable = true;
    }
    public void setPClassAccountant()
    {
        N_Control.StartingJob = Accountant;
        StartingJob = cardList.cards[1].gameObject;
        NumCurrency = Accountant.starting_Currency;
        TheFarmer.interactable = true;
        TheAccountant.interactable = false;
        TheBouncer.interactable = true;
    }
    public void setPClassBouncer()
    {
        N_Control.StartingJob = Bouncer;
        StartingJob = cardList.cards[0].gameObject;
        NumCurrency = Bouncer.starting_Currency;
        TheFarmer.interactable = true;
        TheAccountant.interactable = true;
        TheBouncer.interactable = false;
    }
}
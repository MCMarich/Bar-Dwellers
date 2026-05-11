using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine;

public enum Mission
{
    One, Two, Three, Four, Five
}
public class Player : MonoBehaviour
{
    public Mission _currentMission;
    [SerializeField] public TMP_Text _ratingText;
    private NPC _npc;
    public delegate void ObjectDelegate(GameObject o);
    public event ObjectDelegate Interacted;
    public List<GameObject> _inventory;
    public List<string> _inventoryString;
    public float _rating = 3.0f;
    public static Player Instance { get; private set; }
    public Player _player { get; private set; }
    private string _scene;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }


        Instance = this;

        DontDestroyOnLoad(this);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    private void Update()
    {
        _scene = SceneManager.GetActiveScene().name;
        if (_scene == "Speak" || _scene == "Speak1" || _scene == "Speak2" || _scene == "Speak3")
        {
            if(_ratingText == null)
            {
                _ratingText = GameObject.FindWithTag("Rate").GetComponent<TMP_Text>();
            }
            if (_ratingText.text == "New Text")
            {
                _ratingText.text = "Rating: " + _rating.ToString() + "/5";
            }
        }
    }
}

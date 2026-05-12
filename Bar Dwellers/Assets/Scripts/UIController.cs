using NUnit.Framework;
using TMPro;
using UnityEngine;
using System.Collections.Generic;

public class UIController : MonoBehaviour
{
    [SerializeField] public GameObject _inventorybox;
    [SerializeField] public GameObject _uparrow;
    [SerializeField] public GameObject _downarrow;
    private bool _boxActive = false;
    // dialogue UI
    [SerializeField] private GameObject _dialogueBox;
    [SerializeField] private TMP_Text _npcText;
    [SerializeField] private GameObject _playerOptions;
    [SerializeField] private TMP_Text _option1;
    [SerializeField] private TMP_Text _option2;
    [SerializeField] private TMP_Text _option3;
    [SerializeField] private List<GameObject> _notebooks;
    private int i = 0;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I) && _boxActive == false)
        {
            _inventorybox.SetActive(true);
            _uparrow.SetActive(true);
            _downarrow.SetActive(true);
            _boxActive = true;
            Debug.Log(i);
        }
        else if (Input.GetKeyDown(KeyCode.I) && _boxActive == true)
        {
            _inventorybox.SetActive(false);
            _notebooks[i].SetActive(false);
            _uparrow.SetActive(false);
            _downarrow.SetActive(false);
            _boxActive = false;
        }
    }
    // dialogue logic
    public void ShowDialogue(string dialogue)
    {
        _dialogueBox.SetActive(true);

        _npcText.enabled = true;
        _playerOptions.SetActive(false);

        _npcText.text = dialogue;
    }

    // note: this only works for up to 3 dialogue options at a time currently
    // if you want to make more possible, you may have to get crafty with the UI... :)
    public void ShowPlayerOptions(string[] options)
    {
        _dialogueBox.SetActive(false);

        _npcText.enabled = false;
        _playerOptions.SetActive(true);

        _option1.text = options[0];

        if (options.Length >= 2)
        {
            _option2.transform.parent.gameObject.SetActive(true);
            _option2.text = options[1];
        }
        else
        {
            _option2.transform.parent.gameObject.SetActive(false);
        }

        if (options.Length >= 3)
        {
            _option3.transform.parent.gameObject.SetActive(true);
            _option3.text = options[2];
        }
        else
        {
            _option3.transform.parent.gameObject.SetActive(false);
        }
    }
    public void Up()
    {
        i += 1;
        if (i == _notebooks.Count)
        {
            _inventorybox.SetActive(false);
            i = 0;
            _inventorybox = _notebooks[i];
            _inventorybox.SetActive(true);
        }
        else
        {
            _inventorybox = _notebooks[i];
            _notebooks[i - 1].SetActive(false);
            _notebooks[i].SetActive(true);
        }
    }

    public void Down()
    {
        i -= 1;
        if (i < 0)
        {
            _inventorybox.SetActive(false);
            i = _notebooks.Count - 1;
            _inventorybox = _notebooks[i];
            _inventorybox.SetActive(true);
        }
        else
        {
            _inventorybox = _notebooks[i];
            _notebooks[i + 1].SetActive(false);
            _notebooks[i].SetActive(true);
        }
    }

    public void HideDialogue()
    {
        _dialogueBox.SetActive(false);
        _playerOptions.SetActive(false);
        _npcText.enabled = false;
    }
}

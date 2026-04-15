using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public delegate void ObjectDelegate(GameObject o);
    public event ObjectDelegate Interacted;
    public List<GameObject> _inventory;
    public List<string> _inventoryString;
    public static Player Instance { get; private set; }
    public Player _player { get; private set; }

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
}

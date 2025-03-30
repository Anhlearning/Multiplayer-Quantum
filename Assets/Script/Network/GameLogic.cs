using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    public GameObject LocalPlayerPrefab;
    public GameObject PlayerPrefab;
    public static GameLogic Instance {get; private set;}
    void Awake()
    {
        Instance=this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

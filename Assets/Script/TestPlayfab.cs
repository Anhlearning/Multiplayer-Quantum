using System;
using System.Collections;
using System.Collections.Generic;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;

public class TestPlayfab : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var request = new LoginWithCustomIDRequest
        {
            CustomId = "TestUser",
            CreateAccount = true
        };
        PlayFabClientAPI.LoginWithCustomID(request, OnLoginSuccess, OnLoginFailure);
    }

    private void OnLoginFailure(PlayFabError error)
    {
        Debug.LogError("Error logging in: " + error.GenerateErrorReport());
    }

    private void OnLoginSuccess(LoginResult result)
    {
        Debug.Log("Login successful! Welcome, " + result.PlayFabId);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

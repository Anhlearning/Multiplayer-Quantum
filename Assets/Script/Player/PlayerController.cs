using System.Collections;
using System.Collections.Generic;
using Riptide;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform camForward;

    private bool[] inputs;
    private void Awake() {
        camForward=FindAnyObjectByType<Camera>().transform;
        inputs= new bool[4];
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
            inputs[0] = true;
        

        if (Input.GetKey(KeyCode.S))
            inputs[1] = true;

        if (Input.GetKey(KeyCode.A))
            inputs[2] = true;

        if (Input.GetKey(KeyCode.D))
            inputs[3] = true;

        // if (Input.GetKey(KeyCode.Space))
        //     inputs[4] = true;

        // if (Input.GetKey(KeyCode.LeftShift))
        //     inputs[5] = true;
    }
    private void FixedUpdate() {
        SendInput();

         for (int i = 0; i < inputs.Length; i++)
            inputs[i] = false;
    }
    private void SendInput(){
        Message message = Message.Create(MessageSendMode.Unreliable,ClientToServerId.input);
        message.AddBools(inputs,false);
        message.AddQuaternion(camForward.rotation);
        NetworkManager.Instance.Client.Send(message);
    }
}

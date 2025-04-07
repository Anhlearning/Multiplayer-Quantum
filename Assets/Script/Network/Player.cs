using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Riptide;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Dictionary<ushort,Player> Players= new Dictionary<ushort, Player>();
    public ushort Id { get; private set; }
    public bool IsLocal { get; private set; }
    private string username;
    [SerializeField] private Transform camFollow;
    [SerializeField] private Transform camFowrad;
    [SerializeField] private float rotateSpeed=50f;
    [SerializeField] private CinemachineFreeLook cinemachineFreeLook;
   

    private void Awake() {
        camFowrad=GameObject.FindAnyObjectByType<Camera>().transform;
        cinemachineFreeLook=GameObject.FindAnyObjectByType<CinemachineFreeLook>();
    }
    public static void Spawn(ushort id, string username ,Vector3 position)
    {
        Player player;
        if (id == NetworkManager.Instance.Client.Id)
        {   
            player = Instantiate(GameLogic.Instance.LocalPlayerPrefab, position, Quaternion.identity).GetComponent<Player>();
            player.IsLocal = true;
            Debug.Log("LOCAL PLAYER");
        }
        else
        {
            player = Instantiate(GameLogic.Instance.PlayerPrefab, position, Quaternion.identity).GetComponent<Player>();
            player.IsLocal = false;
            Debug.Log("Player Difff");
        }   
        

        player.name = $"Player {id} ({username})";
        player.Id = id;
        player.username = username;
        player.SetCameraFollow();
        Players.Add(id, player);
    }
    private void SetCameraFollow(){
        if(IsLocal){
            cinemachineFreeLook.Follow = transform;
            cinemachineFreeLook.LookAt = camFollow;
        }
    }
    private void OnDestroy()
    {
        Players.Remove(Id);
    }

    public void Move(Vector3 newPos){
        Vector3 moveDir=newPos- transform.position;
        transform.position = newPos;

        if(moveDir.magnitude != 0){
            HandleRotation(moveDir);
        }
        if(!IsLocal){
            // camFowrad.forward=Camfoward;
        }

    }
    public void HandleRotation(Vector3 moveDir){
        Quaternion targetRotaion=Quaternion.LookRotation(moveDir);
        transform.rotation=Quaternion.RotateTowards(transform.rotation,targetRotaion,rotateSpeed *  Time.deltaTime);
    }
    [MessageHandler((ushort)ServerToClientId.playerSpawned)]
    private static void SpawnPlayer(Message message)
    {
        Spawn(message.GetUShort(), message.GetString(), message.GetVector3());
    }
    [MessageHandler((ushort) ServerToClientId.playerMovement)]
    private static void Move(Message message){
        if(Players.TryGetValue(message.GetUShort(),out Player player)){
            player.Move(message.GetVector3());
        }
    }
}

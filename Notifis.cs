using UnityEngine;
using UnityEngine.Networking;
using Photon.Pun;
using TMPro;
using Photon.VR;
using Photon.Voice.PUN;
using Photon.VR.Player;
using System.Text;
using System.Collections;
using System;
using System.Collections.Generic;
using Photon.Realtime;
using PlayFab;
using PlayFab.ClientModels;

public class Notifis : MonoBehaviourPunCallbacks
{
    [Header("Made by sev :)")]
    [Header("Needed Data")]
    [SerializeField] public string WebHookURL;
    public Playfablogin PlayfabLoginScript;
    [Header("Can not get player id on start message")]
    public bool ShowPlayerID = false;
    [Header("Optoins")]
    public bool SendNotifiOnStart = true;
    public bool SendNotifiOnJoinRoom = true;
    public bool SendNotifiOnLeaveRoom = true;
    // Start is called before the first frame update
    void Start()
    {
        if(SendNotifiOnStart)
        {
            SendtoWebhook(PlayerPrefs.GetString("Username", null) + " logged on.");
        }
    }
    public override void OnJoinedRoom()
    {
        if(SendNotifiOnJoinRoom)
        {
            string roomcode = PhotonNetwork.CurrentRoom.Name;
            if(!ShowPlayerID)
            {
                SendtoWebhook(PlayerPrefs.GetString("Username", null) + " joined server " + roomcode + ".");
            }
            if(ShowPlayerID)
            {
                SendtoWebhook(PlayerPrefs.GetString("Username", null) + " **" + PlayfabLoginScript.MyPlayFabID + "** joined server " + roomcode + ".");
            }
        }
    }
    public override void OnLeftRoom()
    {
        if(SendNotifiOnLeaveRoom)
        {
            if(!ShowPlayerID)
            {
                SendtoWebhook(PlayerPrefs.GetString("Username", null) + " left the server.");
            }
            if(ShowPlayerID)
            {
                SendtoWebhook(PlayerPrefs.GetString("Username", null) + " **" + PlayfabLoginScript.MyPlayFabID + "** left the server.");
            }
        }
    }

    public void SendtoWebhook(string message)
    {
        StartCoroutine(PostToDiscord(message));
    }

    IEnumerator PostToDiscord(string message)
    {
        string jsonPayload = "{\"content\": \"" + message + "\"}";

        UnityWebRequest www = new UnityWebRequest(WebHookURL, "POST");
        byte[] jsonToSend = new UTF8Encoding().GetBytes(jsonPayload);
        www.uploadHandler = (UploadHandler)new UploadHandlerRaw(jsonToSend);
        www.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        www.SetRequestHeader("Content-Type", "application/json");
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("Reporting Webhook Error: " + www.error);
        }
    }
}

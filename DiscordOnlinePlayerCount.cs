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

public class DiscordOnlinePlayerCount : MonoBehaviour
{
    [Header("Made by sev :)")]
    [SerializeField] public string WebHookURL;
    public string PlayerName = "Monke";
    [Space]
    [Space]
    [Header("Update player count after _ seconds")]
    public float UPCA = 10f;

    // Update is called once per frame
    void Update()
    {
       if (PhotonNetwork.IsConnected)
       {
           int playerCount = PhotonNetwork.CountOfPlayers;
           SendtoWebhook(playerCount + " " + PlayerName + "s are currently online.");
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
        yield return new WaitForSeconds(UPCA);
    }
}

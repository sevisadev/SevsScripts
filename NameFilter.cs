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

public class NameFilter : MonoBehaviour
{
    [Header("Made by sev :)")]
    public TextMeshPro username;
    public NameScript NameScript;
    public Playfablogin PlayfabLoginScript;
    [Header("This webhook will be used to send you a notifis on playes")]
    public bool SendNotifi = true;
    [SerializeField] public string WebHookURL;
    [Space]
    [Space]

    public List<string> blockedUsernames;
    string currentuser;
    string currentuserphoton;
    string blocked = "**";

    void Update()
    {
        currentuserphoton = PhotonNetwork.LocalPlayer.NickName;
        currentuser = PlayerPrefs.GetString("Username");
        foreach (string x in blockedUsernames)
        {
            if (username.text == x)
            {
                username.text = "Sev";
            }
        }
        foreach (string x in blockedUsernames)
        {
            if (currentuser == x)
            {
                PlayerPrefs.SetString("Username", blocked);
            }
        }
        foreach (string x in blockedUsernames)
        {
            if (currentuserphoton == x)
            {
                if (SendNotifi){
                    SendtoWebhook("**" + PlayfabLoginScript.MyPlayFabID + "** set their username to " + NameScript.NameVar + ".");
                }
                NameScript.NameVar = "Blocked";
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.VR;
using TMPro;

public class SetNameOnNewPlayer : MonoBehaviour
{
    [Header("Made by sev :)")]
    public NameScript NameScript;
    public string NewPlayerName = "Monke";
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("NEWPLAYERSETNAMEONNEWTOCOMP2") != 1)
        {
           Invoke("SN", 0.1f);
        }
    }

    public void SN()
    {
        PhotonVRManager.SetUsername(NewPlayerName + Random.Range(0, 100));
        NameScript.NameVar = PlayerPrefs.GetString("Username", null);
        PlayerPrefs.SetInt("NEWPLAYERSETNAMEONNEWTOCOMP2", 1); 
    }
}

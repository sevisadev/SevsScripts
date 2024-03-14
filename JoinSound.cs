using UnityEngine;
using TMPro;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.XR;

public class JoinSound : MonoBehaviourPunCallbacks
{
    [Header("THIS SCRIPT WAS MADE BY SEV NOT YOU, PLEASE GIVE CREDITS!")]
    [Space]
    [Space]
    public bool PlaySoundOnLeave = true;
    [Space]
    [Space]
    public AudioSource AudioSource;
    public AudioClip Join;
    public AudioClip Leave;

    public override void OnJoinedRoom()
    {
        AudioSource.clip = Join;
        AudioSource.Play();
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        AudioSource.clip = Join;
        AudioSource.Play();
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        if(PlaySoundOnLeave)
        {
            AudioSource.clip = Leave;
            AudioSource.Play();
        }
    }
    public override void OnLeftRoom()
    {
        if(PlaySoundOnLeave)
        {
        AudioSource.clip = Leave;
        AudioSource.Play();
        }
    }
}

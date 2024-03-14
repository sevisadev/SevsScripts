using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEnable : MonoBehaviour
{
    [Header("Made by sev :)")]
    public int AmoutOfObejectsToEnable = 1;
    public GameObject[] Objects;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < Objects.Length; i++)
        {
            Objects[i].SetActive(false);
        }
        EnableRandomObject();
    }
    void EnableRandomObject()
    {
        for (int x = 0; x < AmoutOfObejectsToEnable; x++)
        {
            int randomIndex = Random.Range(0, Objects.Length);
            Objects[randomIndex].SetActive(true);
        }
    }
}

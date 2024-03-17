using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveEnabled : MonoBehaviour
{
    [Header("Made by sev :)")]
    [SerializeField] public GameObject[] ObjectsToSave;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < ObjectsToSave.Length; i++)
        {
            if (PlayerPrefs.GetInt(ObjectsToSave[i].name) == 1)
            {
                ObjectsToSave[i].SetActive(true);
            }
            else
            {
                ObjectsToSave[i].SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < ObjectsToSave.Length; i++){
            if(ObjectsToSave[i].activeSelf)
            {
                PlayerPrefs.SetInt(ObjectsToSave[i].name, 1);
            }
            else
            {
                PlayerPrefs.SetInt(ObjectsToSave[i].name, 0);
            }
        }
    }
}

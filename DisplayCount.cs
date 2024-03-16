using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayCount : MonoBehaviour
{
    private TMP_Text Text;
    private int Count;
    [Header("Made by sev :)")]
    public DisplayCount DisplayCountScript;
    public bool IsDisplay = false;
    public int ChangeNumberBy = 0;
    public bool IsSet = false;
    public string TextBeforeCount = "Count";
    public int StartCountAt = 0;
    // Start is called before the first frame update
    void Start()
    {
        if(IsDisplay)
        {
            Text = GetComponent<TMP_Text>();
            Count = StartCountAt;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(IsDisplay)
        {
            Text.text = TextBeforeCount + ": " + StartCountAt;
        }
    }
    public void OnTriggerEnter()
    {
        if(!IsSet)
        {
            DisplayCountScript.StartCountAt = DisplayCountScript.StartCountAt+ChangeNumberBy;
        }
        if(IsSet)
        {
            DisplayCountScript.StartCountAt = ChangeNumberBy;
        }
    }
}

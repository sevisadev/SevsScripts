using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using easyInputs;

public class NoClip : MonoBehaviour
{
    private Collider[] ObjectsWithColliders;
    [Header("Made by sev :)")]
    public EasyHand Hand;
    public string TagToNotMessWith = "AntiNoClip";
    private bool NoClipOn;
    // Start is called before the first frame update
    void Start()
    {
        NoClipOn = false;
        ObjectsWithColliders = FindObjectsOfType<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        Check();
        if(EasyInputs.GetTriggerButtonDown(Hand))
        {
            NoClipOn = true;
        }
        else
        {
            NoClipOn = false;
        }
    }

    public void Check()
    {
        if(NoClipOn)
        {
            foreach (Collider collider in ObjectsWithColliders)
            {
                if(collider.gameObject.tag != TagToNotMessWith)
                {
                    collider.enabled = false;
                }
            }
        }
        else
        {
            foreach (Collider collider in ObjectsWithColliders)
            {
                if(collider.gameObject.tag != TagToNotMessWith)
                {
                    collider.enabled = true;
                }
            }
        }
    }
}

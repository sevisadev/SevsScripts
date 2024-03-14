using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using easyInputs;

public class BetterModMenu : MonoBehaviour
{
    private bool MenuOpen;
    private float turnSpeed = 5f;
    private Transform MT;
    private Transform ST;
    [Header("Made by sev :)")]
    public Transform Camera;
    public GameObject ModMenu;
    public Transform ModMenuOpenSpawn;
    [Space]
    [Space]
    [Space]
    [Space]
    [Header("Optoions")]
    public bool AlwaysFollowPlayer = false;
    [Space]
    [Header("When to open")]
    public bool OnBothJoysticksPressed = false;
    public bool OnBothTriggersPressed = true;
    public bool OnBothGripsPressed = false;
    public bool OnBothPrimarysPressed = false;
    public bool OnBothSecondarysPressed = false;
    [Space]
    [Header("When to close")]
    public bool onBothJoysticksPressed = false;
    public bool onBothTriggersPressed = false;
    public bool onBothGripsPressed = true;
    public bool onBothPrimarysPressed = false;
    public bool onBothSecondarysPressed = false;
    // Start is called before the first frame update
    void Start()
    {
        MT = ModMenu.GetComponent<Transform>();
        ModMenu.SetActive(false);
        ST = GetComponent<Transform>();
        MenuOpen = false;
        ModMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(AlwaysFollowPlayer)
        {
            if(MenuOpen)
            {
                Vector3 targetToCamera = Camera.position - MT.position;

                Quaternion targetRotation = Quaternion.LookRotation(targetToCamera);
    
                Vector3 currentAngles = targetRotation.eulerAngles;
                currentAngles.z = 0f;
                MT.rotation = Quaternion.Euler(currentAngles);
   
                Quaternion targetRotationXY = Quaternion.Euler(0f, targetRotation.eulerAngles.y, targetRotation.eulerAngles.x);
                MT.rotation = Quaternion.Slerp(MT.rotation, targetRotationXY, turnSpeed * Time.deltaTime);
            }
        }

        if(EasyInputs.GetThumbStickButtonDown(EasyHand.LeftHand))
        {
           if(EasyInputs.GetThumbStickButtonDown(EasyHand.RightHand))
           {
                if(OnBothJoysticksPressed)
                {
                    MM(true);
                }
                if(onBothJoysticksPressed)
                {
                    MM(false);
                }
           }
        }
        if(EasyInputs.GetTriggerButtonDown(EasyHand.LeftHand))
        {
            if(EasyInputs.GetTriggerButtonDown(EasyHand.RightHand))
            {
                if(OnBothTriggersPressed)
                {
                    MM(true);
                }
                if(onBothTriggersPressed)
                {
                    MM(false);
                }
            }
        }
        if(EasyInputs.GetGripButtonDown(EasyHand.LeftHand))
        {
            if(EasyInputs.GetGripButtonDown(EasyHand.RightHand))
            {
                if(OnBothGripsPressed)
                {
                    MM(true);
                }
                if(onBothGripsPressed)
                {
                    MM(false);
                }
            }
        }
        if(EasyInputs.GetPrimaryButtonDown(EasyHand.LeftHand))
        {
            if(EasyInputs.GetPrimaryButtonDown(EasyHand.RightHand))
            {
                if(OnBothPrimarysPressed)
                {
                    MM(true);
                }
                if(onBothPrimarysPressed)
                {
                    MM(false);
                }
            }
        }
        if(EasyInputs.GetSecondaryButtonDown(EasyHand.LeftHand))
        {
            if(EasyInputs.GetSecondaryButtonDown(EasyHand.RightHand))
            {
                if(OnBothSecondarysPressed)
                {
                    MM(true);
                }
                if(onBothSecondarysPressed)
                {
                    MM(false);
                }
            }
        }
    }
    public void MM(bool Active)
    {
        MenuOpen = (Active);
        if(!AlwaysFollowPlayer)
        {
            Vector3 targetToCamera = Camera.position - MT.position;

            Quaternion targetRotation = Quaternion.LookRotation(targetToCamera);

            Vector3 currentAngles = targetRotation.eulerAngles;
            currentAngles.z = 0f;
            MT.rotation = Quaternion.Euler(currentAngles);

            Quaternion targetRotationXY = Quaternion.Euler(0f, targetRotation.eulerAngles.y, targetRotation.eulerAngles.x);
            MT.rotation = Quaternion.Slerp(MT.rotation, targetRotationXY, turnSpeed * Time.deltaTime);
        }
        MT.position = ModMenuOpenSpawn.position;
        if(!AlwaysFollowPlayer)
        {
            Vector3 targetToCamera = Camera.position - MT.position;

            Quaternion targetRotation = Quaternion.LookRotation(targetToCamera);

            Vector3 currentAngles = targetRotation.eulerAngles;
            currentAngles.z = 0f;
            MT.rotation = Quaternion.Euler(currentAngles);

            Quaternion targetRotationXY = Quaternion.Euler(0f, targetRotation.eulerAngles.y, targetRotation.eulerAngles.x);
            MT.rotation = Quaternion.Slerp(MT.rotation, targetRotationXY, turnSpeed * Time.deltaTime);
        }
        ModMenu.SetActive((Active));
    }
}

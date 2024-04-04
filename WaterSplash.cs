using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSplash : MonoBehaviour
{
    private bool On;
    private GameObject Water;
    [Header("Made by sev :)")]
    public string HandTag = "HandTag";
    public GameObject SplashPrefab;
    public float TimeForSplash = 1.6f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!On){
            if(other.gameObject.tag == HandTag)
            {
                On = true;
                Water = Instantiate(SplashPrefab, other.gameObject.transform.position, Quaternion.identity);
                Invoke("Del", TimeForSplash);
            }
        }
    }
    public void Del()
    {
        Destroy(Water);
        On = false;
    }
}

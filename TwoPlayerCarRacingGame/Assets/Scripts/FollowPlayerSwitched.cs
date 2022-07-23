using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerSwitched : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset = new Vector3(0, 2.4f, 0.6f);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
        transform.rotation = player.transform.rotation;
    }
}

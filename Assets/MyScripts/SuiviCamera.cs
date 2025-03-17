using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuiviCamera : MonoBehaviour
{
    public GameObject mainCharacter;
    public Vector3 offset;
    public float timeOffset;
    public Vector3 velocity;
    // Start is called before the first frame update
    void Start()
    {
        mainCharacter = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
      transform.position = Vector3.SmoothDamp(transform.position, mainCharacter.transform.position + offset, ref velocity, timeOffset);
    }
}

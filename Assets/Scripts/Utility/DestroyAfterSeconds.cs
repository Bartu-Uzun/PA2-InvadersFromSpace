using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterSeconds : MonoBehaviour
{

    [SerializeField] private float seconds;
    // Start is called before the first frame update
    void Start()
    {

        Destroy(gameObject, seconds); //destroy after  'seconds' parameter
        
    }

}
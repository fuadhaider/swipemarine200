/*It does not destroy the target Object when loading a new Scene.
  it is attached to AdObject to keep to seamless ads in scene trnsitions
  and reloading same Scene
  */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script example manages the playing audio. The GameObject with the
// "ad" tag is the Ad GameObject. it is attached to first scene

public class DontDestroyGameObject : MonoBehaviour
{
    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Ad");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
}

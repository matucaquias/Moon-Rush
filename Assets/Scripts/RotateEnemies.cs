using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateEnemies : MonoBehaviour
{
    private PlayerMovement _player;
    List<Transform> childrens = new List<Transform>();
    void Start()
    {
        _player = FindObjectOfType<PlayerMovement>();
        foreach (Transform child in transform)
        {
            childrens.Add(child);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
    }

    void Rotate()
    {
        if (_player.isWolf)
        {
            foreach (Transform trans in childrens)
            {
                var transRotation = trans.rotation;
                transRotation.eulerAngles = new Vector3(0,180,0);
            }
        }
    }
}

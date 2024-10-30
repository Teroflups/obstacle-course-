using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeReference] private Transform transformPlayer;


    private void Update()
    {
        transform.position = new Vector3(transformPlayer.position.x, transformPlayer.position.y, -10);
    }
}

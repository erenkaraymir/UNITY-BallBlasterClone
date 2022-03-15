using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenSides : MonoBehaviour
{
    [SerializeField] BoxCollider2D leftWallCollider;
    [SerializeField] BoxCollider2D rightWallCollider;


    void Awake()
    {
        float screenWidht = Game.Instance.screenWidht;

        leftWallCollider.transform.position = new Vector3(-screenWidht - leftWallCollider.size.x / 2f, 0f, 0f);
        rightWallCollider.transform.position = new Vector3(screenWidht + leftWallCollider.size.x / 2f, 0f, 0f);
        Destroy(this); 
    }

}

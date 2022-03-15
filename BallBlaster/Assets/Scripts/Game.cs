
using UnityEngine;

public class Game : MonoBehaviour
{
    public static Game Instance;
    private void Awake()
    {
        Instance = this;
        screenWidht = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0f, 0f)).x;
    }

    [HideInInspector] public float screenWidht;
}

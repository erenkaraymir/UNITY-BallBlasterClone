using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Misslie : MonoBehaviour
{
    Queue<GameObject> missliesQueue;

    [SerializeField] GameObject misslie;
    [SerializeField] int misslieCount;

    [Space]
    [SerializeField] float delay = 0.3f;
    [SerializeField] float speed = 0.3f;

    GameObject g;
    float t = 0f;

    public static Misslie Instance;

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        PrepareMisslie();   
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        if(t >= delay)
        {
            t = 0f;
            g = SpawnMislie(transform.position);
            g.GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
        }
    }

    void PrepareMisslie()
    {
        missliesQueue = new Queue<GameObject>();
        for (int i = 0; i < misslieCount; i++)
        {
            g = Instantiate(misslie, transform.position, Quaternion.identity,transform);
            g.SetActive(false);
            missliesQueue.Enqueue(g);
        }
    }

    public GameObject SpawnMislie(Vector2 pos)
    {
        if(missliesQueue.Count > 0)
        {
            g = missliesQueue.Dequeue();
            g.transform.position = pos;
            g.SetActive(true);
            return g;
        }
        else
        {
            return null;
        }
    }

    public void DestroyMisslie(GameObject misslie)
    {
        missliesQueue.Enqueue(misslie);
        misslie.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("missile"))
        {
            DestroyMisslie(collision.gameObject);   
        }
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Ground : MonoBehaviour
{
    [SerializeField] private Bird bird;
    [SerializeField] private float speed = 1;
    [SerializeField] private Transform nextPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(bird == null || (bird != null && !bird.IsDead()))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
        }
    }

    public void SetNextGround(GameObject ground)
    {
        if(ground != null)
        {
            ground.transform.position = nextPos.position;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(bird != null && !bird.IsDead())
        {
            bird.Dead();
        }
    }
}

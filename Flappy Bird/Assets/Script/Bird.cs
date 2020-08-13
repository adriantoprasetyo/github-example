using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Bird : MonoBehaviour
{
    [SerializeField] private float upForce = 100;
    [SerializeField] private bool isDead;
    [SerializeField] private UnityEvent OnJump, OnDead;
    [SerializeField] private int score;
    [SerializeField] private UnityEvent OnAddPoint;
    [SerializeField] private Text scoreText;
    private Rigidbody2D rigidbody2d;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead && Input.GetMouseButtonDown(0))
        {
            Jump();
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        animator.enabled = false;
    }

    public bool IsDead()
    {
        return isDead;
    }

    public void Dead()
    {
        if (!isDead && OnDead != null)
        {
            OnDead.Invoke();
        }

        isDead = true;
    }

    void Jump()
    {
        if (rigidbody2d)
        {
            rigidbody2d.velocity = Vector2.zero;

            rigidbody2d.AddForce(new Vector2(0, upForce));
        }

        if(OnJump != null)
        {
            OnJump.Invoke();
        }
    }

    public void AddScore(int value)
    {

        //Menambahkan Score value
        score += value;

        //Pengecekan Null Value
        if (OnAddPoint != null)
        {
            //Memanggil semua event pada OnAddPoint
            OnAddPoint.Invoke();

        }

        //Mengubah nilai text pada score text
        scoreText.text = score.ToString();
    }
}

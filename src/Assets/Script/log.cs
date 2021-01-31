using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public enum EnemyState
{
    idle,
    walk
}

public class log : MonoBehaviour
{
    public EnemyState currentState;
    private Rigidbody2D myRigidbody;
    public Transform target;
    public float chaseRadius;
    public float attackRadius;
    private Animator anim;
    public float moveSpeed;

    public GameOver gameOver;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        currentState = EnemyState.idle;
        target = GameObject.FindWithTag("Player").transform;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckDistance();
    }

    void CheckDistance()
    {
        if (Vector3.Distance(target.position,
                             transform.position) <= chaseRadius
            && Vector3.Distance(target.position,
                                transform.position) > attackRadius)
        {
            Vector3 temp = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
            changeAnim(temp - transform.position);
            myRigidbody.MovePosition(temp);
            ChangeState(EnemyState.walk);
            anim.SetBool("wakeUp", true);
        } else if (Vector3.Distance(target.position,
                             transform.position) > chaseRadius)
        {
            ChangeState(EnemyState.idle);
            anim.SetBool("wakeUp", false);
        }
    }

    private void ChangeState(EnemyState newState)
    {
        if (currentState != newState)
            currentState = newState;
    }

    private void SetAnimFloat(Vector2 setVector)
    {
        anim.SetFloat("moveX", setVector.x);
        anim.SetFloat("moveY", setVector.y);
    }

    private void changeAnim(Vector2 direction)
    {
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            if(direction.x > 0)
            {
                SetAnimFloat(Vector2.right);
            }
            else if (direction.x < 0)
            {
                SetAnimFloat(Vector2.left);
            }
        }
        else if(Mathf.Abs(direction.x) < Mathf.Abs(direction.y))
        {
            if (direction.y > 0)
            {
                SetAnimFloat(Vector2.up);
            }
            else if (direction.y < 0)
            {
                SetAnimFloat(Vector2.down);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            gameOver.IsOver = true;
        }
    }

}

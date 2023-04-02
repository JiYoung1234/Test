using UnityEngine;
using System.Collections;


public abstract class MovingObject : MonoBehaviour
{
    public float moveTime = 0.1f;
    public LayerMask blockingLayer;

    private BoxCollider2D boxCollider;
    private Rigidbody2D rb2D; 
    private float inverseMoveTime;

    protected virtual void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        rb2D = GetComponent<Rigidbody2D>();

        inverseMoveTime = 1f / moveTime;
    }


    protected bool Move(int xDir, int yDir, out RaycastHit2D hit)
    {
        //시작점과 끝점 지정
        Vector2 start = transform.position;
        Vector2 end = start + new Vector2(xDir, yDir);

        //충돌체크 비활성화
        boxCollider.enabled = false;

        //끝점까지 안보이는 레이저를 쏜다
        hit = Physics2D.Linecast(start, end, blockingLayer);

        //충돌체크 활성화
        boxCollider.enabled = true;

        //아무것도 없는거 확인하면 이동
        if (hit.transform == null)
        {
            StartCoroutine(SmoothMovement(end));

            return true;
        }

        //이동불가능하면 false 반환
        return false;
    }


    protected IEnumerator SmoothMovement(Vector3 end)
    {
        float sqrRemainingDistance = (transform.position - end).sqrMagnitude;

        Vector3 velocity = Vector3.one;
        float sumTime = 0f;

        //조금 움직이는 척
        while (moveTime > sumTime)
        {
            Vector3 newPostion = Vector3.SmoothDamp(rb2D.position, end, ref velocity, moveTime);
            rb2D.MovePosition(newPostion);

            sumTime += Time.deltaTime;
            yield return null;
        }

        //시간 다되면 도착지로 이동
        rb2D.MovePosition(end);
    }


    protected virtual void AttemptMove<T>(int xDir, int yDir) where T : Component
    {
        //앞에 아무것도 없음
        RaycastHit2D hit;
        bool canMove = Move(xDir, yDir, out hit);
        if (hit.transform == null)
        {
            return;
        }

        //닿은 대상이 원하는(T) 형태인가?
        T hitComponent = hit.transform.GetComponent<T>();
        if (!canMove && hitComponent != null)
            OnCantMove(hitComponent);
    }

    protected abstract void OnCantMove<T>(T component) where T : Component;
}

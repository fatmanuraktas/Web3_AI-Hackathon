using UnityEngine;
using BehaviorTree;

public class TaskPatrol : Node
{
    private Transform transform;
    private Animator animator;
    private Transform[] waypoints;

    private int currentWaypointIndex = 0;

    private float waitTime = .1f; // Saniye cinsinden
    private float waitCounter = 0f;
    private bool isWaiting = true;

    public TaskPatrol(Transform transform, Transform[] waypoints)
    {
        this.transform = transform;
        animator = transform.GetComponent<Animator>();
        this.waypoints = waypoints;
    }

    public override NodeState Evaluate()
    {
        if (isWaiting)
        {
            waitCounter += 5*Time.deltaTime;
            if (waitCounter >= waitTime)
            {
                isWaiting = false;
                animator.SetBool("IsWalking", true);
            }
        }
        else
        {
            Transform wp = waypoints[currentWaypointIndex];

            // Karakterin orijinal Y pozisyonunu muhafaza edelim.
            Vector3 targetPos = wp.position;
            targetPos.y = transform.position.y;

            if (Vector3.Distance(transform.position, targetPos) < 0.01f)
            {
                // Bekleme zamanlayýcýsýný sýfýrla ve rastgele
                // yeni bir bekleme süresi belirle.
                waitTime = Random.Range(3f, 6f);
                waitCounter = 0f;
                isWaiting = true;

                currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
                animator.SetBool("IsWalking", false);
            }
            else
            {
                // Hareketi ve rotasyonu güncelle.
                transform.position = Vector3.MoveTowards(
                    transform.position,
                    targetPos,
                    SlayerBT.walkSpeed * Time.deltaTime
                );

                transform.LookAt(targetPos);
            }
        }

        state = NodeState.RUNNING;
        return state;
    }
}
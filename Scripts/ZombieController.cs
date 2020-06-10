using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class ZombieController : MonoBehaviour
{
    [SerializeField]
    private Transform[] points;
    [SerializeField]

    private float minRemainingDistance = 0.5f;

    private int destinationPoint = 0;

    public float lookRadius = 10f;

    public AudioSource source;

    Transform target;
    NavMeshAgent agent;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        source = GetComponent<AudioSource>();

        GoToNextPoint();
    }

    void GoToNextPoint()
    {
        if (points.Length == 0)
        {
            Debug.LogError("You must setup at least one destination point");
            enabled = false;
            return;
        }

        agent.destination = points[destinationPoint].position;
        destinationPoint = (destinationPoint + 1) % points.Length;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        animator.SetBool("isWalking", true);
        

        if (distance <= lookRadius && distance > 3)
        {
            animator.SetTrigger("run");
            agent.SetDestination(target.position);
        }
        if (distance <= 3)
        {
            StartCoroutine(Attack());
            FaceTarget();
        }
        if (distance > lookRadius && !agent.pathPending && agent.remainingDistance < minRemainingDistance)
        {
            GoToNextPoint();
        }
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    IEnumerator Attack()
    {
        animator.SetTrigger("attack");
        source.Play();
        PlayerStats.instance.GetDamage(0.2f);
        yield return new WaitForSeconds(2f);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}

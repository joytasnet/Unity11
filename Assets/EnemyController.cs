using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public Transform player;
    public float traceDist = 10f;
    NavMeshAgent nav;
    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        StartCoroutine(CheckDist());
    }
    IEnumerator CheckDist() {
        while (true) {
            yield return new WaitForSeconds(0.2f);
            float dist = Vector3.Distance(player.position, transform.position);
            if(dist < traceDist) {
                nav.SetDestination(player.position);
                nav.isStopped = false;
            } else {
                nav.isStopped = true;
            }
        }
    }
}

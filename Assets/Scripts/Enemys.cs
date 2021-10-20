using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if __DEBUG_AVAILABLE__
using UnityEditor;
#endif
public class Enemys : MonoBehaviour
{
    public Transform player;
    public float speed = 2;

    public float followSpeed = 0.2f;
    public float followDistance = 15.0f;

    float distance;

    Vector3 playerOffset;
    Vector3 playerOffsetProjected;
    Vector3 playerOffsetNormalized;
    
    void Start()
    {
        
    }
    #if __DEBUG_AVAILABLE__
    //debug
    private void OnDrawGizmos()
    {
        if (Switches.debugMode && Switches.debgShowIds)
        {
            Handles.Label(transform.position + new Vector3(0, 0.2f, 0), gameObject.name);
        }

        if(Switches.debugMode && Switches.debugShowEnemyFollow)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, followDistance);
            if (distance < followDistance)
            {
                Gizmos.DrawLine(transform.position, transform.position + playerOffset);


                Gizmos.color = Color.green;
                Gizmos.DrawLine(transform.position, transform.position + playerOffsetProjected);
                Gizmos.color = Color.blue;
                Gizmos.DrawLine(transform.position, transform.position + playerOffsetNormalized);

                Handles.Label(transform.position + new Vector3(0, 0.8f, 0), "distance: " + distance);
            }

        }
    }
#endif


    // Update is called once per frame
    void Update()
    {


        transform.position += -Vector3.right * speed * Time.deltaTime;
        if(gameObject.name == "ship07")
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        playerOffset = player.position - transform.position;
        playerOffset = new Vector3(playerOffset.x, playerOffset.y, 0);

        distance = playerOffset.magnitude;

        if (distance < followDistance)
        {

            playerOffsetProjected = new Vector3(0, playerOffset.y, 0);

            playerOffsetNormalized = playerOffset.normalized;

            transform.position += playerOffsetNormalized * followSpeed * Time.deltaTime;
        }
    }
}

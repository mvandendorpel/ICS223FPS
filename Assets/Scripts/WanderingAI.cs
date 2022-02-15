using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum EnemyStates { alive, dead };
public class WanderingAI : MonoBehaviour
{
    private float enemySpeed = 3.0f;
    private float obstacleRange = 5.0f;
    private float sphereRadius = 0.75f;
    private EnemyStates state;
    [SerializeField]
    private GameObject laserBeamPrefab;
    private GameObject laserBeam;
    public float fireRate = 2.0f;
    private float nextFire = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        this.state = EnemyStates.alive;
    }

    // Update is called once per frame
    void Update()
    {
        if (state == EnemyStates.alive)
        {
            // Move Enemy 
            transform.Translate(Vector3.forward * enemySpeed * Time.deltaTime);
            // generate Ray 
            Ray ray = new Ray(transform.position, transform.forward);

            // Spherecast and determine if Enemy needs to turn 
            RaycastHit hit;
            if (Physics.SphereCast(ray, sphereRadius, out hit))
            {
                GameObject hitObject = hit.transform.gameObject;
                if (hitObject.GetComponent<PlayerCharacter>())
                {
                    if (laserBeam == null && Time.time > nextFire)
                    {
                        nextFire = Time.time + fireRate;
                        laserBeam = Instantiate(laserBeamPrefab) as GameObject;
                        laserBeam.transform.position = transform.TransformPoint(0, 1.5f, 1.5f);
                        laserBeam.transform.rotation = transform.rotation;
                    }
                }
                else if (hit.distance < obstacleRange)
                {
                    float turnAngle = Random.Range(-110, 110);
                    transform.Rotate(Vector3.up * turnAngle);
                }
            }
        }
    }

    public void ChangeState(EnemyStates state)
    {
        this.state = state;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Vector3 rangeTest = transform.position + transform.forward * obstacleRange;
        Debug.DrawLine(transform.position, rangeTest);
        Gizmos.DrawWireSphere(rangeTest, sphereRadius);
    }
}

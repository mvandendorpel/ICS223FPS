using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{
    // Start is called before the first frame update
    private bool isAlive = true;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void ReactToHit()
    {
        WanderingAI enemyAI = GetComponent<WanderingAI>();
        if (enemyAI != null && isAlive)
        {
            enemyAI.ChangeState(EnemyStates.dead);
            isAlive = false;
            Messenger.Broadcast(GameEvent.ENEMY_DEAD);
        }
        Animator enemyAnimator = GetComponent<Animator>();
        if (enemyAnimator != null)
        {
            enemyAnimator.SetTrigger("Die");
        }
        //StartCoroutine(Die());
        
    }
 
    private IEnumerator Die()
    {
        

        //iTween.RotateAdd(this.gameObject, new Vector3(-75, 0, 0), 1);

        yield return new WaitForSeconds(3);

        Destroy(this.gameObject);
        

    }
    private void DeadEvent()
    {
        Destroy(this.gameObject);
    }
}

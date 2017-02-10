using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMinionsGeneric : MonoBehaviour
{

    Experience expRef;
    AIController aiController;

    private void Awake()
    {
        expRef = transform.parent.parent.parent.GetComponent<Experience>();
        aiController = transform.parent.parent.parent.GetComponent<AIController>();
    }
    IEnumerator DamageCooldown(Wisp wisp)
    {
        wisp.canBeDamaged = false;
        yield return new WaitForSeconds(0.2f);
        wisp.canBeDamaged = true;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Wisp"))
        {
            //Debug.Log("Çarpışma !");
            Debug.Log("The " + gameObject.transform + " from " + gameObject.transform.parent.parent.parent + " hit " + other.transform.parent.gameObject);

            other.GetComponent<Wisp>().LoseHealth(20);
            StartCoroutine(DamageCooldown(other.GetComponent<Wisp>()));
            if (other.transform.parent.GetComponent<Experience>().level == 1)
            {
                expRef.GainExperience(20);
                aiController.SetScore(aiController.GetScore() + 10);
            }
            else
            {
                //Amount of experience to gain will be decided later
                expRef.GainExperience((other.transform.parent.GetComponent<Experience>().experiencePoints / 10));
                aiController.SetScore(aiController.GetScore() + (int)(other.transform.parent.GetComponent<Experience>().experiencePoints / 10));
            }


        }
    }
}

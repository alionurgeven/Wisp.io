using UnityEngine;
using System.Collections.Generic;


public class MinionController : MonoBehaviour {

    // Variables
    [SerializeField]
    private int childCount = 3;
    [SerializeField]
    public float angle, range;
    [SerializeField]
    List<GameObject> minions = new List<GameObject>();

    // Loading screen initialization
    private void Awake()
    {
        range = 1;
        angle = 360 / childCount;

        for (int i = 0; i < transform.childCount; i++)
        {
            if (i < childCount)
            {
                transform.GetChild(i).gameObject.SetActive(true);
            }
            minions.Add(transform.GetChild(i).gameObject);
        }
    }

    float x, y;
    Vector3 formation;
    public void DetermineFormation(bool fromLevelUp)
    {
        if (fromLevelUp)
        {
            for (int i = 0; i < minions.Count; i++)
            {
                if (transform.rotation.eulerAngles.z < 0)
                {
                    x = Mathf.Sin(Mathf.Deg2Rad * (transform.rotation.eulerAngles.z + (angle * i))) * range;
                    y = Mathf.Cos(Mathf.Deg2Rad * (transform.rotation.eulerAngles.z + (angle * i))) * range;
                }
                else
                {
                    x = Mathf.Sin(Mathf.Deg2Rad * (transform.rotation.eulerAngles.z - (angle * i))) * range;
                    y = Mathf.Cos(Mathf.Deg2Rad * (transform.rotation.eulerAngles.z - (angle * i))) * range;
                }
                formation = Vector2.right * x + Vector2.up * y;
                minions[i].transform.position = transform.position + formation;
            }
        }
        else
        {
            for (int i = 0; i < minions.Count; i++)
            {
                x = Mathf.Sin(Mathf.Deg2Rad * angle * i) * range;
                y = Mathf.Cos(Mathf.Deg2Rad * angle * i) * range;
                formation = Vector2.right * x + Vector2.up * y;
                minions[i].transform.position = transform.position + formation;
            }
        }
    }
    
    void Start()
    {
        DetermineFormation(false);
    }

    // for rotateAround
    Vector3 rotationMask = new Vector3(0, 0, 1);
    private void LateUpdate()
    {
        transform.RotateAround(transform.parent.position, -rotationMask, 90.0f * Time.deltaTime);
    }
}

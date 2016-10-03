using UnityEngine;

public class SphereCloudGenerator : MonoBehaviour
{
    public GameObject obj;

    public float distance = 1.0f;

    public int count = 10;

    Vector3 movingSpawnPoint;

    GameObject objOfInterest;

    public bool randomizeScale = false;
    public float min;
    public float max;

    // Use this for initialization
    void Start()
    {
        objOfInterest = this.gameObject;

        for (int i = 0; i < count;)
        {
            movingSpawnPoint = (objOfInterest.transform.position + (Random.insideUnitSphere * objOfInterest.transform.localScale.x));

            if (Vector3.Distance(objOfInterest.transform.position, movingSpawnPoint) > distance)
            {
                var _obj = Instantiate(obj, movingSpawnPoint, Quaternion.identity) as GameObject;

                if(randomizeScale)
                {
                    var rand = Random.Range(min, max);

                    _obj.transform.localScale = new Vector3(rand, rand, rand);
                }

                _obj.transform.parent = this.transform;

                objOfInterest = transform.GetChild(i).gameObject;

                i++;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

}

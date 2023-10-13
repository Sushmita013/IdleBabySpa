using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchMaker : MonoBehaviour
{
    public static MatchMaker instance;
    public List<GameObject> placedObject = new List<GameObject>();
    public List<GameObject> collectedObjects = new List<GameObject>();

    public GameObject pointA;
    public GameObject pointB;

    public GameObject toys;
     
    void Start()
    {
        instance = this;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(placedObject.Count == 0)
        {
            other.gameObject.transform.position = pointA.transform.position;
            other.gameObject.transform.rotation = pointA.transform.rotation;
            //other.gameObject.GetComponent<Rigidbody>().useGravity = false;
            placedObject.Add(other.gameObject);
            collectedObjects.Add(other.gameObject);
            placedObject[0].transform.parent = null; 
        }
        else if (other.gameObject.transform.name.Contains(placedObject[0].name))
        {
            //other.gameObject.GetComponent<Collider>().enabled = false;
            //placedObject[0].gameObject.GetComponent<Collider>().enabled = false; 
            Debug.Log("Matched objects");
            collectedObjects.Add(other.gameObject); 
            Destroy(other.gameObject.GetComponent<Rigidbody>());
            Destroy(placedObject[0].gameObject.GetComponent<Rigidbody>());
            other.transform.parent = null;
            other.gameObject.transform.position = pointB.transform.position;
            placedObject[0].gameObject.transform.position = pointB.transform.position;
            other.gameObject.transform.rotation = pointB.transform.rotation;
            placedObject[0].gameObject.transform.rotation = pointB.transform.rotation;
            //Destroy(placedObject[0].gameObject);
            placedObject.Clear(); 
        }
        else
        {
            Debug.Log("wrong objects");

            //other.gameObject.GetComponent<Rigidbody>().useGravity = true; 
            //placedObject[0].gameObject.GetComponent<Rigidbody>().useGravity = true;
            //other.GetComponent<Rigidbody>().velocity = new Vector3(0, 1, 1) * 120 * Time.deltaTime;
            other.GetComponent<Rigidbody>().AddForce(new Vector3(0,10, 0), ForceMode.Impulse);
            //placedObject[0].GetComponent<Rigidbody>().AddForce(new Vector3(0,10, 0), ForceMode.Impulse); 
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (placedObject.Contains(other.gameObject))
        {
            placedObject.Remove(other.gameObject);
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public GameObject pooledObject;
    public int pooledAmount;

    List<GameObject> pooledObjects;
    
    // Start is called before the first frame update
    void Start()
    {
        pooledObjects = new List<GameObject>();

        for(int i = 0; i<pooledAmount; i++)
        {
            GameObject obj = (GameObject)Instantiate(pooledObject); //creating new Object
            obj.SetActive(false); //deactivating created Object
            pooledObjects.Add(obj); //inserting created Object in list
        }
    }


    public GameObject GetPooledObject()
    {
        for(int i = 0; i<pooledObjects.Count; i++)
        {
            if(!pooledObjects[i].activeInHierarchy) //if the object is currently not active in the szene
            {
                return pooledObjects[i];
            }
        }

        GameObject obj = (GameObject)Instantiate(pooledObject);
        obj.SetActive(false); 
        pooledObjects.Add(obj);
        return obj;
    }


}

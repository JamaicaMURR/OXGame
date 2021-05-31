using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DynamicPopUpSpawner : MonoBehaviour
{
    public GameObject popupPrefab;
    public Transform anchorTransform;

    public void Pop(string message, Transform t)
    {
        transform.position = t.position;

        GameObject newbie = Instantiate(popupPrefab, anchorTransform);

        newbie.GetComponent<Transform>().position = transform.position;
        newbie.GetComponent<Text>().text = message;
        newbie.GetComponent<Pop>().BeginEvaporating();
    }
}

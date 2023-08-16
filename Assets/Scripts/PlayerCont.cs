using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable IDE0051, IDE0060
public class PlayerCont : MonoBehaviour
{
    public float speed;
    public float normalSpeed = 2.5f;

    float xclampl, xclampr;


    public GameManager manager;
    public GameObject right, left, big;
    public List<GameObject> collectedStuff;

    void Start()
    {
        right.GetComponent<Animator>().keepAnimatorStateOnDisable = true;
        left.GetComponent<Animator>().keepAnimatorStateOnDisable = true;
        big.GetComponent<Animator>().keepAnimatorStateOnDisable = true;
        speed = normalSpeed;
        big.SetActive(false);
    }

    void Update()
    {
        Move();
    }
    void Move()
    {
        if (manager.isStarted)
        {
            transform.position += new Vector3(0, 0, speed * Time.deltaTime);
        }
    }
    public void CollectProcess(GameObject other)
    {
        collectedStuff.Add(other.gameObject);
    }

    public void LoseCollectable(GameObject other)
    {
        collectedStuff.Remove(other.gameObject);
        Destroy(other.gameObject);
    }

    public void StartAll()
    {
        right.GetComponent<Animator>().SetBool("_isRunning", true);
        left.GetComponent<Animator>().SetBool("_isRunning", true);
        big.GetComponent<Animator>().SetBool("_isRunning", true);
    }
    public void StopAll()
    {
        right.GetComponent<Animator>().SetBool("_isRunning", false);
        left.GetComponent<Animator>().SetBool("_isRunning", false);
        big.GetComponent<Animator>().SetBool("_isRunning", false);
    }

    public void LeftRight(float datax)
    {
        left.transform.localPosition += new Vector3(datax * Time.deltaTime, 0, 0);
        xclampl = Mathf.Clamp(left.transform.localPosition.x, -3.5f, 0);
        left.transform.localPosition = new Vector3(xclampl, left.transform.localPosition.y, left.transform.localPosition.z);

        right.transform.localPosition -= new Vector3(datax * Time.deltaTime, 0, 0);
        xclampr = Mathf.Clamp(right.transform.localPosition.x, 0, 3.5f);
        right.transform.localPosition = new Vector3(xclampr, right.transform.localPosition.y, right.transform.localPosition.z);
    }
}

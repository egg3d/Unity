using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UgokuYuka : MonoBehaviour
{
    public bool forward;
    public bool back;
    public bool right;
    public bool left;
    public bool up;
    public bool down;
    public bool notParent;
    bool re;
    bool stop;
    Vector3 StartPos;
    float count;
    public float value;
    public float speed;
    void Awake()
    {
        StartPos = transform.position;
        print(StartPos);
    }
    void Update()
    {
        // count = count + 1;
        //transform.Translate(-z, y, x);
        if (forward)
        {
            if (!stop)
            {
                if (re)
                    transform.Translate(speed, 0, 0);

                else
                    transform.Translate(-speed, 0, 0);

            }
            if (transform.position.z >= StartPos.z + value)
            {
                stop = true;
                StartCoroutine("Re");
            }


            if (transform.position.z <= StartPos.z)
            {
                stop = true;
                StartCoroutine("NotRe");
            }

        }
        if (back)
        {
            if (!stop)
            {
                if (re)
                    transform.Translate(-speed, 0, 0);

                else
                    transform.Translate(speed, 0, 0);

            }
            if (transform.position.z <= StartPos.z - value)
            {
                stop = true;
                StartCoroutine("Re");
            }

            if (transform.position.z >= StartPos.z)
            {
                stop = true;
                StartCoroutine("NotRe");
            }
        }
        if (right)
        {
            if (!stop)
            {
                if (re)
                    transform.Translate(0, 0, -speed);

                else
                    transform.Translate(0, 0, speed);

            }
            if (transform.position.x >= StartPos.x + value)
            {
                stop = true;
                StartCoroutine("Re");
            }
            if (transform.position.x <= StartPos.x)
            {
                stop = true;
                StartCoroutine("NotRe");
            }
        }
        if (left)
        {
            if (!stop)
            {
                if (re)
                    transform.Translate(0, 0, speed);

                else
                    transform.Translate(0, 0, -speed);

            }
            if (transform.position.x <= StartPos.x - value)
            {
                stop = true;
                StartCoroutine("Re");
            }
            if (transform.position.x >= StartPos.x)
            {
                stop = true;
                StartCoroutine("NotRe");
            }
        }
        if (up)
        {
            if (!stop)
            {
                if (re)
                    transform.Translate(0, 0, speed);

                else
                    transform.Translate(0, 0, -speed);

            }
            if (transform.position.x <= StartPos.x - value)
            {
                stop = true;
                StartCoroutine("Re");
            }
            if (transform.position.x >= StartPos.x)
            {
                stop = true;
                StartCoroutine("NotRe");
            }
        }
        if (down)
        {
            if (!stop)
            {
                if (re)
                    transform.Translate(0, speed, 0);

                else
                    transform.Translate(0, -speed, 0);

            }
            if (transform.position.y <= StartPos.y - value)
            {
                stop = true;
                StartCoroutine("Re");
            }
            if (transform.position.y >= StartPos.y)
            {
                stop = true;
                StartCoroutine("NotRe");
            }
        }
    }
    IEnumerator Re()
    {

        yield return new WaitForSeconds(0.5f);
        re = true;
        stop = false;

    }
    IEnumerator NotRe()
    {

        yield return new WaitForSeconds(0.5f);
        re = false;
        stop = false;

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (notParent)
        {
            collision.gameObject.transform.SetParent(this.transform);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (notParent)
        {
            collision.gameObject.transform.SetParent(null);

        }
    }
    void OnTriggerEnter(Collider other)
        {
            if (notParent)
            {
                other.gameObject.transform.SetParent(this.transform);

            }
        }
    void OnTriggerExit(Collider other)
            {
                if (notParent)
                {
                    other.gameObject.transform.SetParent(null);
                }
            }
}

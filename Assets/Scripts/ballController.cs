using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballController : MonoBehaviour
{
    public AgentBowling Agent;
    public GameObject area;
    [HideInInspector]
    public ballEnvController envController;

    void Start()
    {
        envController = area.GetComponent<ballEnvController>();
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.CompareTag("pin1Goal"))
        {
            Agent.PinTouched();
        }

        if (col.gameObject.CompareTag("pin2Goal"))
        {
            Agent.PinTouched();
        }

        if (col.gameObject.CompareTag("pin3Goal"))
        {
           Agent.PinTouched();
        }

        if (col.gameObject.CompareTag("pin4Goal"))
        {
           Agent.PinTouched();
        }

        if (col.gameObject.CompareTag("pin4Goal"))
        {
            Agent.PinTouched();
        }

        if (col.gameObject.CompareTag("pin5Goal"))
        {
            Agent.PinTouched();
        }

        if (col.gameObject.CompareTag("pin6Goal"))
        {
           Agent.PinTouched();
        }

        if (col.gameObject.CompareTag("pin7Goal"))
        {
           Agent.PinTouched();
        }

        if (col.gameObject.CompareTag("pin8Goal"))
        {
           Agent.PinTouched();
        }

        if (col.gameObject.CompareTag("pin9Goal"))
        {
           Agent.PinTouched();
        }
        if (col.gameObject.CompareTag("pin10Goal"))
        {
           Agent.PinTouched();
        }
    }
}

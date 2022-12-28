using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Policies;
using Unity.MLAgents;


public enum Team
{
  Blue = 0
}
public class AgentBowling : Agent
{
    [HideInInspector]
    public Team team;
    float m_KickPower;
    const float k_Power = 2000f;
    float m_ForwardSpeed;
    float m_LateralSpeed;

    [HideInInspector]
    public Rigidbody agentRb;
    ballSettings m_ballSettings;
    BehaviorParameters m_BehaviorParameters;
    public Vector3 initialPos;
    public float rotSign;
    [HideInInspector]
    public ballEnvController envController;

    EnvironmentParameters m_ResetParams;

    public override void Initialize()
    {
        ballEnvController envController = GetComponentInParent<ballEnvController>();


        m_BehaviorParameters = gameObject.GetComponent<BehaviorParameters>();
        if (m_BehaviorParameters.TeamId == (int)Team.Blue)
        {
          team = Team.Blue;
            initialPos = new Vector3(transform.position.x , transform.position.y, transform.position.z);
            rotSign = 1f;
        }
        
        m_ForwardSpeed = 1.0f;
        m_LateralSpeed = 0.3f;
        m_ballSettings = FindObjectOfType<ballSettings>();
        agentRb = GetComponent<Rigidbody>();
        agentRb.maxAngularVelocity = 500;

        m_ResetParams = Academy.Instance.EnvironmentParameters;
    }

    public void MoveAgent(ActionSegment<int> act)
    {
        var dirToGo = Vector3.zero;
        var rotateDir = Vector3.zero;

        m_KickPower = 0f;

        var forwardAxis = act[0];
        var rightAxis = act[1];
        var rotateAxis = act[2];

        switch (forwardAxis)
        {
          case 1:
            dirToGo = transform.forward*m_ForwardSpeed;
            m_KickPower = 50f;
            break;
          case 2:
            dirToGo = transform.forward*-m_ForwardSpeed;
            break;
        }

        switch (rightAxis)
        {
          case 1:
            dirToGo = transform.right*m_LateralSpeed;
            break;
          case 2:
            dirToGo = transform.right*-m_ForwardSpeed;
            break;
        }

        switch (rotateAxis)
        {
          case 1:
            rotateDir = transform.up * -1f;
            break;
          case 2:
            rotateDir = transform.up * 1f;
            break;
        }

        transform.Rotate(rotateDir,Time.deltaTime * 100f);
        agentRb.AddForce(dirToGo*4,ForceMode.VelocityChange);

        if(agentRb.transform.position.z>=-6f)
        {
          AddReward(-1f);
        }

    }

    public override void OnActionReceived(ActionBuffers actionBuffers)  
    {
      MoveAgent(actionBuffers.DiscreteActions);
    }

    public override void Heuristic(in ActionBuffers actionOut)
    {
      var discreteActionsOut = actionOut.DiscreteActions;
      //forward
      if(Input.GetKey(KeyCode.W))
      {
        discreteActionsOut[0] = 1;
      }
      if(Input.GetKey(KeyCode.S))
      {
        discreteActionsOut[0] = 2;
      }
      //rotate
      if(Input.GetKey(KeyCode.A))
      {
        discreteActionsOut[2] = 1;
      }
      if(Input.GetKey(KeyCode.D))
      {
        discreteActionsOut[2] = 2;
      }
      //right
      if(Input.GetKey(KeyCode.E))
      {
        discreteActionsOut[1] = 1;
      }
      if(Input.GetKey(KeyCode.W))
      {
        discreteActionsOut[1] = 2;
      }
      
    }
    public void PinTouched()
    {
      AddReward(10f);
    }
    public void Wrong()
    {
      AddReward(-100f);
    }
    void OnCollisionEnter(Collision c)
    {
        var force = k_Power * m_KickPower;
        if (c.gameObject.CompareTag("ball"))
        {
            AddReward(10f);
            var dir = c.contacts[0].point - transform.position;
            dir = dir.normalized;
            c.gameObject.GetComponent<Rigidbody>().AddForce(dir * force);
        }

        if(c.gameObject.CompareTag("pin1Goal"))
        {
            AddReward(-100f);
        }

        if (c.gameObject.CompareTag("pin2Goal"))
        {
            AddReward(-100f);
        }

        if (c.gameObject.CompareTag("pin3Goal"))
        {
            AddReward(-100f);
        }

        if (c.gameObject.CompareTag("pin4Goal"))
        {
            AddReward(-100f);
        }

        if (c.gameObject.CompareTag("pin5Goal"))
        {
            AddReward(-100f);
        }

        if (c.gameObject.CompareTag("pin6Goal"))
        {
            AddReward(-100f);
        }

        if (c.gameObject.CompareTag("pin7Goal"))
        {
            AddReward(-100f);
        }

        if (c.gameObject.CompareTag("pin8Goal"))
        {
            AddReward(-100f);
        }

        if (c.gameObject.CompareTag("pin9Goal"))
        {
            AddReward(-100f);
        }

        if (c.gameObject.CompareTag("pin10Goal"))
        {
            AddReward(-100f);
        }
    }

}

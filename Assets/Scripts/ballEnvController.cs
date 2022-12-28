using JetBrains.Rider.Unity.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Palmmedia.ReportGenerator.Core.Reporting.Builders;
using static UnityEditor.Progress;


public class ballEnvController : MonoBehaviour
{
    [System.Serializable]
    public class PlayerInfo
    {
        public AgentBowling Agent;
        [HideInInspector]
        public Vector3 StartingPos;
        [HideInInspector]
        public Quaternion StartingRot;
        [HideInInspector]
        public Rigidbody Rb;
    }

    [Tooltip("Max Environment Steps")] public int MaxEnvironmentSteps;

    public GameObject ball;
    [HideInInspector]
    public Rigidbody ballRb;
    Vector3 m_BallStartingPos;

    public PlayerInfo agent;

    public GameObject pin;
    Vector3 m_PinStartingPos;

    public GameObject pin1;
    public GameObject pin2;
    public GameObject pin3;
    public GameObject pin4;
    public GameObject pin5;
    public GameObject pin6;
    public GameObject pin7;
    public GameObject pin8;
    public GameObject pin9;
    public GameObject pin10;
    
    [HideInInspector]
    public Rigidbody pin1Rb;
    [HideInInspector]
    public Rigidbody pin2Rb;
    [HideInInspector]
    public Rigidbody pin3Rb;
    [HideInInspector]
    public Rigidbody pin4Rb;
    [HideInInspector]
    public Rigidbody pin5Rb;
    [HideInInspector]
    public Rigidbody pin6Rb;
    [HideInInspector]
    public Rigidbody pin7Rb;
    [HideInInspector]
    public Rigidbody pin8Rb;
    [HideInInspector]
    public Rigidbody pin9Rb;
    [HideInInspector]
    public Rigidbody pin10Rb;

    private ballSettings m_ballSettings;

    private SimpleMultiAgentGroup m_BlueAgentGroup;

    private int m_ResetTimer;

    void Start()
    {
        m_ballSettings = FindObjectOfType<ballSettings>();

        //Initialize TeamManager
        m_BlueAgentGroup = new SimpleMultiAgentGroup();

        ballRb = ball.GetComponent<Rigidbody>();
        m_BallStartingPos = new Vector3(ball.transform.position.x, ball.transform.position.y, ball.transform.position.z);
        
        pin1Rb = pin1.GetComponent<Rigidbody>();
        pin2Rb = pin2.GetComponent<Rigidbody>();
        pin3Rb = pin3.GetComponent<Rigidbody>();
        pin4Rb = pin4.GetComponent<Rigidbody>();
        pin5Rb = pin5.GetComponent<Rigidbody>();
        pin6Rb = pin6.GetComponent<Rigidbody>();
        pin7Rb = pin7.GetComponent<Rigidbody>();
        pin8Rb = pin8.GetComponent<Rigidbody>();
        pin9Rb = pin9.GetComponent<Rigidbody>();
        pin10Rb = pin10.GetComponent<Rigidbody>();
        m_PinStartingPos = new Vector3(pin.transform.position.x, pin.transform.position.y, pin.transform.position.z);

        agent.StartingPos = agent.Agent.transform.position;
        agent.StartingRot = agent.Agent.transform.rotation;
        agent.Rb = agent.Agent.GetComponent<Rigidbody>();
        m_BlueAgentGroup.RegisterAgent(agent.Agent);
        ResetScene();
    }

    void FixedUpdate()
    {
        m_ResetTimer += 1;
        if (m_ResetTimer >= MaxEnvironmentSteps && MaxEnvironmentSteps > 0)
        {
            m_BlueAgentGroup.GroupEpisodeInterrupted();
            ResetScene();
        }
    }

    public void ResetBall()
    {
        var randomPosX = Random.Range(-1f, 1f);

        ball.transform.position = m_BallStartingPos + new Vector3(randomPosX, 0f, 0f);
        ballRb.velocity = Vector3.zero;
        ballRb.angularVelocity = Vector3.zero;
    }

    public void ResetPins()
    {
        print("resetPins");
        pin1.transform.position = m_PinStartingPos + new Vector3(0f, 0f, 0f);
        pin1.transform.rotation = Quaternion.Euler(0,90,-90);

        pin2.transform.position = m_PinStartingPos + new Vector3(-0.3f, 0f, 0.6f);
        pin2.transform.rotation = Quaternion.Euler(0, 90, -90);

        pin3.transform.position = m_PinStartingPos + new Vector3(0.3f, 0f, 0.6f);
        pin3.transform.rotation = Quaternion.Euler(0, 90, -90);

        pin4.transform.position = m_PinStartingPos + new Vector3(-0.6f, 0f, 1.2f);
        pin4.transform.rotation = Quaternion.Euler(0, 90, -90);

        pin5.transform.position = m_PinStartingPos + new Vector3(0f, 0f, 1.2f);
        pin5.transform.rotation = Quaternion.Euler(0, 90, -90);

        pin6.transform.position = m_PinStartingPos + new Vector3(0.6f, 0f, 1.2f);
        pin6.transform.rotation = Quaternion.Euler(0, 90, -90);

        pin7.transform.position = m_PinStartingPos + new Vector3(-0.9f, 0f, 1.8f);
        pin7.transform.rotation = Quaternion.Euler(0, 90, -90);

        pin8.transform.position = m_PinStartingPos + new Vector3(-0.3f, 0f, 1.8f);
        pin8.transform.rotation = Quaternion.Euler(0, 90, -90);

        pin9.transform.position = m_PinStartingPos + new Vector3(0.3f, 0f, 1.8f);
        pin9.transform.rotation = Quaternion.Euler(0, 90, -90);

        pin10.transform.position = m_PinStartingPos + new Vector3(0.9f, 0f, 1.8f);
        pin10.transform.rotation = Quaternion.Euler(0, 90, -90);
    }
    public void ResetScene()
    {
        m_ResetTimer= 0;

        //Reset Agents
        var randomPosX = Random.Range(-1f,0.64f);
        var randomPosZ = Random.Range(-1.5f, 2.5f);
        var newStartPos = agent.Agent.initialPos + new Vector3(randomPosX, 0f, randomPosZ);
        var rot = agent.Agent.rotSign * Random.Range(80.0f, 100.0f);
        var newRot = Quaternion.Euler(0, rot, 0);
        agent.Rb.velocity = Vector3.zero;
        agent.Rb.angularVelocity = Vector3.zero;
        agent.Agent.transform.SetPositionAndRotation(newStartPos, newRot);

        ResetBall();
        ResetPins();
    }
}

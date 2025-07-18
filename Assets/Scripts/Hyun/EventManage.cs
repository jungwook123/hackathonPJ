using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EventManage : MonoBehaviour
{
    public GameObject onRunning_Ui;
    public GameObject onGoing_Ui;

    public List<GameObject> banks;
    public List<GameObject> portals;

    private void Start()
    {
        int randomBankIndex = Random.Range(0, banks.Count);
        for (int i = 0; i < banks.Count; i++)
        {
            banks[i].SetActive(i == randomBankIndex);
        }

        int randomPortalIndex = Random.Range(0, portals.Count);
        for (int i = 0; i < portals.Count; i++)
        {
            portals[i].SetActive(i == randomPortalIndex);
        }

        if (GameManager.Instance.gameState == GameState.Ongoing)
        {
            onRunning_Ui.SetActive(true);
            onGoing_Ui.SetActive(false);
        }
        else
        {
            onGoing_Ui.SetActive(true);
            onRunning_Ui.SetActive(false);

            
        }
    }
}

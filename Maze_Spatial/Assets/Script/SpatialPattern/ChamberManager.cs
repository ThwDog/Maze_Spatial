using System.Collections;
using System.Collections.Generic;
using AYellowpaper;
using UnityEngine;

public class ChamberManager : MonoBehaviour
{
    [Header("Trigger Enter")]
    [SerializeField] List<InterfaceReference<Activate, MonoBehaviour>> enter_activateObj;
    [SerializeField] List<InterfaceReference<DeActivate, MonoBehaviour>> enter_DeactivateObj;

    [Header("Trigger stay")]
    [SerializeField] List<InterfaceReference<Activate, MonoBehaviour>> stay_activateObj;
    [SerializeField] List<InterfaceReference<DeActivate, MonoBehaviour>> stay_DeactivateObj;

    [Header("Trigger Exit")]
    [SerializeField] List<InterfaceReference<Activate, MonoBehaviour>> exit_activateObj;
    [SerializeField] List<InterfaceReference<DeActivate, MonoBehaviour>> exit_DeactivateObj;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            loopActivate(enter_activateObj);
            loopDeactivate(enter_DeactivateObj);
        }
    }

    private void OnTriggerStay(Collider other) 
    {
        if (other.CompareTag("Player"))
        {
            loopActivate(stay_activateObj);
            loopDeactivate(stay_DeactivateObj);
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if (other.CompareTag("Player"))
        {
            loopActivate(exit_activateObj);
            loopDeactivate(exit_DeactivateObj);
        }
    }

    private void loopActivate(List<InterfaceReference<Activate, MonoBehaviour>> activeObj)
    {
        if(activeObj == null)
            return;
        for (int i = 0; i < activeObj.Count; i++)
        {
            activeObj[i].Value.Activate();
        }
    }

    private void loopDeactivate(List<InterfaceReference<DeActivate, MonoBehaviour>> deActiveObj)
    {
        if(deActiveObj == null)
            return;
        for (int i = 0; i < deActiveObj.Count; i++)
        {
            deActiveObj[i].Value.DeActivate();
        }
    }
}

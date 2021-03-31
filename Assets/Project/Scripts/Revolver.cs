using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class Revolver : MonoBehaviour
{
    [SerializeField]
    private SteamVR_Action_Boolean _shootAction;

    [SerializeField]
    private MeshRenderer _meshRenderer;
    [SerializeField]
    private Material _shootingMaterial;

    private Material _baseMaterial;
    private Interactable _interactable;


    private void Start()
    {
        _baseMaterial = _meshRenderer.material;
        _interactable = GetComponent<Interactable>();
    }

    private void Update()
    {
        if (_interactable.attachedToHand != null)
        {
            SteamVR_Input_Sources inputSource = _interactable.attachedToHand.handType;

            if (_shootAction[inputSource].stateDown)
                StartShooting();
            else if (_shootAction[inputSource].stateUp)
                StopShooting();
        }
    }

    private void StartShooting()
    {
        _meshRenderer.material = _shootingMaterial;
        print("Start shooting");
    }

    private void StopShooting()
    {
        _meshRenderer.material = _baseMaterial;
        print("Start shooting");
    }
}

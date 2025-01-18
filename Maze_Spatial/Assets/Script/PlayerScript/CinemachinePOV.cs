using UnityEngine;
using Cinemachine;
using UnityEngine.AI;

public class CinemachinePOV : CinemachineExtension
{
    [Header("setting")]
    [SerializeField] private float horiSpeed = 10f;
    [SerializeField] private float vertiSpeed = 10f;
    [SerializeField] private float clampAngle = 80f;

    public InputManager input;
    private Vector3 startRotation;

    protected override void Awake() 
    {
        base.Awake();    
    }

    protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam, CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    {
        if(vcam.Follow)
        {
            if(stage == CinemachineCore.Stage.Aim)
            {
                if(startRotation == null)
                    startRotation = transform.localRotation.eulerAngles;
                Vector2 deltaInput = input.GetMouseDelta();
                startRotation.x += deltaInput.x * vertiSpeed * Time.deltaTime;     
                startRotation.y += deltaInput.y * horiSpeed * Time.deltaTime;     

                startRotation.y = Mathf.Clamp(startRotation.y, -clampAngle, clampAngle);
                state.RawOrientation = Quaternion.Euler(-startRotation.y,startRotation.x,0f);
            }
        }
    }
}

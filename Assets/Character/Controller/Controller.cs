using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using Random = UnityEngine.Random;

public class Controller : MonoBehaviour
{
    [SerializeField] private Camera m_Camera;
    [SerializeField] private float speed = 2.5f;
    [SerializeField] private MouseLook m_MouseLook;
    [SerializeField] private AudioClip[] m_FootstepSounds;
    private float m_RunstepLenghten = 0.593f;
    [SerializeField] private float m_StepInterval = 7;
    [SerializeField] AudioSource m_AudioSource;
     private bool m_IsWalking;
     private float m_GravityMultiplier = 2;
     private float fatigue = 0.0f; 
     private float fatigueIncreaseRate = 25f; 
     private float fatigueDecreaseRate = 25f; 
     private bool tired = false;

    private CharacterController m_CharacterController;
    private CollisionFlags m_CollisionFlags;
    private Vector3 m_MoveDir = Vector3.zero;
    private Vector2 m_Input;
    
    private float m_StepCycle;
    private float m_NextStep;
    private bool m_PreviouslyGrounded;
    private bool pressedshift;
    



    private void Start()
    {
        m_CharacterController = gameObject.GetComponent<CharacterController>();
        m_MouseLook.Init(transform , m_Camera.transform);
    }

    private void Update()
{
    if (!m_CharacterController.isGrounded)
    {
        m_MoveDir += Physics.gravity * m_GravityMultiplier * Time.deltaTime;
    }
    
    RotateView();
    
    
    float horizontalInput = Input.GetAxis("Horizontal");
    float verticalInput = Input.GetAxis("Vertical");
    m_Input = new Vector2(horizontalInput, verticalInput);
    if (m_Input.sqrMagnitude > 1)
    {
        m_Input.Normalize();
    }
    
    Vector3 desiredMove = transform.forward * m_Input.y + transform.right * m_Input.x;
    RaycastHit hitInfo;
    Physics.SphereCast(transform.position, m_CharacterController.radius, Vector3.down, out hitInfo,
                       m_CharacterController.height / 2f, Physics.AllLayers, QueryTriggerInteraction.Ignore);
    desiredMove = Vector3.ProjectOnPlane(desiredMove, hitInfo.normal).normalized;
    m_MoveDir.x = desiredMove.x * speed;
    m_MoveDir.z = desiredMove.z * speed;

    
    m_CollisionFlags = m_CharacterController.Move(m_MoveDir * Time.deltaTime);
    
    ProgressStepCycle(speed);
    
    m_IsWalking = m_MoveDir != Vector3.zero;

    
    bool isRunning = Input.GetKey(KeyCode.LeftShift);
    if (isRunning && m_IsWalking && !tired)
    {
        speed = 5f; 
        fatigue += fatigueIncreaseRate * Time.deltaTime;
        if (fatigue >= 100f)
        {
            tired = true;
            fatigue = 100f; 
        }
    }
    else
    {
        speed = 2.5f; 
        fatigue -= fatigueDecreaseRate * Time.deltaTime;
        if (fatigue <= 0f)
        {
            tired = false;
            fatigue = 0f; 
        }
    }

    fatigue = Mathf.Clamp(fatigue, 0.0f, 100.0f); 
}

private void FixedUpdate()
{
    m_MouseLook.UpdateCursorLock();
}

private void RotateView()
{
    m_MouseLook.LookRotation(transform, m_Camera.transform);
}

private void PlayFootStepAudio()
{
    int n = Random.Range(1, m_FootstepSounds.Length);
    m_AudioSource.clip = m_FootstepSounds[n];
    m_AudioSource.PlayOneShot(m_AudioSource.clip);
    m_FootstepSounds[n] = m_FootstepSounds[0];
    m_FootstepSounds[0] = m_AudioSource.clip;
}

private void ProgressStepCycle(float speed)
{
    if (m_CharacterController.velocity.sqrMagnitude > 0 && (m_Input.x != 0 || m_Input.y != 0))
    {
        m_StepCycle += (m_CharacterController.velocity.magnitude + (speed * (m_IsWalking ? 1f : m_RunstepLenghten))) * Time.deltaTime;
    }

    if (!(m_StepCycle > m_NextStep))
    {
        return;
    }

    m_NextStep = m_StepCycle + m_StepInterval;
    PlayFootStepAudio();
}
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody body = hit.collider.attachedRigidbody;
        if (m_CollisionFlags == CollisionFlags.Below)
        {
            return;
        }
        if (body == null || body.isKinematic)
        {
            return;
        }
        body.AddForceAtPosition(m_CharacterController.velocity*0.1f, hit.point, ForceMode.Impulse);
    }
}

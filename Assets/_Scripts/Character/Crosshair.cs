using UnityEngine;
using UnityEngine.InputSystem;

 public class Crosshair : MonoBehaviour
 {
     public Vector2 mousePos { get; private set; }
     public Vector2 mouseSensitivity = Vector2.zero;    

     [SerializeField, Range(0.0f,1.0f)]
     private float xConstraint; 
 
     [SerializeField, Range(0.0f,1.0f)]
     private float yConstraint; 

     private float horizontalConstraint;
     private float verticalConstraint;
 
     private Vector2 startPos;
 
     private Vector2 lookDelta = Vector2.zero;

     private float minXConstraint;
     private float maxXConstraint;
 
     private float minYConstraint;
     private float maxYConstraint;

     private GameInputActions inputActions;

     private void Awake()
     {
         inputActions = new GameInputActions();
     }

     private void Start()
     {
         if (GameManager.instance.isCursorActive)
             AppEvents.Invoke_MouseCursorEnable(false);

         startPos = new Vector2(Screen.width / 2f, Screen.height / 2f);

         horizontalConstraint = (Screen.width * xConstraint) / 2f;
         minXConstraint = -(Screen.width / 2) + horizontalConstraint;
         maxXConstraint = (Screen.width / 2) - horizontalConstraint;

         verticalConstraint = (Screen.height * yConstraint) * 2f;
         minYConstraint = -(Screen.height / 2f) + verticalConstraint;
         maxYConstraint = (Screen.height / 2f) - verticalConstraint;
     }

     // Update is called once per frame
     private void Update()
     {
         float crosshairXPosition = startPos.x + lookDelta.x;
        float crosshairYPosition = startPos.y + lookDelta.y;
         mousePos = new Vector2(crosshairXPosition, crosshairYPosition);
         transform.position = mousePos;
     }
 
     private void OnLook(InputAction.CallbackContext delta)
     {
         Vector2 mouseDelta = delta.ReadValue<Vector2>();
         lookDelta.x += mouseDelta.x * mouseSensitivity.x;
         if (lookDelta.x >= maxXConstraint || lookDelta.x <= minXConstraint)
         {
             lookDelta.x -= mouseDelta.x * mouseSensitivity.x;
         }

         lookDelta.y += mouseDelta.y * mouseSensitivity.y;
         if (lookDelta.y >= maxYConstraint || lookDelta.y <= minYConstraint)
         {
             lookDelta.y -= mouseDelta.y * mouseSensitivity.y;
         }
     }

     private void OnEnable()
     {
         inputActions.Enable();
         inputActions.ThirdPerson.Look.performed += OnLook;
     }
 
     private void OnDisable()
     {
         inputActions.Disable();
         inputActions.ThirdPerson.Look.performed -= OnLook;
     }
 }

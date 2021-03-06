using UnityEngine;
using UnityEngine.InputSystem;

    public class CameraController : MonoBehaviour
    {
        [SerializeField] 
        GameObject followTarget;
        [SerializeField] 
        float rotationSpeed = 1f;
        [SerializeField] 
        float horizontalDamping = 1f;

        Transform followTargetTransform;
        Vector2 prevMouseInput;

        // Start is called before the first frame update
        private void Start()
        {
            followTargetTransform = followTarget.transform;
            prevMouseInput = Vector2.zero;
        }

        public void OnLook(InputValue delta)
        {
            Vector2 aimValue = delta.Get<Vector2>();
            followTargetTransform.rotation *= Quaternion.AngleAxis(Mathf.Lerp(prevMouseInput.x, aimValue.x, 1f / horizontalDamping) * rotationSpeed, transform.up);
            prevMouseInput = aimValue;
            transform.rotation = Quaternion.Euler(0 , followTargetTransform.transform.rotation.eulerAngles.y, 0);
            followTargetTransform.localEulerAngles = Vector3.zero;
        }
    }

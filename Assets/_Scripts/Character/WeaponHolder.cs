using UnityEngine;
using UnityEngine.InputSystem;

namespace Character
{
    public class WeaponHolder : MonoBehaviour
    {

        [SerializeField] private GameObject Weapon;

        [SerializeField] private Transform WeaponSocket;

        private Transform GripLocation;

        private bool FiringPressed = false; 
        //Components
        public PlayerController Controller => PlayerController;
        private PlayerController PlayerController;
        private Animator PlayerAnimator;
        
        

        //Ref
        private Camera MainCamera;
        private WeaponComponent EquippedWeapon;
    

        private void Awake()
        {
            PlayerController = GetComponent<PlayerController>();
            PlayerAnimator = GetComponent<Animator>();
        
            MainCamera = Camera.main;
        }

        // Start is called before the first frame update
        private void Start()
        {
            GameObject spawnedWeapon = Instantiate(Weapon, WeaponSocket.position, WeaponSocket.rotation);

            if (!spawnedWeapon) return;

            if (spawnedWeapon)
            {
                WeaponComponent weapon = spawnedWeapon.GetComponent<WeaponComponent>();
                if(weapon)
                {
                    PlayerAnimator.SetInteger("WeaponType", (int)weapon.WeaponStats.WaeaponType);
                    spawnedWeapon.transform.parent = WeaponSocket;
                    EquippedWeapon = spawnedWeapon.GetComponent<WeaponComponent>();
                    GripLocation = EquippedWeapon.HandPosition;
                    EquippedWeapon.Initialize(this, PlayerController.crosshair);

                    PlayerEvents.Invoke_OnWeaponEquipped(EquippedWeapon);
                }
            }
        }

        public void OnLook(InputValue delta)
        {
            Vector3 independentMousePosition =
                MainCamera.ScreenToViewportPoint(PlayerController.crosshair.mousePos);
            PlayerAnimator.SetFloat("AimVertical", independentMousePosition.y);
            PlayerAnimator.SetFloat("AimHorizontal", independentMousePosition.x);
        }
        public void StopFiring()
        {
            PlayerController.isFiring = false;
            PlayerAnimator.SetBool("IsFiring", PlayerController.isFiring);
            EquippedWeapon.StopFiring();
        }
        public void StartFiring()
        {
            
            PlayerController.isFiring = true;
            PlayerAnimator.SetBool("IsFiring", PlayerController.isFiring);
            EquippedWeapon.StartFiring();
        }
        public void OnFire(InputValue button)
        {
            FiringPressed = button.isPressed;
            if (FiringPressed)
            {
                StartFiring();
            }
            else
            {
                StopFiring();
            }
            
        }

       
        private void OnAnimatorIK(int layerIndex)
        {
            PlayerAnimator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1f);
            PlayerAnimator.SetIKPosition(AvatarIKGoal.LeftHand, GripLocation.position);
        }
        
    }
}

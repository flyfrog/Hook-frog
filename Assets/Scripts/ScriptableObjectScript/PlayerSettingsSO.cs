using UnityEngine;

namespace ScriptableObjectScript
{
    [CreateAssetMenu(fileName = "PlayerSettingsSO", menuName = "GameSO/PlayerSettingsSO")]
    public class PlayerSettingsSO : ScriptableObject
    {
        [Header("Player")] 
        public float jumpForce = 13f;
        public float maxAngleGroundForJump = 45f;

        [Space] [Header("RopeGun")] public float speedHook = 70f;
        public float ROPE_SPRING = 100f;
        public float ROPE_DAMPER = 5f;
        public float MAX_ROPE_LENGTH = 20f;
    }
}
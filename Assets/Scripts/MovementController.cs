using UnityEngine;

namespace LostCubs
{
    /// <summary>
    /// The class responsible for motion control 
    /// </summary>
    public class MovementController : MonoBehaviour
    {
        #region Properties

        public enum ControlMode
        {
            Keyboard
        }

        [SerializeField] private Character m_TargetCharacter;

        #endregion

        #region Unity Events

        private void Update()
        {
            if (m_TargetCharacter == null) return;

            ControlKeyboard();
        }

        #endregion

        #region private API

        private void ControlKeyboard()
        {
            float dir = 0;
            float jump = 0;

            if (Input.GetKey(KeyCode.LeftArrow))
                dir = -1.0f;

            if (Input.GetKey(KeyCode.RightArrow))
                dir = 1.0f;

            if (Input.GetKey(KeyCode.Space))
                jump = 1.0f;

            m_TargetCharacter.DirectionMovement = dir;
            m_TargetCharacter.JumpControl = jump;
        }

        #endregion
    }
}

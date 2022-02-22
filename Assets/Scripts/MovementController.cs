using UnityEngine;

namespace LostCubs
{
    /// <summary>
    /// The class responsible for motion control 
    /// </summary>
    public class MovementController : MonoBehaviour
    {
        #region Properties

        /// <summary>
        /// Enumeration of control options. 
        /// </summary>
        public enum ControlMode
        {
            Keyboard
        }

        /// <summary>
        /// The target character being controlled.
        /// </summary>
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

        /// <summary>
        /// Method for keyboard control.
        /// </summary>
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

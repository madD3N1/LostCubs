using UnityEngine;

namespace LostCubs
{
    /// <summary>
    /// Class for controlling the game camera. 
    /// </summary>
    public class CameraController : MonoBehaviour
    {
        #region Properties

        /// <summary>
        /// Target camera. 
        /// </summary>
        [SerializeField] private Camera m_Camera;

        /// <summary>
        /// The target being tracked by the camera.
        /// </summary>
        [SerializeField] private Transform m_Target;

        /// <summary>
        /// Camera movement speed.
        /// </summary>
        [SerializeField] private float m_InterpolationLinear;

        /// <summary>
        /// Camera offset along the Z axis.
        /// </summary>
        [SerializeField] private float m_CameraZOffset;

        /// <summary>
        /// Offset tracking camera.
        /// </summary>
        [SerializeField] private float m_ForwardOffset;

        #endregion

        #region Unity Events

        private void FixedUpdate()
        {
            if (m_Target == null || m_Camera == null) return;

            Vector2 camPos = m_Camera.transform.position;
            Vector2 targetPos = m_Target.position + m_Target.transform.up * m_ForwardOffset;

            Vector2 newCamPos = Vector2.Lerp(camPos, targetPos, m_InterpolationLinear * Time.deltaTime);

            m_Camera.transform.position = new Vector3(newCamPos.x, newCamPos.y, m_CameraZOffset);
        }

        #endregion

        #region Public API

        /// <summary>
        /// A method that sets a new target for the camera.
        /// </summary>
        /// <param name="newTarget"> Target. </param>
        public void SetTarget(Transform newTarget)
        {
            m_Target = newTarget;
        }

        #endregion
    }
}

using UnityEngine;
using System.Collections;

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

        private float m_CurrentForwardOffset;

        #endregion

        #region Unity Events

        private void Start()
        {
            m_CurrentForwardOffset = m_ForwardOffset;
            m_Target.GetComponent<MovementController>().EventOnJump.AddListener(OnForwardOffsetChange);
        }

        private void FixedUpdate()
        {
            if (m_Target == null || m_Camera == null) return;

            Vector2 camPos = m_Camera.transform.position;
            Vector2 targetPos = m_Target.position + m_Target.transform.up * m_CurrentForwardOffset;

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

        private void OnForwardOffsetChange()
        {
            m_CurrentForwardOffset = 1;

            // TODO: думаю, стоит обойтись без корутины. Возможно стоит добавить в MovementController еще один ивент,
            // который срабатывает, когда прыжок равен 0 и подписаться на него.
            StartCoroutine(ForwardOffsetChange());
        }

        IEnumerator ForwardOffsetChange()
        {
            yield return new WaitForSeconds(0.8f);

            m_CurrentForwardOffset = m_ForwardOffset;
        }
    }
}

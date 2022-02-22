using UnityEngine;

namespace LostCubs
{
    /// <summary>
    /// The class responsible for character movement
    /// </summary>
    [RequireComponent(typeof(Rigidbody2D))]
    public class Character : Destructible
    {
        #region Properties
        /// <summary>
        /// Character mass.
        /// </summary>
        [SerializeField] private float m_Mass;

        /// <summary>
        /// Forward pushing force.
        /// </summary>
        [SerializeField] private float m_Thrust;

        /// <summary>
        /// Maximum character speed.
        /// </summary>
        [SerializeField] private float m_MaxSpeed;

        /// <summary>
        /// Jump force. 
        /// </summary>
        [SerializeField] private float m_JumpForce;

        /// <summary>
        /// Character movement direction.
        /// </summary>
        public float DirectionMovement { get; set; }

        /// <summary>
        /// Jump power control.
        /// </summary>
        public float JumpControl { get; set; }

        /// <summary>
        /// A flag that keeps track of whether the character is on the ground.
        /// </summary>
        private bool m_IsGround;

        /// <summary>
        /// Saved Rigidbody character.
        /// </summary>
        private Rigidbody2D m_Rigidbody;

        #endregion

        #region Unity Events

        protected override void Start()
        {
            base.Start();

            m_Rigidbody = GetComponent<Rigidbody2D>();
            m_Rigidbody.mass = m_Mass;
            m_Rigidbody.inertia = 1;
        }

        private void FixedUpdate()
        {
            UpdateRigidbody();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.transform.tag == "Ground")
            {
                m_IsGround = true;
            }
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            m_IsGround = false;
        }

        #endregion

        #region Private API

        /// <summary>
        /// Method that updates the Rigidbody.
        /// </summary>
        private void UpdateRigidbody()
        {
            m_Rigidbody.AddForce(m_Thrust * DirectionMovement * transform.right * Time.fixedDeltaTime, ForceMode2D.Force);
            m_Rigidbody.AddForce(-m_Rigidbody.velocity * (m_Thrust / m_MaxSpeed) * Time.fixedDeltaTime, ForceMode2D.Force);

            if(m_IsGround == true)
            {
                m_Rigidbody.AddForce(m_JumpForce * JumpControl * transform.up * Time.fixedDeltaTime, ForceMode2D.Impulse);
            } 
        }

        #endregion
    }
}

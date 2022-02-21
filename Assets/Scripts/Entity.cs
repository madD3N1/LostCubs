using UnityEngine;

namespace LostCubs
{
    /// <summary>
    /// The base class for all interactive game objects in the scene. 
    /// </summary>
    public class Entity : MonoBehaviour
    {
        #region Properties

        /// <summary>
        /// The name of the object for the user.
        /// </summary>
        [SerializeField] private string m_Nickname;
        public string Nickname => m_Nickname;

        #endregion
    }
}

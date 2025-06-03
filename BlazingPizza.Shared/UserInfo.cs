namespace BlazingPizza
{
    /// <summary>
    /// Stellt Informationen über einen Benutzer bereit.
    /// </summary>
    public class UserInfo
    {
        /// <summary>
        /// Gibt an, ob der Benutzer authentifiziert ist.
        /// </summary>
        public bool IsAuthenticated { get; set; }

        /// <summary>
        /// Ruft den Namen des Benutzers ab oder legt ihn fest.
        /// </summary>
        public string Name { get; set; }
    }
}
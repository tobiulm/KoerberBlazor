namespace BlazingPizza.ComponentsLibrary.Map
{
    /// <summary>
    /// Repräsentiert einen Marker auf der Karte.
    /// </summary>
    public class Marker
    {
        /// <summary>
        /// Ruft die Beschreibung des Markers ab oder legt sie fest.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Ruft die X-Koordinate des Markers ab oder legt sie fest.
        /// </summary>
        public double X { get; set; }

        /// <summary>
        /// Ruft die Y-Koordinate des Markers ab oder legt sie fest.
        /// </summary>
        public double Y { get; set; }

        /// <summary>
        /// Gibt an, ob ein Popup für den Marker angezeigt werden soll.
        /// </summary>
        public bool ShowPopup { get; set; }
    }
}
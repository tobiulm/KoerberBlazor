using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace BlazingPizza.ComponentsLibrary
{
    /// <summary>
    /// Stellt Hilfsmethoden für den Zugriff auf den lokalen Speicher (LocalStorage) im Browser bereit.
    /// </summary>
    public static class LocalStorage
    {
        /// <summary>
        /// Ruft einen Wert aus dem lokalen Speicher asynchron ab.
        /// </summary>
        /// <typeparam name="T">Der Typ des Werts, der abgerufen werden soll.</typeparam>
        /// <param name="jsRuntime">Die Instanz von <see cref="IJSRuntime"/>, die für den JavaScript-Aufruf verwendet wird.</param>
        /// <param name="key">Der Schlüssel, unter dem der Wert gespeichert ist.</param>
        /// <returns>Ein <see cref="ValueTask{T}"/>, der den abgerufenen Wert enthält.</returns>
        public static ValueTask<T> GetAsync<T>(IJSRuntime jsRuntime, string key)
            => jsRuntime.InvokeAsync<T>("blazorLocalStorage.get", key);

        /// <summary>
        /// Speichert einen Wert asynchron im lokalen Speicher.
        /// </summary>
        /// <param name="jsRuntime">Die Instanz von <see cref="IJSRuntime"/>, die für den JavaScript-Aufruf verwendet wird.</param>
        /// <param name="key">Der Schlüssel, unter dem der Wert gespeichert werden soll.</param>
        /// <param name="value">Der zu speichernde Wert.</param>
        /// <returns>Ein <see cref="ValueTask"/>, der die asynchrone Operation darstellt.</returns>
        public static ValueTask SetAsync(IJSRuntime jsRuntime, string key, object value)
            => jsRuntime.InvokeVoidAsync("blazorLocalStorage.set", key, value);

        /// <summary>
        /// Löscht einen Wert asynchron aus dem lokalen Speicher.
        /// </summary>
        /// <param name="jsRuntime">Die Instanz von <see cref="IJSRuntime"/>, die für den JavaScript-Aufruf verwendet wird.</param>
        /// <param name="key">Der Schlüssel des zu löschenden Werts.</param>
        /// <returns>Ein <see cref="ValueTask"/>, der die asynchrone Operation darstellt.</returns>
        public static ValueTask DeleteAsync(IJSRuntime jsRuntime, string key)
            => jsRuntime.InvokeVoidAsync("blazorLocalStorage.delete", key);
    }
}
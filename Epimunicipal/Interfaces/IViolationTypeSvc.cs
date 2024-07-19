using Epimunicipal.Models;

namespace Epimunicipal.Service
{
    /// <summary>
    /// Interfaccia per il servizio di gestione dei tipi di violazione.
    /// </summary>
    public interface IViolationTypeSvc
    {
        /// <summary>
        /// Recupera un tipo di violazione per ID.
        /// </summary>
        /// <param name="id">L'ID del tipo di violazione.</param>
        /// <returns>Il tipo di violazione con l'ID specificato.</returns>
        ViolationType GetViolationType(int id);

        /// <summary>
        /// Recupera tutti i tipi di violazione.
        /// </summary>
        /// <returns>Una lista di tutti i tipi di violazione.</returns>
        List<ViolationType> GetViolationTypes();
    }
}

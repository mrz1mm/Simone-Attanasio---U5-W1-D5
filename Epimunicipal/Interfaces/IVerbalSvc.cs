using Epimunicipal.Models;
using Epimunicipal.Models.Dto;

namespace Epimunicipal.Service
{
    /// <summary>
    /// Interfaccia per il servizio di gestione dei verbali.
    /// </summary>
    public interface IVerbalSvc
    {
        /// <summary>
        /// Recupera un verbale per ID.
        /// </summary>
        /// <param name="id">L'ID del verbale.</param>
        /// <returns>Il verbale con l'ID specificato.</returns>
        Verbal GetVerbal(int id);

        /// <summary>
        /// Recupera tutti i verbali.
        /// </summary>
        /// <returns>Una lista di tutti i verbali.</returns>
        List<Verbal> GetVerbals();

        /// <summary>
        /// Recupera i dettagli di tutti i verbali.
        /// </summary>
        /// <returns>Una lista di dettagli di tutti i verbali.</returns>
        List<VerbalDetailsDto> GetVerbalsDetails();

        /// <summary>
        /// Recupera i verbali per trasgressore.
        /// </summary>
        /// <returns>Una lista di verbali per trasgressore.</returns>
        List<TransgressorVerbalDto> GetVerbalsByTrasgressor();

        /// <summary>
        /// Recupera i punti decurtati per trasgressore.
        /// </summary>
        /// <returns>Una lista di punti decurtati per trasgressore.</returns>
        List<TransgressorPointsDeductedDto> GetTransgressorPointsDeducted();

        /// <summary>
        /// Recupera i verbali con decurtazione punti superiori a dieci.
        /// </summary>
        /// <returns>Una lista di verbali con decurtazione punti superiori a dieci.</returns>
        List<VerbalsPointsDeductionOverTenDto> GetVerbalsPointsDeductedOverTen();

        /// <summary>
        /// Recupera i dettagli dei verbali con importo superiore a 400.
        /// </summary>
        /// <returns>Una lista di dettagli dei verbali con importo superiore a 400.</returns>
        List<VerbalDetailsDto> GetVerbalsDetailsAmourOver400();

        /// <summary>
        /// Aggiunge un nuovo verbale.
        /// </summary>
        /// <param name="verbalDto">I dettagli del verbale da aggiungere.</param>
        void AddVerbal(VerbalDto verbalDto);
    }
}

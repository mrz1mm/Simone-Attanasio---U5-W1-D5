using Epimunicipal.Models;
using Epimunicipal.Models.Dto;

namespace Epimunicipal.Service
{
    /// <summary>
    /// Interfaccia per il servizio di gestione dei dati personali.
    /// </summary>
    public interface IPersonalDataSvc
    {
        /// <summary>
        /// Recupera i dati personali per ID.
        /// </summary>
        /// <param name="id">L'ID dei dati personali.</param>
        /// <returns>I dati personali con l'ID specificato.</returns>
        PersonalData GetPersonalData(int id);

        /// <summary>
        /// Recupera tutte le voci dei dati personali.
        /// </summary>
        /// <returns>Una lista di tutte le voci dei dati personali.</returns>
        List<PersonalData> GetPersonalDatas();

        /// <summary>
        /// Aggiunge nuovi dati personali.
        /// </summary>
        /// <param name="personalDataDto">I dati personali da aggiungere.</param>
        void AddPersonalData(PersonalDataDto personalDataDto);

        /// <summary>
        /// Aggiorna i dati personali esistenti.
        /// </summary>
        /// <param name="personalData">I dati personali da aggiornare.</param>
        void UpdatePersonalData(PersonalData personalData);

        /// <summary>
        /// Elimina i dati personali per ID.
        /// </summary>
        /// <param name="id">L'ID dei dati personali da eliminare.</param>
        void DeletePersonalData(int id);
    }
}

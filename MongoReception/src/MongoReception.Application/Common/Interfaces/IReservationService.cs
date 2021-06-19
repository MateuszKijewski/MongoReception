using MongoReception.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoReception.Application.Common.Interfaces
{
    public interface IReservationService
    {
        Task<Reservation> AddReservation(Reservation reservation);

        Task<Reservation> GetReservation(string id);

        Task<IEnumerable<Reservation>> GetAllReservations();

        Task UpdateReservation(Reservation reservation);

        Task DeleteReservation(string id);

        Task PayForReservation(string id);
    }
}
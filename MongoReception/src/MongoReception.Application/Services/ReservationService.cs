using MongoReception.Application.Common.Interfaces;
using MongoReception.Domain.Entities;
using MongoReception.Infrastructure.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoReception.Application.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IBaseRepository<Reservation> _reservationRepository;

        public ReservationService(IBaseRepositoryProvider baseRepositoryProvider)
        {
            _reservationRepository = baseRepositoryProvider.GetRepository<Reservation>();
        }

        public async Task<Reservation> AddReservation(Reservation reservation)
        {
            return await _reservationRepository.Add(reservation);
        }

        public async Task DeleteReservation(string id)
        {
            await _reservationRepository.Delete(id);
        }

        public async Task<IEnumerable<Reservation>> GetAllReservations()
        {
            return await _reservationRepository.List();
        }

        public async Task<Reservation> GetReservation(string id)
        {
            return await _reservationRepository.Get(id);
        }

        public async Task UpdateReservation(Reservation reservation)
        {
            await _reservationRepository.Update(reservation);
        }

        public async Task PayForReservation(string id)
        {
            var reservation = await _reservationRepository.Get(id);

            // Room for payment middleware (eg. PayU)
            reservation.IsPaid = true;

            await _reservationRepository.Update(reservation);
        }
    }
}
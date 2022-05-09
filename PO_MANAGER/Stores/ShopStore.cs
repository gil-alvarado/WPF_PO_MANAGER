using PO_MANAGER.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PO_MANAGER.Stores
{
    public class ShopStore
    {
        private readonly Shop _shop;
        private readonly List<PurchaseOrder> _purchaseOrders;
        private Lazy<Task> _initializeLazy;//make sure initialization only happens once

        public IEnumerable<PurchaseOrder> Reservations => _purchaseOrders;

        //reactivity: ListingView reacts to new reservation that was created
        public event Action<PurchaseOrder> ReservationMade;

        public ShopStore(Shop shop)
        {
            _shop = shop;
            _initializeLazy = new Lazy<Task>(Initialize);

            _purchaseOrders = new List<PurchaseOrder>();
        }

        /// <summary>
        /// Load reservations ONCE
        /// </summary>
        /// <returns></returns>
        public async Task Load()
        {
            try
            {
                //Value = Initialize
                await _initializeLazy.Value;
            }
            catch (Exception)
            {
                _initializeLazy = new Lazy<Task>(Initialize);
                throw;
            }

        }
        /// <summary>
        /// create task to initialize once
        /// </summary>
        /// <returns></returns>
        private async Task Initialize()
        {
            /*
            IEnumerable<PurchaseOrder> reservations = await _shop.GetAllReservations();

            _purchaseOrders.Clear();
            _purchaseOrders.AddRange(reservations);
            */
            //throw new Exception();
        }

        /// <summary>
        /// notify HotelStore about new reservation, add to in-memory List(_reservations)
        /// build off of MakeReservationCommand
        /// </summary>
        /// <param name="purchaseOrder"></param>
        /// <returns></returns>
        public async Task MakeReservation(PurchaseOrder purchaseOrder)
        {
            /*
            await _shop.MakeReservation(purchaseOrder);//add reservation to database

            _purchaseOrders.Add(purchaseOrder);//add reservation yo in-memory reservations

            OnReservationMade(purchaseOrder);
            */
        }

        private void OnReservationMade(PurchaseOrder purchaseOrder)
        {
            ReservationMade?.Invoke(purchaseOrder);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

using ShippingRates.Helpers.Extensions;
using ShippingRates.RateServiceWebReference;

namespace ShippingRates.ShippingProviders
{
    /// <summary>
    ///     Provides rates from FedEx (Federal Express) excluding SmartPost. Please use <see cref="FedExSmartPostProvider"/> for SmartPost rates.
    /// </summary>
    public class FedExProvider : FedExBaseProvider
    {
        public override string Name { get => "FedEx"; }

        /// <summary>
        /// </summary>
        /// <param name="key"></param>
        /// <param name="password"></param>
        /// <param name="accountNumber"></param>
        /// <param name="meterNumber"></param>
        public FedExProvider(string key, string password, string accountNumber, string meterNumber)
            : this(key, password, accountNumber, meterNumber, true) { }

        /// <summary>
        /// </summary>
        /// <param name="key"></param>
        /// <param name="password"></param>
        /// <param name="accountNumber"></param>
        /// <param name="meterNumber"></param>
        /// <param name="useProduction"></param>
        public FedExProvider(string key, string password, string accountNumber, string meterNumber, bool useProduction)
            : base(key, password, accountNumber, meterNumber, useProduction) { }

        /// <summary>
        /// Sets service codes.
        /// </summary>
        protected override Dictionary<string, string> ServiceCodes => new Dictionary<string, string>
        {
            {"PRIORITY_OVERNIGHT", "FedEx Priority Overnight"},
            {"FEDEX_2_DAY", "FedEx 2nd Day"},
            {"FEDEX_2_DAY_AM", "FedEx 2nd Day A.M."},
            {"STANDARD_OVERNIGHT", "FedEx Standard Overnight"},
            {"FIRST_OVERNIGHT", "FedEx First Overnight"},
            {"FEDEX_EXPRESS_SAVER", "FedEx Express Saver"},
            {"FEDEX_GROUND", "FedEx Ground"},
            {"GROUND_HOME_DELIVERY", "FedEx Ground Residential"},
            {"INTERNATIONAL_GROUND", "FedEx International Ground"},
            {"INTERNATIONAL_FIRST", "FedEx International First"},
            {"INTERNATIONAL_ECONOMY", "FedEx International Economy"},
            {"INTERNATIONAL_PRIORITY", "FedEx International Priority"}
        };

        /// <summary>
        /// Sets shipment details
        /// </summary>
        /// <param name="request"></param>
        protected sealed override void SetShipmentDetails(RateRequest request)
        {
            SetOrigin(request);
            SetDestination(request);
            SetPackageLineItems(request);
        }
    }
}

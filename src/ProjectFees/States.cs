using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectFees
{
    public class States
    {
        public List<StateFee> ServiceAreaStateFees = new List<StateFee>();
        public decimal OutOfAreaFee { get; private set; }
        public States()
        {
            ServiceAreaStateFees.Add(new StateFee("Washington", "WA", 8.99m));
            ServiceAreaStateFees.Add(new StateFee("Oregon", "OR", 2.99m));
            ServiceAreaStateFees.Add(new StateFee("California", "CA", 16.99m));
            ServiceAreaStateFees.Add(new StateFee("Idaho", "ID", 3.99m));
            ServiceAreaStateFees.Add(new StateFee("Nevada", "NV", 5.99m));
            ServiceAreaStateFees.Add(new StateFee("Arizona", "AZ", 2.99m));
            ServiceAreaStateFees.Add(new StateFee("Montana", "MT", 8.99m));
            ServiceAreaStateFees.Add(new StateFee("Wyoming", "WY", 4.99m));
            ServiceAreaStateFees.Add(new StateFee("Utah", "UT", 7.99m));
            ServiceAreaStateFees.Add(new StateFee("Colorado", "CO", 2.99m));

            OutOfAreaFee = 49.99m;
        }

        public decimal GetFeeForState(string twoLetterCode)
        {
            var state = ServiceAreaStateFees.FirstOrDefault(f => f.TwoLetterCode == twoLetterCode.ToUpper());
            return state != null ? state.Fee : OutOfAreaFee;
        }
    }
}

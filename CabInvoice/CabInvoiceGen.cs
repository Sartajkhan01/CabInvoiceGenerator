using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoice
{
    public class CabInvoiceGen
    {
        // If Variable is read only values can be only changed in constructor.
        public readonly int MINIMUM_FARE;
        public readonly int COST_PER_KM;
        public readonly int COST_PER_MINUTE;

        // Parameterized constructor
        public CabInvoiceGen(RideType type)
        {
            if (type.Equals(RideType.NORMAL))
            {
                MINIMUM_FARE = 5;
                COST_PER_KM = 10;
                COST_PER_MINUTE = 1;
            }
        }

        // UC1 - Method to calculate fare for single ride
        public double CalculateFare(int time, double distance)
        {
            double totalFare;
            try
            {
                if (time <= 0)
                    throw new CabInvoiceGeneratorException(CabInvoiceGeneratorException.ExceptionType.INVALID_TIME, "Invalid Time");
                if (distance <= 0)
                    throw new CabInvoiceGeneratorException(CabInvoiceGeneratorException.ExceptionType.INVALID_DISTANCE, "Invalid Distance");
                //Total fare for single ride
                totalFare = (distance * COST_PER_KM) + (time * COST_PER_MINUTE);
                //Comparing minimum fare and calculated fare to return the maximum fare
                return Math.Max(totalFare, MINIMUM_FARE);
            }
            catch (CabInvoiceGeneratorException ex)
            {
                throw ex;
            }
        }
    }
}

using RapidPay.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidPay.Services
{
    public class UniversalFeeExchangeService : IUniversalFeeExchangeService
    {
        private readonly Random random = new();
        private readonly int changeMinutesInterval;
        private readonly int decimals;
        private readonly int minValue, maxValue;
        
        private decimal lastFee = 0;
        private DateTimeOffset lastChange;

        public UniversalFeeExchangeService(int minValue, int maxValue, int decimals, int changeMinutesInterval)
        {
            this.changeMinutesInterval = changeMinutesInterval;
            this.minValue = minValue;
            this.maxValue = maxValue;
            this.decimals = decimals;
            lastFee = RandomNumberBetween(this.minValue, this.maxValue, this.decimals);
            lastChange = DateTimeOffset.Now;
        }
        
        public decimal GetFee()
        {
            DateTimeOffset now = DateTimeOffset.Now;
            TimeSpan timeDiff = now.Subtract( lastChange );

            if (timeDiff.Minutes > changeMinutesInterval)
            {
                Math.Round(lastFee *= RandomNumberBetween(minValue, maxValue, decimals), decimals);
                lastChange = now;
            }

            return lastFee;
        }

        private decimal RandomNumberBetween(double minValue, double maxValue, int decimals)
        {
            var next = random.NextDouble();

            return Math.Round(new decimal(minValue + (next * (maxValue - minValue))), decimals);
        }
    }
}

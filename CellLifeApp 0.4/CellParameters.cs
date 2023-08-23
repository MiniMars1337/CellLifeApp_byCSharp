using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CellLifeApp.PrintingClasses;
using CellLifeApp.FieldClasses;

namespace CellLifeApp
{
    [Serializable]
    class CellParameters
    {
        public int MaxSunLevel { get; set; }
        public int ToxicLevel { get; set; }
        public int AverageCharge { get; set; }
        public int ChargeRecoverySpeed { get; set; }
        public int OrganicIncrease { get; set; }
        public int ChargeIncrease { get; set; }
        public int MaxEnergyCapacity { get; set; }
        public int EnergyDecreasement { get; set; }
        public int MaxChargeExtraction { get; set; }
        public int MaxOrganicExtraction { get; set; }
        public int MaxGenCodeValue { get; set; }
        public double CellEatingCoefficient { get; set; }
        public int OrganicEating { get; set; }
        public bool IsMutationEnabled { get; set; }
        public double MutationChance { get; set; }

        public CellParameters()
        {
            OrganicIncrease = 2;
            ChargeIncrease = 2;
            MaxSunLevel = 8;
            ToxicLevel = 1000;
            AverageCharge = 50;
            ChargeRecoverySpeed = 1;
            MaxEnergyCapacity = 500;
            EnergyDecreasement = 2;
            MaxChargeExtraction = 5;
            MaxOrganicExtraction = 2;
            MaxGenCodeValue = 100;
            CellEatingCoefficient = 0.5;
            OrganicEating = 4;
            MutationChance = 0.01;
            IsMutationEnabled = true;
            UpdateData();
        }

        public void UpdateData()
        {
            Cell.parameters = this;
            TextureArray.range = ToxicLevel / TextureArray.precision;
            GeneticCell.toxicConstant = ToxicLevel / MaxGenCodeValue;
            GeneticCell.energyConstant = MaxEnergyCapacity / MaxGenCodeValue;
        }
    }
}

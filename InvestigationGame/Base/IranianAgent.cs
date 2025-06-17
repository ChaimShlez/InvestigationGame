using System;
using System.Collections.Generic;
using InvestigationGame.Enum;

namespace InvestigationGame.Base
{
    internal class IranianAgent
    {
        private int Id;
        private EnumTypeRank Type;
        private int AmountWeaknessesSensors;
        private EnumTypeSensor[] EnumTypeSensors;
        private List<Sensor> Sensors;

        private static readonly Random rand = new Random();

        public IranianAgent(EnumTypeRank type, int amount)
        {
            Type = type;
            AmountWeaknessesSensors = amount;
            EnumTypeSensors = CreateRandomTypeSensors(amount);
            Sensors = new List<Sensor>();
        }

        private EnumTypeSensor[] CreateRandomTypeSensors(int amount)
        {
            var values = System.Enum.GetValues(typeof(EnumTypeSensor));
            EnumTypeSensor[] sensors = new EnumTypeSensor[amount];

            for (int i = 0; i < amount; i++)
            {
                sensors[i] = (EnumTypeSensor)values.GetValue(rand.Next(values.Length));
            }

            return sensors;
        }
        

        public void AttachSensor(Sensor sensor)
        {
            Sensors.Add(sensor);
        }

        public int amountWeaknessesSensors
        {
            get { return AmountWeaknessesSensors; }
            set { AmountWeaknessesSensors = value; }
        }

        public EnumTypeSensor[] enumTypeSensors
        {
            get { return EnumTypeSensors; }
            set { EnumTypeSensors = value; }
        }

        public List<Sensor> sensors
        {
            get { return Sensors; }
            set { Sensors = value; }
        }
        public EnumTypeRank typeRank
        {
            get { return Type; }
            //set { EnumTypeSensors = value; }
        }

    }
}


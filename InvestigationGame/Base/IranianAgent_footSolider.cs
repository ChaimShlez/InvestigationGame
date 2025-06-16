using System;
using InvestigationGame.Enum;

namespace InvestigationGame.Base
{
    internal class IranianAgent_footSolider
    {
        private int Id;
        private EnumTypeRank Type;
        private int AmountWeaknessesSensors;
        private EnumTypeSensor[] EnumTypeSensors;

        private static readonly Random rand = new Random();

        public IranianAgent_footSolider(EnumTypeRank type, int amount)
        {
            Type = type;
            AmountWeaknessesSensors = amount;
            EnumTypeSensors = CreateRandomTypeSensors(amount);
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

        public EnumTypeRank AgentType => Type;

        public EnumTypeSensor[] WeaknessSensors => EnumTypeSensors;
    }
}


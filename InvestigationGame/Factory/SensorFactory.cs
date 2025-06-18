using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvestigationGame.Base;
using InvestigationGame.Entity.IranianEntity;
using InvestigationGame.Entity.SensorEntity;
using InvestigationGame.Enum;

namespace InvestigationGame.Factory
{
    internal static class SensorFactory
    {
        public static Sensor CreateSensor(int id,EnumTypeSensor type)
        {
            switch (type)
            {
                case EnumTypeSensor.AudioSensor:
                    return new AudioSensor(id);
                case EnumTypeSensor.ThermalSensor:
                    return new ThermalSensor(id);
                case EnumTypeSensor.PulseSensor:
                    return new PulseSensor(id);
                case EnumTypeSensor.MotionSensor:
                    return new MotionSensor(id);
                case EnumTypeSensor.MagneticSensor:
                    return new MagneticSensor(id);
                case EnumTypeSensor.SignalSensor:
                    return new SignalSensor(id);
                case EnumTypeSensor.LightSensor:
                    return new LightSensor(id);
                default:
                    throw new ArgumentException("Unknown sensor type");
            }
        }
    }

}

      
       
       
        
        
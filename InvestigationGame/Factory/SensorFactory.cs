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
        public static Sensor CreateSensor(EnumTypeSensor type)
        {
            switch (type)
            {
                case EnumTypeSensor.AudioSensor:
                    return new AudioSensor();
                case EnumTypeSensor.ThermalSensor:
                    return new ThermalSensor();
                case EnumTypeSensor.PulseSensor:
                    return new PulseSensor();
                case EnumTypeSensor.MotionSensor:
                    return new MotionSensor();
                case EnumTypeSensor.MagneticSensor:
                    return new MagneticSensor();
                case EnumTypeSensor.SignalSensor:
                    return new SignalSensor();
                case EnumTypeSensor.LightSensor:
                    return new LightSensor();
                default:
                    throw new ArgumentException("Unknown sensor type");
            }
        }
    }

}

      
       
       
        
        
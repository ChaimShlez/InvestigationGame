using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvestigationGame.Entity;
using InvestigationGame.Enum;

namespace InvestigationGame.Base
{
    internal abstract class Sensor
    {
        private int Id;
        private EnumTypeSensor TypeSensor;
        

        public Sensor(int id ,EnumTypeSensor typeSensor)
        {
            Id = id;
            TypeSensor = typeSensor;
           
        }

        public abstract ActivateResult Activate(IranianAgent agent);
        
           
        

        

        public EnumTypeSensor tpye
        {
            get { return TypeSensor; }
            //set { Name = value; }
        }


        public int id
        {
            get { return Id; }
        }

        

    }
}

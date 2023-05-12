using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Models.GamesFolder
{
    public class Specification
    {
        public int SpecificationID { get; private set; }
        public string SpecificationType { get; private set; }
        public string OS { get; private set; }
        public string Processor { get; private set; }
        public string Memory { get; private set; }
        public string Storage { get; private set; }
        public string DirectX { get; private set; }
        public string Graphics { get; private set; }
        public string Other { get; private set; }
        public string Logins { get; private set; }

        public Specification(int specificationID, string SpecificationType, string os, string processor, string memory, string storage, string directX, string graphics, string other, string logins) 
        {
            this.SpecificationID = specificationID;
            this.SpecificationType = SpecificationType;
            this.OS = os;
            this.Processor = processor;
            this.Memory = memory;
            this.Storage = storage;
            this.DirectX = directX;
            this.Graphics = graphics;
            this.Other = other;
            this.Logins = logins;
        }
    }
    

}

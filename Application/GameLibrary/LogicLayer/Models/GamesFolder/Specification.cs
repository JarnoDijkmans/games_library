using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Models.GamesFolder
{
    public class Specification
    {
        public int SpecificationID { get; set; }
        public string SpecificationType { get; set; }
        public string OS { get; set; }
        public string Processor { get; set; }
        public string Memory { get; set; }
        public string Storage { get; set; }
        public string DirectX { get; set; }
        public string Graphics { get; set; }
        public string Other { get; set; }
        public string Logins { get; set; }

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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class ElectronicPublicationEntity : MaterialEntity
    {
        public string[] Authors { get; set; }
        public int NumberOfPages { get; set; }
        public string Format { get; set; }
        public int YearOfPublishing { get; set; }
        public ElectronicPublicationEntity(int userId,string materialName, string[] Authors, int NumberOfPages, string Format, int YearOfPublishing)
        {
            this.UserId = userId;
            this.Id = counter;
            this.Name = materialName;
            this.Authors = Authors;
            this.NumberOfPages = NumberOfPages;
            this.Format = Format;
            this.YearOfPublishing = YearOfPublishing;
            counter++;
        }

        public ElectronicPublicationEntity()
        {
        }
    }
}

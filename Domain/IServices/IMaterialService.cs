using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public interface IMaterialService
    {
        public List<MaterialEntity> ShowMaterials();
        public bool AddMaterial(int userId,string[] properties, string name);
    }
}

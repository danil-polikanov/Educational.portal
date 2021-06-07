using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public interface IMaterialRepository
    {
        public void SaveList();
        public List<MaterialEntity> ShowMaterials();
        public List<MaterialEntity> AddMaterial(MaterialEntity material);
    }
}
     
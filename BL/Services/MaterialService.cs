using Domain.Entity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL
{
    public class MaterialService : IMaterialService
    {
        private readonly IMaterialRepository _materialRepository;
        List<VideoResourceEntity> videoMaterials = new List<VideoResourceEntity>();
        List<ElectronicPublicationEntity> electronicMaterials = new List<ElectronicPublicationEntity>();
        List<InternetArticleEntity> internetMaterials = new List<InternetArticleEntity>();

        List<MaterialEntity> materials = new List<MaterialEntity>();
        public MaterialService(IMaterialRepository repository)
        {
            _materialRepository = repository;
            MaterialEntity.counter += _materialRepository.ShowMaterials().Count();
            materials.AddRange(_materialRepository.ShowMaterials());
        }

        public bool AddMaterial(int userId, string[] properties, string name)
        {
            string materialName = properties[0];

            if (name == "VideoResource")
            {
                TimeSpan duraction;
                try
                {
                    duraction = TimeSpan.Parse(properties[1]);
                }
                catch (Exception)
                {
                    return false;
                }

                string quality = properties[2];
                var videoResource = new VideoResourceEntity(userId, materialName, duraction, quality);
                videoMaterials.Add(videoResource);
                _materialRepository.AddMaterial(videoResource);
            }
            if (name == "InternetArticle")
            {
                DateTime dateOfPublication;
                try
                {
                    dateOfPublication = DateTime.Parse(properties[1]);
                }
                catch (Exception)
                {
                    return false;
                }
                string wiki = properties[2];       
                var internetArticle = new InternetArticleEntity(userId, materialName, dateOfPublication, wiki);
                internetMaterials.Add(internetArticle);
                _materialRepository.AddMaterial(internetArticle);
            }
            if (name == "ElectronicPublication")
            {
                string[] authors = properties[1].Split(',');
                int numberPages = int.Parse(properties[2]);
                string format = properties[3];
                int yearOfPublication = int.Parse(properties[4]);
                var electronic=new ElectronicPublicationEntity(userId, materialName, authors, numberPages, format, yearOfPublication);
                electronicMaterials.Add(electronic);
                _materialRepository.AddMaterial(electronic);
            }
            return true;

        }
        public List<MaterialEntity> ShowMaterials()
        {
            return _materialRepository.ShowMaterials();
        }
    }
}
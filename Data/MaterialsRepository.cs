using Domain.Entity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;
using BL;
using System.Text.Json;

namespace Data
{
    public class MaterialsRepository : IMaterialRepository
    {
        List<VideoResourceEntity> videoMaterials = new List<VideoResourceEntity>();
        List<ElectronicPublicationEntity> electronicMaterials = new List<ElectronicPublicationEntity>();
        List<InternetArticleEntity> internetMaterials = new List<InternetArticleEntity>();
        List<MaterialEntity> materials = new List<MaterialEntity>();
        private readonly string defaultPathVideo = "Video Resources.txt";
        private readonly string defaultPathArticle = "Internet Article.txt";
        private readonly string defaultPathBook = "Electronic Resouces.txt";
        public void SaveList()
        {
            string jsonString;
            jsonString = JsonSerializer.Serialize(materials.OfType<InternetArticleEntity>());
            File.WriteAllText(defaultPathArticle, jsonString);
            jsonString = JsonSerializer.Serialize(materials.OfType<ElectronicPublicationEntity>());
            File.WriteAllText(defaultPathBook, jsonString);
            jsonString = JsonSerializer.Serialize(materials.OfType<VideoResourceEntity>());
            File.WriteAllText(defaultPathVideo, jsonString);
        }
        public List<MaterialEntity> ShowMaterials()
        {
            var result = new List<MaterialEntity>();
            if (!File.Exists(defaultPathArticle))
            {
                File.Create(defaultPathArticle).Close();
            }
            if (!File.Exists(defaultPathBook))
            {
                File.Create(defaultPathBook).Close();
            }
            if (!File.Exists(defaultPathVideo))
            {
                File.Create(defaultPathVideo).Close();
            }

            string jsonString;
            jsonString = File.ReadAllText(defaultPathArticle);
            if (jsonString != "")
            {
                result.AddRange(JsonSerializer.Deserialize<List<InternetArticleEntity>>(jsonString));
            }
            jsonString = File.ReadAllText(defaultPathBook);
            if (jsonString != "")
            {
                result.AddRange(JsonSerializer.Deserialize<List<ElectronicPublicationEntity>>(jsonString));
            }
            jsonString = File.ReadAllText(defaultPathVideo);
            if (jsonString != "")
            {
                result.AddRange(JsonSerializer.Deserialize<List<VideoResourceEntity>>(jsonString));
            }
            return result;
        }
        public List<MaterialEntity> AddMaterial(MaterialEntity material)
        {
            materials.Add(material);
            SaveList();
            return materials;
        }
    }
}

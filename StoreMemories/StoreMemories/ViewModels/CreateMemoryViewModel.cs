using StoreMemories.DataServices;
using StoreMemories.Models;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace StoreMemories.ViewModels
{
    public class CreateMemoryViewModel
    {
        public Memory Memory { get; set; } = new Memory();
        public Photo Photo { get; set; }

        private readonly IMemoryService _memoryService;
        private readonly IPhotoService _photoService;

        public CreateMemoryViewModel(IMemoryService memoryService, IPhotoService photoService)
        {
            _memoryService = memoryService;
            _photoService = photoService;
        }

        public void StoreData()
        {
            SavePhoto();
            SaveMemory();
        }
        
        private Photo SavePhoto()
        {
            if (Memory == null)
                return null;

            try
            {
                return _photoService.Add(Photo);
            }
            catch(Exception e)
            {
                return null;
            }
        }

        private Memory SaveMemory()
        {
            Memory.Photo = Photo;
            Memory.PhotoId = Photo.Id;
            return _memoryService.Add(Memory);
        }
    }
}

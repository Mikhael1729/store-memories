using StoreMemories.DataServices;
using StoreMemories.Models;
using StoreMemories.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace StoreMemories.ViewModels
{
    public class MemoriesViewModel
    {
        // Services.
        private readonly IMemoryService _memoryService;
        private readonly IPhotoService _photoService;

        // To bind.s
        public ObservableCollection<Memory> MemoryList { get; set; }

        public MemoriesViewModel(IMemoryService memoryService, IPhotoService photoService)
        {
            _memoryService = memoryService;
            _photoService = photoService;

            MemoryList = new ObservableCollection<Memory>(memoryService.GetAll());

            foreach (var memory in MemoryList)
                memory.Photo = photoService.Get(memory.PhotoId);

            SubscribeToMessages();
        }

        private void SubscribeToMessages()
        {
            MessagingCenter.Subscribe<CreateMemoryPage, Memory>(this, "NewMemory", (obj, memory) =>
            {
                MemoryList.Add(memory);
            });
        }
    }
}

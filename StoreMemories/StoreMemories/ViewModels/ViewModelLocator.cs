using CommonServiceLocator;

namespace StoreMemories.ViewModels
{
    public class ViewModelLocator
    {
        public CreateMemoryViewModel CreateMemoryViewModel
        {
            get => ServiceLocator.Current.GetInstance<CreateMemoryViewModel>();
        }

        public MemoriesViewModel MemoriesViewModel
        {
            get => ServiceLocator.Current.GetInstance<MemoriesViewModel>();
        }
    }
}

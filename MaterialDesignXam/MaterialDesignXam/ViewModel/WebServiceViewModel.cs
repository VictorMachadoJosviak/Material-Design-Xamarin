using MaterialDesignXam.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MaterialDesignXam.ViewModel
{
    public class WebServiceViewModel : AppViewModelBase
    {
        public WebServiceViewModel()
        {
            LoadData();
        }

        private async Task LoadData()
        {
            IsRunning = true;
            await getAsync();
        }

        public async Task<ObservableCollection<Book>> getAsync()
        {
            using (var client = new HttpClient())
            {
                ListBooks = new ObservableCollection<Book>();

                var json = await client.GetStringAsync("https://mvalivros.azurewebsites.net/api/livros");
                ListBooks = JsonConvert.DeserializeObject<ObservableCollection<Book>>(json);
                IsRunning = false;
                return ListBooks;
            }
        }


        private bool _isrunning;
        public bool IsRunning
        {
            get { return _isrunning; }
            set {Set(ref _isrunning , value); }
        }


        private Book _books;
        public Book Books
        {
            get { return _books; }
            set { Set(ref _books, value); }
        }


        private ObservableCollection<Book> _listBooks;
        public ObservableCollection<Book> ListBooks
        {
            get { return _listBooks; }
            set { Set(ref _listBooks, value); }
        }

    }
}

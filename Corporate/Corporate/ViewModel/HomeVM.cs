using Corporate.Models;
using System.Collections.Generic;

namespace Corporate.ViewModel
{
    public class HomeVM
    {
        public List<Slider> Slider { get; set; }
        public List<AboutCarts> AboutCarts { get;set; }
        public List<PortfolioCategory> PortfolioCategories { get; set; }
        public List<PortfolioItem> PortfolioItems { get; set; }
        public List<Contact> Contacts { get; set; }
        public List<Client> Clients { get; set; }
        public List<ClientComment> ClientComments { get; set; }
    }
}

using Cas12102021.VuesModeles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Cas12102021.Vues
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ClientVue : ContentPage
    {
        ClientVueModele vueModele;
        public ClientVue()
        {
            InitializeComponent();
            BindingContext = vueModele = new ClientVueModele();
        }
    }
}
﻿using Cas12102021.Modeles;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Cas12102021.VuesModeles
{
    class ClientVueModele : BaseVueModele
    {
        #region Attributs


        #endregion

        #region Constructeurs

        public ClientVueModele()
        {

        }

        #endregion

        #region Getters/Setters
        public ICommand CommandeCreerClient => new Command(ActionCommandeCreerClient);

        #endregion

        #region Methodes
        public void ActionCommandeCreerClient()
        {
            Client C1 = new Client {Nom = "Client 01",Prenom = "Prenom 01", Photo = "Photo 01"};

            App.Database.SaveItemClientAsync(C1);

            Client CS = App.Database.GetItemAsync(1).Result;

            ObservableCollection<Client> oc1 = App.Database.GetItemsClientAsync();

        }
        #endregion
    }
}
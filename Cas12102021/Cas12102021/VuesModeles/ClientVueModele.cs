using Cas12102021.Modeles;
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

            int i = App.Database.SaveItemClientAsync(C1).Result;

            Client CS = App.Database.GetItemAsync(i).Result;

            ObservableCollection<Client> oc1 = App.Database.GetItemsClientAsync();
            // Creer objet commande
            Commande CO1 = new Commande { DateCommande = DateTime.Now };
            //mapper dans BDD l'objet Commande
            App.Database.SaveItemCommandeAsync(CO1);
            //Ajouter la commande a la collection lescommandes du client
            CS.LesCommandes.Add(CO1);
            //mettre à jour la relation client commande
            App.Database.MiseAJourRelation(CS);
            //Recuperer l'objet et ses relations
            CS= App.Database.GetClientAvecRelations(CS).Result;
            /////////////////
            Commander CDR1 = new Commander { Quantite = 5 };
            App.Database.SaveItemCommanderAsync(CDR1);
            CO1.LesLignesCommandes.Add(CDR1);
            App.Database.MiseAJourRelation(CO1);
            CO1 = App.Database.GetCommandeAvecRelations(CO1).Result;
        }
        #endregion
    }
}
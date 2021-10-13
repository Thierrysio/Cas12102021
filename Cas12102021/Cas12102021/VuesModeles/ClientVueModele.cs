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
        private Produit _unProduit;
        private double _unProduitTarif;
        private double _total;
        private ObservableCollection<Produit> _listProduit;
        #endregion

        #region Constructeurs

        public ClientVueModele()
        {

        }

        #endregion

        #region Getters/Setters
        public ICommand CommandeCreerClient => new Command(ActionCommandeCreerClient);
        public ICommand CommandeCreerClient2 => new Command(ActionCommandeCreerClient2);

        public Produit UnProduit
        {
            get
            {
                return _unProduit;
            }
            set
            {
                SetProperty(ref _unProduit, value);
            }
        }
        public double UnProduitTarif
        {
            get
            {
                return _unProduitTarif;
            }
            set
            {
                
                SetProperty(ref _unProduitTarif, value);
            }
        }
        public ObservableCollection<Produit> ListProduit
        {
            get
            {
                return _listProduit;
            }
            set
            {

                SetProperty(ref _listProduit, value);
            }
        }
        #endregion

        #region Methodes
        public async void ActionCommandeCreerClient()
        {
            Client CS = new Client {Nom = "Client 01",Prenom = "Prenom 01", Photo = "Photo 01"};
            int x = App.Database.SaveItemClientAsync(CS).Result;
            ObservableCollection<Client> oc1 = App.Database.GetItemsClientAsync();
            /////////////////
            // Creer objet commande
            Commande CO1 = new Commande { DateCommande = DateTime.Now };
            //mapper dans BDD l'objet Commande
            x = await App.Database.SaveItemCommandeAsync(CO1);
            //Ajouter la commande a la collection lescommandes du client
            CS.LesCommandes.Add(CO1);
            //mettre à jour la relation client commande
            await App.Database.MiseAJourRelation(CS);
            //Recuperer l'objet et ses relations
            CS= await  App.Database.GetClientAvecRelations(CS);
            /////////////////
            Commander CDR1 = new Commander { Quantite = 5 };
            x = await App.Database.SaveItemCommanderAsync(CDR1);
            CO1.LesLignesCommandes.Add(CDR1);
            await App.Database.MiseAJourRelation(CO1);
            CO1 = await  App.Database.GetCommandeAvecRelations(CO1);
            /////////////////
            Produit P1 = new Produit { Nom = "Produit 01", Photo = "photo 01", Prix = 23 };
            x = await App.Database.SaveItemProduitAsync(P1) ;
            P1.LesLignesCommande.Add(CDR1);
            await App .Database.MiseAJourRelation(P1);
            CDR1 = await  App.Database.GetCommanderAvecRelations(CDR1);

            Client c = await  App.Database.GetClientAvecRelations(CS);
            Commande c1 = await App .Database.GetCommandeAvecRelations(c.LesCommandes[0]);
            Commander c2 = await App.Database.GetCommanderAvecRelations(c1.LesLignesCommandes[0]) ;
            string c3 = c2.LesProduits.Nom;
        }

        public async void ActionCommandeCreerClient2()
        {
            UnProduit = new Produit { Nom = "Produit 01", Photo = "photo 01", Prix = 23};
            UnProduit.Total = UnProduit.GetTarif();

            int x = await App.Database.SaveItemProduitAsync(UnProduit);

            Commande CO1 = new Commande { DateCommande = DateTime.Now };
           
            x = await App.Database.SaveItemCommandeAsync(CO1);

            Client CS = new Client { Nom = "Client 01", Prenom = "Prenom 01", Photo = "Photo 01" };
            x = await App.Database.SaveItemClientAsync(CS);

            CS.LesCommandes.Add(CO1);
            await App.Database.MiseAJourRelation(CS);

            CS = await App.Database.GetClientAvecRelations(CS);


            Commander CDR1 = new Commander { Quantite = 5, LesProduits = UnProduit };
            x = await App.Database.SaveItemCommanderAsync(CDR1);

           await  App.Database.MiseAJourRelation(CDR1);
            CO1.LesLignesCommandes.Add(CDR1);
           
            await App.Database.MiseAJourRelation(CO1);

            CDR1 = App.Database.GetCommanderAvecRelations(CDR1).Result;

            UnProduitTarif = UnProduit.GetTarif();

            ListProduit =  App.Database.GetItemsProduitAsync();
        }
            #endregion
        }
}
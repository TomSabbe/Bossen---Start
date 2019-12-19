using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Bossen.Lib.Entities;

namespace Bossen.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Boss veltembos = new Boss("Veltembos");
        Boss ryckeveldt = new Boss("Ryckeveldt");
        Boss huidigeBos;
        Boom huidigeBoom;

        public MainWindow()
        {
            InitializeComponent();
        }

        void KoppelBomen()
        {
            huidigeBos = (Boss)cmbBos.SelectedItem;
            lstBomen.ItemsSource = huidigeBos.Bomen;
            lstBomen.Items.Refresh(); 
        }

        

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
            cmbBoomSoort.ItemsSource = Enum.GetValues(typeof(Boomsoorten));
            cmbBoomSoortTelling.ItemsSource = Enum.GetValues(typeof(Boomsoorten));
            cmbBos.Items.Add(ryckeveldt);
            cmbBos.Items.Add(veltembos);
            cmbBos.SelectedIndex = 0;

            
        }

        private void cmbBos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            KoppelBomen();
        }

        private void lstBomen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstBomen.SelectedItem != null)
            {
                huidigeBoom = (Boom)lstBomen.SelectedItem;
                txtBoomNaam.Text = huidigeBoom.Naam;
                txtHoogte.Text = huidigeBoom.HoogteInMeter.ToString("0.00");
                cmbBoomSoort.SelectedItem = huidigeBoom.Soort;
            }
            else
            {
                huidigeBoom = null;
            }
        }

        private void btnNieuw_Click(object sender, RoutedEventArgs e)
        {
            ClearPanel(grdBoom);
            txtBoomNaam.Focus();
        }

        private void btnOpslaan_Click(object sender, RoutedEventArgs e)
        {
            string naam = txtBoomNaam.Text;
            try
            {
                float hoogte = float.Parse(txtHoogte.Text);
                Boomsoorten boomSoort = (Boomsoorten)cmbBoomSoort.SelectedItem;
                Guid? id = null;
                if (huidigeBoom != null)
                {
                    id = huidigeBoom.Id;
                    huidigeBoom.Naam = naam;
                    huidigeBoom.HoogteInMeter = hoogte;
                    huidigeBoom.Soort = boomSoort;

                }
                else
                {
                    huidigeBoom = new Boom(naam, hoogte, boomSoort);
                }
                huidigeBos.SlapOp(huidigeBoom);
                ToonMelding($"{huidigeBoom.Naam} is opgeslagen", true);
                KoppelBomen();
                lstBomen.SelectedIndex = 0;
            }
            catch (FormatException ex)
            {
                ToonMelding(ex.Message);
            }
            catch (Exception ex)
            {
                ex.GetType();
                ToonMelding($"{huidigeBoom.Naam} is niet opgeslagen", false);
                

            }
            

            
        }

        private void btnVerwijder_Click(object sender, RoutedEventArgs e)
        {
            if (huidigeBoom != null)
            {
                huidigeBos.TeVerwijderen(huidigeBoom);
                KoppelBomen();
                ClearPanel(grdBoom);
            }
        }

        private void cmbBoomSoortTelling_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lblAantal.Content = huidigeBos.GeefAantalBomen((Boomsoorten)cmbBoomSoort.SelectedItem);
        }
    }
}

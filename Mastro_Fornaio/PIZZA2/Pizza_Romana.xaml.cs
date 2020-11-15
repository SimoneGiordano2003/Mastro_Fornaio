using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Mastro_Fornaio
{
    /// <summary>
    /// Pagina per ottenere l'input della ricetta per la Pizza Romana.
    /// </summary>
    public sealed partial class Pizza_Romana : Page
    {
        public Pizza_Romana()
        {
            this.InitializeComponent();
        }

        private void Calcola_Click(object sender , RoutedEventArgs e)
        {
            double _idroP,  _olio, _tAmbiente, _lievEsterna, _lievFrigo, _sale, _area;

            try //Evita errori in input
            {
                if (Forma.IsOn)
                {
                    double raggio = double.Parse(Raggio.Text);
                    _area         = raggio * raggio * 3.14;
                }
                else
                {
                    _area = double.Parse( L1Teglia.Text ) * double.Parse( L2Teglia.Text );
                }

                _tAmbiente   = double.Parse( TAmbiente.Text );
                _lievEsterna = double.Parse( Lievitazione_Esterno.Text );
                _lievFrigo   = double.Parse( Lievitazione_Frigo.Text );

                _olio  = Olio.Value;
                _idroP = IdroP.Value / 100;
                _sale  = Sale.Value;

                int peso_impasto        = Convert.ToInt32(_area * 0.5);
                double peso_idratazione = peso_impasto * _idroP / (1.0 + _idroP);
                double peso_olio        = peso_idratazione * _olio / 1000;
                double peso_sale        = peso_idratazione * _sale/1000;
                int peso_acqua          = Convert.ToInt32( peso_idratazione - peso_olio );
                int peso_farina         = Convert.ToInt32((peso_impasto / (1 +_idroP) )- peso_sale);
                double peso_lievito     = 0.00226 * F_Temperatura(_tAmbiente) * peso_impasto * F_idro(_idroP) * (1 + 0.006 * _sale) * (1 + 0.004 * _olio) / ((_lievEsterna + _lievFrigo > 3 ? _lievEsterna + _lievFrigo : 3) - 0.90 * _lievFrigo - 1.26);

                MainFrame.Content = new Risultato( peso_olio , peso_sale , peso_acqua , peso_farina , peso_lievito , Risultato.Impasto.Romana );
            }
            catch (Exception)
            {
                Errore.Text = "ERRORE NEI DATI";
            }
        }

        private double F_idro(double idroP)
        {
            return idroP > 65 ? 1.0 : 1 - (2.7 * (idroP - 0.65));
        }

        private double F_Temperatura(double T)
        {
            return T > 20 ? 2 - T / 20 : 2.1 - (T - 15) / 3.5;
        }
    }
}
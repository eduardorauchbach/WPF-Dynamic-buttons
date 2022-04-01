using FromZero.Desktop.Domain.Helpers;
using FromZero.Desktop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FromZero.Desktop.Domain.ViewModels
{
    public class MainWindowViewModel : MasterViewModel
    {
        public ObservableCollection<MosaicItem> MosaicItems { get; set; }
        public ObservableCollection<MenuItem> MenuItems { get; set; }

        public MainWindowViewModel()
        {
            MosaicItems = new ();
            MosaicItems.Add(new MosaicItem("Atendimento", "", "atendimento.svg", 1));
            MosaicItems.Add(new MosaicItem("Despacho", "", "Despacho.svg", 2));
            MosaicItems.Add(new MosaicItem("Supervisão", "", "Supervisao.svg", 3));
            MosaicItems.Add(new MosaicItem("Administrador", "", "administrador.svg", 4));
            MosaicItems.Add(new MosaicItem("Nota Urgente", "", "nota_urgente.svg", 5));
            MosaicItems.Add(new MosaicItem("Ocorrências", "", "ocorrencias.svg", 6));
            MosaicItems.Add(new MosaicItem("Consultas", "", "consultas.svg", 7));
            MosaicItems.Add(new MosaicItem("CEPOL", "", "cepol.svg", 8));
            MosaicItems.Add(new MosaicItem("Gerenciamento de Usuários e Apps", "", "gerenciamento_de_usuarios_e_apps.svg", 9));
            MosaicItems.Add(new MosaicItem("Relatórios", "", "relatorios.svg", 10));
            MosaicItems.Add(new MosaicItem("Árvore de Decisões", "", "arvore_de_decisoes.svg", 11));
            MosaicItems.Add(new MosaicItem("Registro de Ocorrência", "", "registro_de_ocorrencias.svg", 12));
            MosaicItems.Add(new MosaicItem("Web AIA", "", "web_aia.svg", 13));
            MosaicItems.Add(new MosaicItem("COPOM Online", "", "copom_online.svg", 14));
            MosaicItems.Add(new MosaicItem("Mapa Força", "", "mapa_forca.svg", 15));

            MenuItems = new();
            MenuItems.Add(new MenuItem("Menu 1", "Menu numero 1", 1));
            MenuItems.Add(new MenuItem("Menu 2", "Menu numero 2", 1));
            MenuItems.Add(new MenuItem("Menu 3", "Menu numero 3", 1));
            MenuItems.Add(new MenuItem("Menu 4", "Menu numero 4", 1));

            MosaicItems.BuildPositions(columns: 6);
            MosaicItems.AdjustTitles(maxlength: 20);
        }
    }
}

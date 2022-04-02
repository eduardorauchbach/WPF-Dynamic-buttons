using FromZero.Desktop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FromZero.Desktop.Domain.Constants
{
    public static class MosaicDefault
    {
        public static List<MosaicItem> items = new()
        {
            new MosaicItem("Atendimento", "", "atendimento.svg", 1),
            new MosaicItem("Despacho", "", "Despacho.svg", 2),
            new MosaicItem("Supervisão", "", "Supervisao.svg", 3),
            new MosaicItem("Administrador", "", "administrador.svg", 4),
            new MosaicItem("Nota Urgente", "", "nota_urgente.svg", 5),
            new MosaicItem("Ocorrências", "", "ocorrencias.svg", 6),
            new MosaicItem("Consultas", "", "consultas.svg", 7),
            new MosaicItem("CEPOL", "", "cepol.svg", 8),
            new MosaicItem("Gerenciamento de Usuários e Apps", "", "gerenciamento_de_usuarios_e_apps.svg", 9),
            new MosaicItem("Relatórios", "", "relatorios.svg", 10),
            new MosaicItem("Árvore de Decisões", "", "arvore_de_decisoes.svg", 11),
            new MosaicItem("Registro de Ocorrência", "", "registro_de_ocorrencias.svg", 12),
            new MosaicItem("Web AIA", "", "web_aia.svg", 13),
            new MosaicItem("COPOM Online", "", "copom_online.svg", 14),
            new MosaicItem("Mapa Força", "", "mapa_forca.svg", 15),
        };
    }
}

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
            new MosaicItem("Atendimento", "", "atendimento.svg", true, 1),
            new MosaicItem("Despacho", "", "Despacho.svg", true, 2),
            new MosaicItem("Supervisão", "", "Supervisao.svg", true, 3),
            new MosaicItem("Administrador", "", "administrador.svg", true, 4),
            new MosaicItem("Nota Urgente", "", "nota_urgente.svg", true, 5),
            new MosaicItem("Ocorrências", "", "ocorrencias.svg", true, 6),
            new MosaicItem("Consultas", "", "consultas.svg", true, 7),
            new MosaicItem("CEPOL", "", "cepol.svg", true, 8),
            new MosaicItem("Gerenciamento de Usuários e Apps", "", "gerenciamento_de_usuarios_e_apps.svg", true, 9),
            new MosaicItem("Relatórios", "", "relatorios.svg", true, 10),
            new MosaicItem("Árvore de Decisões", "", "arvore_de_decisoes.svg", true, 11),
            new MosaicItem("Registro de Ocorrência", "", "registro_de_ocorrencias.svg", true, 12),
            new MosaicItem("Web AIA", "", "web_aia.svg", true, 13),
            new MosaicItem("COPOM Online", "", "copom_online.svg", true, 14),
            new MosaicItem("Mapa Força", "", "mapa_forca.svg", true, 15),
        };
    }
}

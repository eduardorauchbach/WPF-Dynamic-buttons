using FromZero.Desktop.Domain.Models;
using System.Collections.Generic;

namespace FromZero.Desktop.Domain.Constants
{
    public static class MosaicDefault
    {
        public readonly static List<MosaicItem> Items = new()
        {
            new MosaicItem(MosaicTargets.Attendance, "Atendimento", "", "atendimento.svg", false, 1),
            new MosaicItem(MosaicTargets.Dispatch, "Despacho", "", "Despacho.svg", false, 2),
            new MosaicItem(MosaicTargets.Supervision, "Supervisão", "", "Supervisao.svg", true, 3),
            new MosaicItem(MosaicTargets.Administration, "Administrador", "", "administrador.svg", true, 4),
            new MosaicItem(MosaicTargets.UrgentNote, "Nota Urgente", "", "nota_urgente.svg", false, 5),
            new MosaicItem(MosaicTargets.Occurrences, "Ocorrências", "", "ocorrencias.svg", false, 6),
            new MosaicItem(MosaicTargets.Queries, "Consultas", "", "consultas.svg", false, 7),
            new MosaicItem(MosaicTargets.CEPOL, "CEPOL", "", "cepol.svg", true, 8),
            new MosaicItem(MosaicTargets.AppUserManagment, "Gerenciamento de Usuários e Apps", "", "gerenciamento_de_usuarios_e_apps.svg", false, 9),
            new MosaicItem(MosaicTargets.Reports, "Relatórios", "", "relatorios.svg", false, 10),
            new MosaicItem(MosaicTargets.DecisonTree, "Árvore de Decisões", "", "arvore_de_decisoes.svg", true, 11),
            new MosaicItem(MosaicTargets.OccurrenceRegister, "Registro de Ocorrência", "", "registro_de_ocorrencias.svg", true, 12),
            new MosaicItem(MosaicTargets.WebAIA, "Web AIA", "", "web_aia.svg", true, 13),
            new MosaicItem(MosaicTargets.COPOM, "COPOM Online", "", "copom_online.svg", false, 14),
            new MosaicItem(MosaicTargets.ForceMap, "Mapa Força", "", "mapa_forca.svg", true, 15),
        };

        public enum MosaicTargets
        {
            Attendance, //Atendimento
            Dispatch, //Despacho
            Supervision, //Supervisão
            Administration, //Administrador
            UrgentNote, //Nota Urgente
            Occurrences, //Ocorrências
            Queries, //Consultas
            CEPOL, //CEPOL
            AppUserManagment, //Gerenciamento de Usuários e Apps
            Reports, //Relatórios
            DecisonTree, //Árvore de Decisões
            OccurrenceRegister, //Registro de Ocorrência
            WebAIA, //Web AIA
            COPOM, //COPOM Online
            ForceMap, //Mapa Força
        }
    }
}

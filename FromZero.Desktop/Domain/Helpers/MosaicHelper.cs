using FromZero.Desktop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FromZero.Desktop.Domain.Helpers
{
    internal static class MosaicHelper
    {
        /// <summary>
        /// reorder and fill row and collum based on the IconIndex
        /// </summary>
        /// <param name="menuItems"></param>
        /// <param name="columns">Preferential, ignores rows if filled</param>
        /// <param name="rows"></param>
        public static void BuildPositions(this IEnumerable<MosaicItem> menuItems, int? columns = null, int? rows = null)
        {
            menuItems = menuItems.OrderBy(x => x.IconIndex);

            columns ??= (int)Math.Ceiling(menuItems.Count() / (decimal)(rows ?? 1));

            int currentRow = 0;
            int currentColumn = 0;

            foreach (MosaicItem item in menuItems)
            {
                item.Column = currentColumn;
                item.Row = currentRow;

                if (currentColumn < (columns - 1))
                {
                    currentColumn++;
                }
                else
                {
                    currentColumn = 0;
                    currentRow++;
                }
            }
        }

        public static void AdjustTitles(this IEnumerable<MosaicItem> menuItems, int maxlength)
        {
            foreach (MosaicItem item in menuItems)
            {
                if (item.Title.Length > maxlength)
                {
                    List<string> pieces = item.Title.Split(' ').ToList();

                    for (int i = pieces.Count - 1; i >= 0; i--)
                    {
                        if (string.Join(" ", pieces).Length > maxlength)
                        {
                            item.Title2 = (item.Title2 is null) ? pieces[i] : pieces[i] + " " + item.Title2;
                            pieces.RemoveAt(i);
                        }
                    }
                    item.Title = string.Join(" ", pieces);
                }
            }
        }
    }
}

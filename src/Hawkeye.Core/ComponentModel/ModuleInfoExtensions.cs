﻿using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Hawkeye.ComponentModel
{
    internal static class ModuleInfoExtensions
    {
        /// <summary>
        /// Dumps to.
        /// </summary>
        /// <param name="module">The module.</param>
        /// <param name="builder">The builder.</param>
        public static void DumpTo(this IModuleInfo module, StringBuilder builder)
        {
            DumpTo(module, builder, 0);
        }

        /// <summary>
        /// Dumps to.
        /// </summary>
        /// <param name="module">The module.</param>
        /// <param name="builder">The builder.</param>
        /// <param name="tabCount">The tab count.</param>
        public static void DumpTo(this IModuleInfo module, StringBuilder builder, int tabCount)
        {
            var converter = new ModuleInfoConverter();
            converter.GetProperties(module)
                .Cast<PropertyDescriptor>()
                .OrderBy(pd => pd.Name)
                .Select(pd => new
                {
                    Name = pd.Name,
                    Value = pd.GetValue(module).ToString()
                })
                .Aggregate((acc, pair) =>
                {
                    builder.AppendFormattedLine(tabCount, "{0} = {1}",
                        pair.Name, pair.Value);
                    return pair;
                });
        }
    }
}
